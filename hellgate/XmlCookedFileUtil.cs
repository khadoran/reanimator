﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using Hellgate.Xml;
using Revival.Common;

namespace Hellgate
{
    public partial class XmlCookedFile
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class XmlCookFileHeader
        {
            public UInt32 MagicWord;
            public Int32 Version;
            public UInt32 XmlRootDefinition;
            public Int32 XmlRootElementCount;
        }

        /// <summary>
        /// Initialize XML Definitions and generate String Hash values for xml element names.
        /// Must be called before usage of the class.
        /// </summary>
        /// <param name="fileManager">The loaded table data set of excel/strings for excel lookups.</param>
        public static void Initialize(FileManager fileManager)
        {
            Debug.Assert(fileManager != null);

            _fileManager = fileManager;
            _xmlDefinitions = new XmlDefinition[]
            {
                // AI
                new AIDefinition(),
                new AIBehaviorDefinitionTable(),
                new AIBehaviorDefinition(),

                // Appearance
                new AppearanceDefinition(),
                new AnimationDefinition(),
                new AnimEvent(),
                new InventoryViewInfo(),

                // Colorsets (colorsets.xml)
                new ColorSetDefinition(),
                new ColorDefinition(),

                // Config (config.xml)
                new ConfigDefinition(),

                // GameGlobalDefinition (gamedefault.xml)
                new GameGlobalDefinition(),

                // GlobalDefinition (default.xml)
                new GlobalDefinition(),

                // Shared (used in States, Skills amd Appearance)
                new ConditionDefinition(),

                // Level Layout (contains object positions etc)
                new RoomLayoutGroupDefinition(),
                new RoomLayoutGroup(),

                // Level Pathing (huge-ass list of nodes/points)
                // todo: not all are completely parsing
                //new RoomPathNodeDefinition(),
                //new RoomPathNodeSet(),
                //new RoomPathNode(),
                //new RoomPathNodeConnection(),
                //new RoomPathNodeConnectionRef(),

                // Material (makes things look like things)
                new Material(),

                // Skills (defines skill effect/appearance mostly, not so much the skill itself)
                new SkillEventsDefinition(),
                new SkillEventHolder(),
                new SkillEvent(),

                // Sound Effects
                new SoundEffectDefinition(),
                new SoundEffect(),

                // States
                new StateDefinition(),
                new StateEvent(),

                // Textures
                new TextureDefinition(),
                new BlendRLE(),
                new BlendRun()
            };

            // create hashes
            foreach (XmlDefinition xmlDefinition in _xmlDefinitions)
            {
                xmlDefinition.RootHash = Crypt.GetStringHash(xmlDefinition.RootElement);

                foreach (XmlCookElement xmlCookElement in xmlDefinition.Elements)
                {
                    String stringToHash = String.IsNullOrEmpty(xmlCookElement.TrueName) ? xmlCookElement.Name : xmlCookElement.TrueName;
                    xmlCookElement.NameHash = Crypt.GetStringHash(stringToHash);
                }
            }

            // assign child table hashes
            foreach (XmlDefinition xmlDefinition in _xmlDefinitions)
            {
                foreach (XmlCookElement xmlCookElement in xmlDefinition.Elements)
                {
                    if (xmlCookElement.ChildType == null) continue;

                    Type childType = xmlCookElement.ChildType;
                    foreach (XmlDefinition xmlDef in _xmlDefinitions.Where(def => def.GetType() == childType))
                    {
                        xmlCookElement.ChildTypeHash = xmlDef.RootHash;
                        break;
                    }

                    Debug.Assert(xmlCookElement.ChildTypeHash != 0);
                }
            }
        }

        /// <summary>
        /// Searches for a known XML Definition using their Root Element String Hash.
        /// </summary>
        /// <param name="stringHash">The String Hash of the Root Element to find.</param>
        /// <returns>Found XML Definition or null if not found.</returns>
        private static XmlDefinition _GetXmlDefinition(UInt32 stringHash)
        {
            XmlDefinition xmlDefinition = _xmlDefinitions.FirstOrDefault(xmlDef => xmlDef.RootHash == stringHash);
            if (xmlDefinition != null) xmlDefinition.ResetFields();

            return xmlDefinition;
        }

