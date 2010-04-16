﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Reanimator
{
    static public class Export
    {
        static public string CSV(DataGridView datagridview, bool[] selected, string delimiter)
        {
            StringWriter csv = new StringWriter();

            /*
            // column headers
            for (int col = 0; col < datagridview.Rows[0].Cells.Count; col++)
            {
                if (selected[col] == true)
                {
                    csv.Write(datagridview.Columns[col].Name);
                    if (col < datagridview.Rows[0].Cells.Count)
                    {
                        csv.Write("\t");
                    }
               }
            }
            csv.Write(Environment.NewLine);
            */

            // rows
            for (int row = 0; row < datagridview.Rows.Count - 1; row++)
            {
                for (int col = 0; col < datagridview.Rows[row].Cells.Count; col++)
                {
                    if (selected[col] == true)
                    {
                        if (datagridview[col, row].Value != null)
                        {
                            string stringBuffer = datagridview[col, row].Value.ToString();

                            if (stringBuffer.Contains(',') || stringBuffer.Contains('"'))
                            {
                                //stringBuffer = stringBuffer.Replace("\"", "\"\"");
                                //stringBuffer = stringBuffer.Replace(",", "\",\"");
                                stringBuffer = stringBuffer.Insert(0, "\"");
                                stringBuffer = stringBuffer.Insert(stringBuffer.Length, "\"");
                                csv.Write(stringBuffer);
                            }
                            else
                            {
                                csv.Write(datagridview[col, row].Value);
                            }
                        }
                        if (col < datagridview.Rows[row].Cells.Count)
                        {
                            if (delimiter == "Commar")
                            {
                                csv.Write(",");
                            }
                            else if (delimiter == "Tab")
                            {
                                csv.Write("\t");
                            }
                        }
                    }
                }
                csv.Write(Environment.NewLine);
            }

            return csv.ToString();
        }

        static public class Asset
        {
            public static string ToObj(Model model)
            {
                StringWriter sw = new StringWriter();

                sw.WriteLine("# OBJ Export Test");
                sw.WriteLine("o " + model.id);
                sw.WriteLine();

                int indexLength = 0;
                int swapIndex = 0;

                for (int i = 0; i < model.index.Count; i++)
                {
                    sw.WriteLine("g " + i.ToString());
                    foreach (Model.Coordinate coordinate in model.geometry[i].position)
                    {
                        sw.WriteLine("v " + coordinate.ToString());
                    }
                    foreach (Model.UV uv in model.geometry[i].uv)
                    {
                        sw.WriteLine("vt " + uv.ToString());
                    }
                    foreach (Model.Coordinate coordinate in model.geometry[i].normal)
                    {
                        sw.WriteLine("vn " + coordinate.ToString());
                    }
                    // INDEX SWAP
                    if (model.index.Count > 1)
                    {
                        if (i < model.index.Count - 1)
                        {
                            swapIndex = i + 1;
                        }
                        else
                        {
                            swapIndex = 0;
                        }
                    }
                    else
                    {
                        swapIndex = i;
                    }
                    // END INDEXSWAP
                    foreach (Model.Triangle triangle in model.index[swapIndex].triangle)
                    {
                        sw.Write("f ");
                        sw.Write((triangle.coordinate01 + 1 + indexLength).ToString() + "/");
                        sw.Write((triangle.coordinate01 + 1 + indexLength).ToString() + "/");
                        sw.Write((triangle.coordinate01 + 1 + indexLength).ToString() + " ");
                        sw.Write((triangle.coordinate02 + 1 + indexLength).ToString() + "/");
                        sw.Write((triangle.coordinate02 + 1 + indexLength).ToString() + "/");
                        sw.Write((triangle.coordinate02 + 1 + indexLength).ToString() + " ");
                        sw.Write((triangle.coordinate03 + 1 + indexLength).ToString() + "/");
                        sw.Write((triangle.coordinate03 + 1 + indexLength).ToString() + "/");
                        sw.Write((triangle.coordinate03 + 1 + indexLength).ToString());
                        sw.WriteLine();
                    }
                    indexLength += model.index[swapIndex].triangles;
                }
                return sw.ToString();
            }

            //public void Export()
            //{
            //    XmlWriterSettings wSettings = new XmlWriterSettings();
            //    wSettings.Indent = true;
            //    MemoryStream ms = new MemoryStream();
            //    XmlWriter xw = XmlWriter.Create(ms, wSettings);// Write Declaration

            //    //debug
            //    _modelID = "model_name_here";
            //    DateTime now = DateTime.Now;

            //    //
            //    // HEADER
            //    //

            //    xw.WriteStartDocument();
            //    xw.WriteStartElement("COLLADA");
            //    xw.WriteAttributeString("version", "1.4.1");
            //    //xw.WriteAttributeString("xmlns", "http://www.collada.org/2005/11/COLLADASchema");
            //    xw.WriteStartElement("asset");
            //    xw.WriteStartElement("contributor");
            //    xw.WriteStartElement("author");
            //    xw.WriteString("Ripped by Maeyan");
            //    xw.WriteEndElement();
            //    xw.WriteStartElement("authoring_tool");
            //    xw.WriteString("3ds Max 7.0.0");
            //    xw.WriteEndElement();
            //    xw.WriteStartElement("copyright");
            //    xw.WriteString("Flagship Studios");
            //    xw.WriteEndElement();
            //    xw.WriteEndElement();// End Contributor
            //    xw.WriteStartElement("created");
            //    xw.WriteValue(now - new TimeSpan(0, 0, 0));
            //    xw.WriteEndElement();
            //    xw.WriteStartElement("modified");
            //    xw.WriteValue(now - new TimeSpan(0, 0, 0));
            //    xw.WriteEndElement();
            //    xw.WriteStartElement("unit");
            //    xw.WriteAttributeString("meter", "0.01");
            //    xw.WriteAttributeString("name", "centimeter");
            //    xw.WriteEndElement();
            //    xw.WriteStartElement("up_axis");
            //    xw.WriteString("Y_UP");
            //    xw.WriteEndElement();
            //    xw.WriteEndElement();// End asset

            //    //
            //    // MATERIAL
            //    //

            //    xw.WriteStartElement("library_materials");
            //    xw.WriteStartElement("material");
            //    xw.WriteAttributeString("id", "default");
            //    xw.WriteStartElement("instance_effect");
            //    xw.WriteAttributeString("url", "#lambert-fx");
            //    xw.WriteEndElement();
            //    xw.WriteEndElement();
            //    xw.WriteEndElement();

            //    //
            //    // EFFECT
            //    //

            //    xw.WriteStartElement("library_effects");
            //    xw.WriteStartElement("effect");
            //    xw.WriteAttributeString("id", "lambert-fx");
            //    xw.WriteStartElement("profile_COMMON");
            //    xw.WriteStartElement("technique");
            //    xw.WriteAttributeString("sid", "common");
            //    xw.WriteStartElement("lambert");

            //    xw.WriteStartElement("emission");
            //    xw.WriteStartElement("color");
            //    xw.WriteString("0 0 0 1");
            //    xw.WriteEndElement(); // color
            //    xw.WriteEndElement(); // diffuse

            //    xw.WriteStartElement("ambient");
            //    xw.WriteStartElement("color");
            //    xw.WriteString("0 0 0 1");
            //    xw.WriteEndElement(); // color
            //    xw.WriteEndElement(); // diffuse

            //    xw.WriteStartElement("diffuse");
            //    xw.WriteStartElement("color");
            //    xw.WriteString("0.5 0.5 0.5 1");
            //    xw.WriteEndElement(); // color
            //    xw.WriteEndElement(); // diffuse

            //    xw.WriteStartElement("reflective");
            //    xw.WriteStartElement("color");
            //    xw.WriteString("1 1 1 1");
            //    xw.WriteEndElement(); // color
            //    xw.WriteEndElement(); // diffuse

            //    xw.WriteStartElement("reflectivity");
            //    xw.WriteStartElement("float");
            //    xw.WriteString("1");
            //    xw.WriteEndElement(); // color
            //    xw.WriteEndElement(); // diffuse

            //    xw.WriteStartElement("transparent");
            //    xw.WriteStartElement("color");
            //    xw.WriteString("0 0 0 1");
            //    xw.WriteEndElement(); // color
            //    xw.WriteEndElement(); // diffuse

            //    xw.WriteStartElement("transparency");
            //    xw.WriteStartElement("float");
            //    xw.WriteString("1");
            //    xw.WriteEndElement(); // color
            //    xw.WriteEndElement(); // diffuse

            //    xw.WriteStartElement("index_of_refraction");
            //    xw.WriteStartElement("float");
            //    xw.WriteString("0");
            //    xw.WriteEndElement(); // color
            //    xw.WriteEndElement(); // diffuse

            //    xw.WriteEndElement(); // lambert
            //    xw.WriteEndElement(); // Technique
            //    xw.WriteEndElement(); // profile_COMMON
            //    xw.WriteEndElement(); // Effect
            //    xw.WriteEndElement(); // Library Effects

            //    //
            //    // LIBRARY GEOMETRIES
            //    //

            //    xw.WriteStartElement("library_geometries");
            //    xw.WriteAttributeString("id", modelID);
            //    xw.WriteStartElement("geometry");
            //    xw.WriteStartElement("mesh");

            //    //
            //    // POSITIONS
            //    //

            //    Single[] positions = MergePositions();

            //    xw.WriteStartElement("source");
            //    xw.WriteAttributeString("id", modelID + "-positions");
            //    xw.WriteStartElement("float_array");
            //    xw.WriteAttributeString("id", modelID + "-positions-array");
            //    xw.WriteAttributeString("count", positions.Length.ToString());
            //    xw.WriteString(FileTools.ArrayToStringGeneric<Single>(positions, " "));
            //    xw.WriteEndElement();
            //    xw.WriteStartElement("technique_common");
            //    xw.WriteStartElement("accessor");
            //    xw.WriteAttributeString("stride", "3");
            //    xw.WriteAttributeString("source", "#" + modelID + "-positions-array");
            //    xw.WriteAttributeString("count", (positions.Length / 3).ToString());
            //    xw.WriteStartElement("param");
            //    xw.WriteAttributeString("name", "X");
            //    xw.WriteAttributeString("type", "float");
            //    xw.WriteEndElement();
            //    xw.WriteStartElement("param");
            //    xw.WriteAttributeString("name", "Y");
            //    xw.WriteAttributeString("type", "float");
            //    xw.WriteEndElement();
            //    xw.WriteStartElement("param");
            //    xw.WriteAttributeString("name", "Z");
            //    xw.WriteAttributeString("type", "float");
            //    xw.WriteEndElement();
            //    xw.WriteEndElement();// End Accessor
            //    xw.WriteEndElement();// End technique common
            //    xw.WriteEndElement();// End source

            //    //
            //    // UV
            //    //

            //    for (int i = 0; i < _geometry.Count; i++)
            //    {
            //        Single[] uvArray = GetUVArray(i);

            //        //if (index[i].zone == Zone.Render)
            //        {
            //            xw.WriteStartElement("source");
            //            xw.WriteAttributeString("id", modelID + "-uv-" + i.ToString());
            //            xw.WriteStartElement("float_array");
            //            xw.WriteAttributeString("id", modelID + "-uv-array");
            //            xw.WriteAttributeString("count", uvArray.Length.ToString());
            //            xw.WriteString(FileTools.ArrayToStringGeneric<Single>(uvArray, " "));
            //            xw.WriteEndElement();
            //            xw.WriteStartElement("technique_common");
            //            xw.WriteStartElement("accessor");
            //            xw.WriteAttributeString("stride", "2");
            //            xw.WriteAttributeString("source", "#" + modelID + "-uv-array");
            //            xw.WriteAttributeString("count", (uvArray.Length / 2).ToString());
            //            xw.WriteStartElement("param");
            //            xw.WriteAttributeString("name", "S");
            //            xw.WriteAttributeString("type", "float");
            //            xw.WriteEndElement();
            //            xw.WriteStartElement("param");
            //            xw.WriteAttributeString("name", "T");
            //            xw.WriteAttributeString("type", "float");
            //            xw.WriteEndElement();
            //            xw.WriteEndElement();// End Accessor
            //            xw.WriteEndElement();// End technique common
            //            xw.WriteEndElement();// End source
            //        }
            //    }

            //    xw.WriteStartElement("vertices");
            //    xw.WriteAttributeString("id", modelID + "-vertices");
            //    xw.WriteStartElement("input");
            //    xw.WriteAttributeString("semantic", "POSITION");
            //    xw.WriteAttributeString("source", "#" + modelID + "-positions");
            //    xw.WriteEndElement();
            //    xw.WriteEndElement();

            //    //
            //    // INDEX:
            //    //

            //    for (int i = 0; i < _index.Count; i++)
            //    {
            //        UInt16[] triangleArray = GetTriangleArray(i);

            //        xw.WriteStartElement("triangles");
            //        xw.WriteAttributeString("count", (triangleArray.Length / 3).ToString());
            //        xw.WriteAttributeString("material", "initialShadingGroup");
            //        xw.WriteStartElement("input");
            //        xw.WriteAttributeString("offset", "0");
            //        xw.WriteAttributeString("semantic", "VERTEX");
            //        xw.WriteAttributeString("source", "#" + modelID + "-vertices");
            //        xw.WriteEndElement();
            //        xw.WriteStartElement("input");
            //        xw.WriteAttributeString("offset", "0");
            //        xw.WriteAttributeString("semantic", "TEXCOORD");
            //        xw.WriteAttributeString("source", "#" + modelID + "-uv-" + i.ToString());
            //        xw.WriteEndElement();
            //        xw.WriteStartElement("p");
            //        xw.WriteString(FileTools.ArrayToStringGeneric<UInt16>(triangleArray, " "));
            //        xw.WriteEndElement();
            //        xw.WriteEndElement();
            //    }

            //    xw.WriteEndElement();// End mesh
            //    xw.WriteEndElement();// End geometry
            //    xw.WriteEndElement();// End library_geometries

            //    //
            //    // VISUAL SCENE:
            //    //

            //    xw.WriteStartElement("library_visual_scenes");
            //    xw.WriteStartElement("visual_scene");
            //    xw.WriteAttributeString("id", "scene");
            //    xw.WriteStartElement("node");
            //    xw.WriteAttributeString("id", modelID + "-geometry");
            //    xw.WriteStartElement("rotate");
            //    xw.WriteAttributeString("sid", "rotateZ");
            //    xw.WriteString("0 0 1 0");
            //    xw.WriteEndElement();
            //    xw.WriteStartElement("rotate");
            //    xw.WriteAttributeString("sid", "rotateY");
            //    xw.WriteString("0 1 0 0");
            //    xw.WriteEndElement();
            //    xw.WriteStartElement("rotate");
            //    xw.WriteAttributeString("sid", "rotateX");
            //    xw.WriteString("1 0 0 0");
            //    xw.WriteEndElement();
            //    xw.WriteStartElement("instance_geometry");
            //    xw.WriteAttributeString("url", "#" + modelID);
            //    xw.WriteStartElement("bind_material");
            //    xw.WriteStartElement("technique_common");
            //    xw.WriteStartElement("instance_material");
            //    xw.WriteAttributeString("target", "#default");
            //    xw.WriteAttributeString("symbol", "initialShadingGroup");
            //    xw.WriteEndElement(); // instance_material
            //    xw.WriteEndElement(); // technique_common
            //    xw.WriteEndElement(); // bind_material
            //    xw.WriteEndElement(); // instance_geometry
            //    xw.WriteEndElement(); // node
            //    xw.WriteEndElement(); // visual scene
            //    xw.WriteEndElement(); // library visual scenes

            //    xw.WriteStartElement("scene");
            //    xw.WriteStartElement("instance_visual_scene");
            //    xw.WriteAttributeString("url", "#scene");
            //    xw.WriteEndElement();
            //    xw.WriteEndElement();

            //    xw.WriteEndElement();// End COLLADA
            //    xw.WriteEndDocument();
            //    xw.Flush();

            //    FileStream stream = new FileStream(@"D:\\out.dae", FileMode.OpenOrCreate);
            //    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
            //    stream.Close();

            //}
        }
    }
}