        /// <summary>
        /// Searches for an XML Cook Element in an XML Definition for an Element with a particular String Hash.
        /// </summary>
        /// <param name="xmlDefinition">The XML Definition to search through.</param>
        /// <param name="stringHash">The String Hash of the Element Name to find.</param>
        /// <returns>Found XML Cook Element or null if not found.</returns>
        private static XmlCookElement _GetXmlCookElement(XmlDefinition xmlDefinition, UInt32 stringHash)
        {
            return xmlDefinition.Elements.FirstOrDefault(xmlCookElement => xmlCookElement.NameHash == stringHash);
        }

        private static bool _TestBit(IList<byte> bitField, int byteOffset, int bitOffset)
        {
            byteOffset += bitOffset >> 3;
            bitOffset &= 0x07;

            return (bitField[byteOffset] & (1 << bitOffset)) >= 1;
        }

        private static void _FlagBit(IList<byte> bitField, int byteOffset, int bitOffset)
        {
            byteOffset += bitOffset >> 3;
            bitOffset &= 0x07;

            bitField[byteOffset] |= (byte)(1 << bitOffset);
        }

        #region ReadFunctions
        private String _ReadByteString()
        {
            byte strLen = _buffer[_offset++];
            if (strLen == 0xFF || strLen == 0x00) return null;

            return FileTools.ByteArrayToStringASCII(_buffer, ref _offset, strLen);
        }

        private void _ReadExcelIndex(XmlNode parentNode, XmlCookElement xmlCookElement)
        {
            String excelString = _ReadByteString();
            if (String.IsNullOrEmpty(excelString)) return;

            if (parentNode == null) return;

            // get excel table index
            int rowIndex = _fileManager.GetExcelRowIndex(xmlCookElement.ExcelTableCode, excelString);
            if (rowIndex == -1) throw new Exceptions.UnknownExcelElementException("excelString = " + excelString);

            XmlNode grandParentNode = parentNode.ParentNode;
            XmlNode descriptionNode = grandParentNode.LastChild.PreviousSibling;

            if (descriptionNode != null)
            {
                if (!String.IsNullOrEmpty(descriptionNode.InnerText)) descriptionNode.InnerText += ", ";
                descriptionNode.InnerText += excelString;
            }

            XmlElement element = XmlDoc.CreateElement(xmlCookElement.Name);
            element.InnerText = rowIndex.ToString();
            parentNode.AppendChild(element);
        }

        private void _ReadTable(XmlNode parentNode, XmlCookElement xmlCookElement, XmlCookedFileTree xmlTree)
        {
            String elementName = xmlCookElement.Name;
            Debug.Assert(xmlCookElement.ChildType != null);

            int count = 1;
            if (xmlCookElement.ElementType == ElementType.TableCount)
            {
                elementName += "Count";
                count = _ReadInt32(parentNode, elementName);

                if (count == 0)
                {
                    parentNode.RemoveChild(parentNode.LastChild);
                }
            }

            for (int i = 0; i < count; i++)
            {
                XmlElement tableDesc = XmlDoc.CreateElement(xmlCookElement.Name);
                parentNode.AppendChild(tableDesc);

                _UncookXmlData(xmlTree.Definition, parentNode, xmlTree.TwinRoot);
            }
        }

        private bool _ReadFlag(XmlNode parentNode, XmlDefinition xmlDefinition, XmlCookElement xmlCookElement)
        {
            int flagIndex = xmlCookElement.FlagId;
            if (xmlCookElement.ElementType == ElementType.Flag) flagIndex--;

            Debug.Assert(flagIndex >= 0);
            if (xmlDefinition.BitFields[flagIndex] == -1)
            {
                xmlDefinition.BitFields[flagIndex] = _ReadInt32(null, null);
            }

            bool flagged = false;
            switch (xmlCookElement.ElementType)
            {
                case ElementType.BitFlag:
                    flagged = (xmlDefinition.BitFields[flagIndex] & (1 << xmlCookElement.BitIndex)) > 0;
                    break;

                case ElementType.Flag:
                    flagged = (xmlDefinition.BitFields[flagIndex] & xmlCookElement.BitMask) > 0;
                    break;
            }

            if (parentNode != null)
            {
                XmlElement element = XmlDoc.CreateElement(xmlCookElement.Name);
                element.InnerText = flagged ? "1" : "0";

                parentNode.AppendChild(element);
            }

            return flagged;
        }

        private bool _ReadBitFlag(XmlNode parentNode, XmlDefinition xmlDefinition, XmlCookElement xmlCookElement)
        {
            if (xmlDefinition.NeedToReadBitFlags)
            {
                int intCount = xmlDefinition.BitFlags.Length;
                for (int i = 0; i < intCount; i++)
                {
                    xmlDefinition.BitFlags[i] = _ReadUInt32(null, null);
                }

                xmlDefinition.NeedToReadBitFlags = false;
            }

            int intIndex = xmlCookElement.BitIndex >> 5;
            int bitOffset = xmlCookElement.BitIndex - (intIndex << 5);
            bool flagged = (xmlDefinition.BitFlags[intIndex] & (1 << bitOffset)) > 0;

            if (parentNode != null)
            {
                XmlElement element = XmlDoc.CreateElement(xmlCookElement.Name);
                element.InnerText = flagged ? "1" : "0";

                parentNode.AppendChild(element);
            }

            return flagged;
        }

        private Int32 _ReadInt32(XmlNode parentNode, String elementName)
        {
            Int32 value = FileTools.ByteArrayToInt32(_buffer, ref _offset);

            if (parentNode != null && elementName != null)
            {
                XmlElement element = XmlDoc.CreateElement(elementName);
                element.InnerText = value.ToString();
                parentNode.AppendChild(element);
            }

            return value;
        }

        private bool _ReadBool32(XmlNode parentNode, String elementName)
        {
            bool value = _ReadInt32(null, null) != 0;

            if (parentNode != null && elementName != null)
            {
                XmlElement element = XmlDoc.CreateElement(elementName);
                element.InnerText = value.ToString();
                parentNode.AppendChild(element);
            }

            return value;
        }

        private UInt32 _ReadUInt32(XmlNode parentNode, String elementName)
        {
            UInt32 value = FileTools.ByteArrayToUInt32(_buffer, ref _offset);

            if (parentNode != null && elementName != null)
            {
                XmlElement element = XmlDoc.CreateElement(elementName);
                element.InnerText = value.ToString();
                parentNode.AppendChild(element);
            }

            return value;
        }

        private float _ReadFloat(XmlNode parentNode, String elementName)
        {
            float value = FileTools.ByteArrayToFloat(_buffer, ref _offset);

            // is the float value a negative zero?
            bool isNegativeZero = false;
            if (value == 0)
            {
                if (_TestBit(_buffer, _offset - 1, 7))
                {
                    isNegativeZero = true;
                }
            }

            if (parentNode != null && elementName != null)
            {
                XmlElement element = XmlDoc.CreateElement(elementName);
                element.InnerText = (isNegativeZero ? "-" : "") + value;
                parentNode.AppendChild(element);
            }

            return value;
        }

        private String _ReadZeroString(XmlNode parentNode, XmlCookElement xmlCookElement)
        {
            Int32 strLen = FileTools.ByteArrayToInt32(_buffer, ref _offset);
            Debug.Assert(strLen != 0);

            String value;
            if (xmlCookElement.TreatAsData && strLen > 0)
            {
                byte[] data = new byte[strLen];
                Buffer.BlockCopy(_buffer, _offset, data, 0, strLen);
                value = BitConverter.ToString(data);
            }
            else
            {
                value = strLen == 1 ? String.Empty : FileTools.ByteArrayToStringASCII(_buffer, _offset);
            }

            _offset += strLen;

            if (parentNode != null && !String.IsNullOrEmpty(value))
            {
                XmlElement element = XmlDoc.CreateElement(xmlCookElement.Name);
                element.InnerText = value;
                parentNode.AppendChild(element);
            }

            return value;
        }

        private void _ReadZeroStringArray(XmlNode parentNode, XmlCookElement xmlCookElement)
        {
            int count = _ReadInt32(null, null);
            Debug.Assert(count != 0);

            XmlElement countElement = XmlDoc.CreateElement(xmlCookElement.Name + "Count");
            countElement.InnerText = count.ToString();
            parentNode.AppendChild(countElement);

            for (int i = 0; i < count; i++)
            {
                _ReadZeroString(parentNode, xmlCookElement);
            }
        }

        private void _ReadVariableLengthFloatArray(XmlNode parentNode, XmlCookElement xmlCookElement)
        {
            int count = _ReadInt32(null, null);
            Debug.Assert(count != 0);

            XmlElement countElement = XmlDoc.CreateElement(xmlCookElement.Name + "Count");
            countElement.InnerText = count.ToString();
            parentNode.AppendChild(countElement);

            for (int i = 0; i < count; i++)
            {
                _ReadFloat(parentNode, xmlCookElement.Name);
            }
        }

        private void _ReadTFloatArray(XmlNode parentNode, XmlCookElement xmlCookElement)
        {
            int count = _ReadInt32(null, null);
            Debug.Assert(count == 1); // not tested with anything other than 1 - not even sure if it's a count

            XmlElement countElement = XmlDoc.CreateElement(xmlCookElement.Name + "Count");
            countElement.InnerText = count.ToString();
            parentNode.AppendChild(countElement);

            for (int i = 0; i < count; i++)
            {
                for (int f = 0; f < 4; f++)
                {
                    _ReadFloat(parentNode, xmlCookElement.Name);
                }
            }
        }
        #endregion

        #region WriteFunctions
        private void _WriteInt32(String elementText, XmlCookElement xmlCookElement)
        {
            Int32 intValue = Convert.ToInt32(elementText);
            if ((Int32)xmlCookElement.DefaultValue == intValue) return;
            FileTools.WriteToBuffer(ref _buffer, ref _offset, intValue);
        }

        private void _WriteRGBADoubleWordArray(String elementText, XmlCookElement xmlCookElement, XmlNode xmlNode)
        {
            int dwArrayCount = xmlCookElement.Count;
            List<UInt32> dwElements = new List<UInt32>();
            bool dwAllDefault = true;
            foreach (XmlNode xmlChildNode in xmlNode.ChildNodes)
            {
                if (xmlChildNode.Name != xmlCookElement.Name) continue;

                String arrayElementText = xmlChildNode.InnerText;
                UInt32 dwValue = UInt32.Parse(arrayElementText);
                dwElements.Add(dwValue);

                if ((UInt32)xmlCookElement.DefaultValue != dwValue)
                {
                    dwAllDefault = false;
                }

                if (dwElements.Count == dwArrayCount) break;
            }

            if (dwAllDefault) return;

            for (int i = 0; i < dwArrayCount; i++)
            {
                UInt32 dwWrite = (UInt32)xmlCookElement.DefaultValue;
                if (i < dwElements.Count)
                {
                    dwWrite = dwElements[i];
                }

                FileTools.WriteToBuffer(ref _buffer, ref _offset, dwWrite);
            }
        }

        private void _WriteFloat(String elementText, XmlCookElement xmlCookElement)
        {
            float floatValue = Convert.ToSingle(elementText);
            if ((float)xmlCookElement.DefaultValue == floatValue) return;
            FileTools.WriteToBuffer(ref _buffer, ref _offset, floatValue);
        }

        private void _WriteString(String elementText, XmlCookElement xmlCookElement)
        {
            if ((String)xmlCookElement.DefaultValue == elementText) return;

            Int32 strLen = elementText.Length;
            if (strLen == 0 && xmlCookElement.DefaultValue == null) return;

            byte[] strBytes;
            if (xmlCookElement.TreatAsData)
            {
                String[] dataStrBytes = elementText.Split('-');
                strLen = dataStrBytes.Length - 1; //+1 done down below

                strBytes = new byte[strLen];
                for (int i = 0; i < strLen; i++)
                {
                    strBytes[i] = Byte.Parse(dataStrBytes[i], System.Globalization.NumberStyles.HexNumber);
                }
            }
            else
            {
                strBytes = FileTools.StringToASCIIByteArray(elementText);
            }

            FileTools.WriteToBuffer(ref _buffer, ref _offset, strLen + 1);
            FileTools.WriteToBuffer(ref _buffer, ref _offset, strBytes);

            _offset++; // \0
        }

        private void _WriteUnknownFloatT(String elementText, XmlCookElement xmlCookElement, XmlNode xmlNode)
        {
            Int32 count = Convert.ToInt32(elementText);
            FileTools.WriteToBuffer(ref _buffer, ref _offset, count);

            int floatTCount = xmlCookElement.Count;
            List<float> floatTValues = new List<float>();
            bool floatTAllDefault = true;

            int totalFloatTCount = count * floatTCount;
            foreach (XmlNode xmlChildNode in xmlNode.ChildNodes)
            {
                if (xmlChildNode.Name != xmlCookElement.Name) continue;

                String arrayElementText = xmlChildNode.InnerText;
                float fValue = Convert.ToSingle(arrayElementText);
                if (fValue == 0 && arrayElementText == "-0")
                    fValue = -1.0f * 0.0f;
                floatTValues.Add(fValue);

                if ((float)xmlCookElement.DefaultValue != fValue)
                {
                    floatTAllDefault = false;
                }

                if (floatTValues.Count == totalFloatTCount) break;
            }

            if (floatTAllDefault) return;

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < floatTCount; j++)
                {
                    float fWrite;

                    int index = i * floatTCount + j;
                    if (index < floatTValues.Count)
                    {
                        fWrite = floatTValues[index];
                    }
                    else
                    {
                        fWrite = (float)xmlCookElement.DefaultValue;
                    }

                    FileTools.WriteToBuffer(ref _buffer, ref _offset, fWrite);
                }
            }
        }

        private void _WriteFlag(String elementText, XmlCookElement xmlCookElement, XmlDefinition xmlDefinition, Hashtable bitFieldOffsts)
        {
            // todo: fix up/remove hashtable
            bool flagged = elementText == "0" ? false : true;
            if ((bool)xmlCookElement.DefaultValue == flagged) return;

            int flagIndex = xmlCookElement.FlagId - 1;
            if (xmlCookElement.ElementType == ElementType.BitFlag) flagIndex = 0;

            // has it been written yet
            if (xmlDefinition.BitFields[flagIndex] == -1 || bitFieldOffsts[flagIndex] == null)
            {
                bitFieldOffsts.Add(flagIndex, _offset);
                xmlDefinition.BitFields[flagIndex] = 0;
                _offset += 4; // bit field bytes
            }


            UInt32 flag = (UInt32)xmlDefinition.BitFields[flagIndex];
            if (xmlCookElement.ElementType == ElementType.Flag)
            {
                flag |= xmlCookElement.BitMask;
            }
            else
            {
                flag |= ((UInt32)1 << xmlCookElement.BitIndex);
            }

            int writeOffset = (int)bitFieldOffsts[flagIndex];
            FileTools.WriteToBuffer(ref _buffer, ref writeOffset, flag);
            xmlDefinition.BitFields[flagIndex] = (Int32)flag;
        }

        private void _WriteBitFlag(String elementText, XmlCookElement xmlCookElement, XmlDefinition xmlDefinition)
        {
            bool bitFlagIsFlagged = elementText == "0" ? false : true;
            if ((bool)xmlCookElement.DefaultValue == bitFlagIsFlagged) return;

            if (xmlDefinition.BitFlagsWriteOffset == -1)
            {
                int intCount = xmlDefinition.BitFlags.Length;

                xmlDefinition.BitFlagsWriteOffset = _offset;
                _offset += intCount * sizeof(UInt32);
            }

            int intIndex = xmlCookElement.BitIndex >> 5;
            int bitFlagIndex = xmlCookElement.BitIndex - (intIndex << 5);
            UInt32 bitFlagField = xmlDefinition.BitFlags[intIndex] | ((UInt32)1 << bitFlagIndex);
            xmlDefinition.BitFlags[intIndex] = bitFlagField;

            int bitFlagWriteOffset = xmlDefinition.BitFlagsWriteOffset + (intIndex << 2);
            FileTools.WriteToBuffer(ref _buffer, ref bitFlagWriteOffset, bitFlagField);
        }

        private void _WriteTable(XmlCookElement xmlCookElement, XmlNode xmlNode)
        {
            XmlDefinition xmlTableDefinition = _GetXmlDefinition(xmlCookElement.ChildTypeHash);
            XmlNode xmlTable = xmlNode[xmlTableDefinition.RootElement];

            int tableBytesWritten = _CookXmlData(xmlTableDefinition, xmlTable);
            _offset += tableBytesWritten;
        }

        private int _WriteTableCount(String elementText, XmlCookElement xmlCookElement, XmlNode xmlNode)
        {
            int tableCount = String.IsNullOrEmpty(elementText) ? 0 : Convert.ToInt32(elementText);
            FileTools.WriteToBuffer(ref _buffer, ref _offset, tableCount); // table count is always written
            if (tableCount == 0) return 0;

            XmlDefinition xmlTableCountDefinition = _GetXmlDefinition(xmlCookElement.ChildTypeHash);
            int tablesAdded = 0;
            foreach (XmlNode xmlChildNode in xmlNode.ChildNodes)
            {
                if (xmlChildNode.Name != xmlTableCountDefinition.RootElement) continue;

                int tableCountBytes = _CookXmlData(xmlTableCountDefinition, xmlChildNode);
                _offset += tableCountBytes;
                tablesAdded++;

                if (tableCount == tablesAdded) break;
            }

            if (tablesAdded < tableCount) return -1;
            return tablesAdded;
        }

        private void _WriteExcelIndex(String elementText, XmlCookElement xmlCookElement)
        {
            String excelString = String.Empty;
            byte byteLen = (byte)elementText.Length;
            if (byteLen > 0)
            {
                int index = int.Parse(elementText);
                excelString = _fileManager.GetExcelRowStringFromIndex(xmlCookElement.ExcelTableCode, index);

                if (String.IsNullOrEmpty(excelString))
                {
                    byteLen = 0; // not found
                }
                else
                {
                    byteLen = (byte)excelString.Length;
                }
            }

            if (byteLen == 0)
            {
                byteLen = 0xFF;
                FileTools.WriteToBuffer(ref _buffer, ref _offset, byteLen);
            }
            else
            {
                FileTools.WriteToBuffer(ref _buffer, ref _offset, byteLen);
                byte[] stringBytes = FileTools.StringToASCIIByteArray(excelString);
                FileTools.WriteToBuffer(ref _buffer, ref _offset, stringBytes);
                // no \0
            }
        }

        private void _WriteFloatArray(String elementText, XmlCookElement xmlCookElement, XmlNode xmlNode)
        {
            int arrayCount = xmlCookElement.Count;
            List<float> elements = new List<float>();
            bool allDefault = true;
            foreach (XmlNode xmlChildNode in xmlNode.ChildNodes)
            {
                if (xmlChildNode.Name != xmlCookElement.Name) continue;

                String arrayElementText = xmlChildNode.InnerText;
                float fValue = Convert.ToSingle(arrayElementText);
                if (fValue == 0 && arrayElementText == "-0")
                    fValue = -1.0f * 0.0f;
                elements.Add(fValue);

                if ((float)xmlCookElement.DefaultValue != fValue)
                {
                    allDefault = false;
                }

                if (elements.Count == arrayCount) break;
            }

            if (allDefault) return;

            for (int i = 0; i < arrayCount; i++)
            {
                float fWrite = (float)xmlCookElement.DefaultValue;
                if (i < elements.Count)
                {
                    fWrite = elements[i];
                }

                FileTools.WriteToBuffer(ref _buffer, ref _offset, fWrite);
            }
        }
        #endregion
    }
}
