﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Hellgate.Excel;
using Revival.Common;

namespace Hellgate
{
    public partial class ExcelFile
    {
        public const String FolderPath = "excel\\";
        public const String FileExtention = ".txt.cooked";
        public static Hashtable DataTypes;
        public static KeyValuePair<String, UInt32>[] DataTables;

        static ExcelFile()
        {
            #region Data Types List
            DataTypes = new Hashtable();
            DataTypes.Add((UInt32)0x01082DBE, typeof(UnitEvents));
            DataTypes.Add((UInt32)0x01A80106, typeof(FactionStanding));
            DataTypes.Add((UInt32)0x01A8DA81, typeof(Treasure));
            DataTypes.Add((UInt32)0x03407879, typeof(AnimationGroups));
            DataTypes.Add((UInt32)0x043A420D, typeof(Quest));
            DataTypes.Add((UInt32)0x08402828, typeof(CharacterClass));
            DataTypes.Add((UInt32)0x0A36EF57, typeof(PlayerRace));

            DataTypes.Add((UInt32)0x102ECE59, typeof(AiStart));
            DataTypes.Add((UInt32)0x106C109C, typeof(AffixTypes));
            DataTypes.Add((UInt32)0x11302F85, typeof(Offer));
            DataTypes.Add((UInt32)0x1481FC18, typeof(Movies));
            DataTypes.Add((UInt32)0x1A0A1C09, typeof(QuestState));
            DataTypes.Add((UInt32)0x1A4CAF8A, typeof(Sounds));
            DataTypes.Add((UInt32)0x1ACBB8F7, typeof(SubLevel));
            DataTypes.Add((UInt32)0x1B82B5B5, typeof(MusicStingerSets));
            DataTypes.Add((UInt32)0x1CF9BDE9, typeof(LevelsDrlgs));
            DataTypes.Add((UInt32)0x1E760FB1, typeof(SoundBuses));
            DataTypes.Add((UInt32)0x1EE32EF6, typeof(Bones));
            DataTypes.Add((UInt32)0x1F0513C5, typeof(WardrobeModelGroupRow));
            DataTypes.Add((UInt32)0x1F9DDC98, typeof(UnitTypes));

            DataTypes.Add((UInt32)0x22FCCFEB, typeof(StringFiles));
            DataTypes.Add((UInt32)0x26BC8A8D, typeof(DamageEffects));
            DataTypes.Add((UInt32)0x2C085508, typeof(StatsFunc));
            DataTypes.Add((UInt32)0x2D83EDCC, typeof(ItemQuality));
            DataTypes.Add((UInt32)0x2F942E56, typeof(MusicRef));

            DataTypes.Add((UInt32)0x3230B6BC, typeof(Recipes));
            DataTypes.Add((UInt32)0x3723584E, typeof(ObjectTriggers));

            DataTypes.Add((UInt32)0x40382E46, typeof(MaterialsGlobal));
            DataTypes.Add((UInt32)0x4319D23D, typeof(Display));
            DataTypes.Add((UInt32)0x4506F984, typeof(FootSteps));
            DataTypes.Add((UInt32)0x45B08A9E, typeof(AnimationStance));
            DataTypes.Add((UInt32)0x472CEC2D, typeof(FontColor));
            DataTypes.Add((UInt32)0x498E341C, typeof(UnitModes));
            DataTypes.Add((UInt32)0x4C5392D7, typeof(Font));
            DataTypes.Add((UInt32)0x4CC2F23D, typeof(LevelsEnv));
            DataTypes.Add((UInt32)0x4D232409, typeof(Global));
            DataTypes.Add((UInt32)0x4FC6AEA2, typeof(ItemLooks));

            DataTypes.Add((UInt32)0x50F90D15, typeof(SoundVideoCasets));
            DataTypes.Add((UInt32)0x51C1C606, typeof(Levels));
            DataTypes.Add((UInt32)0x569C0513, typeof(Stats));
            DataTypes.Add((UInt32)0x57D269AF, typeof(GlobalThemes));
            DataTypes.Add((UInt32)0x5876D156, typeof(Properties));
            DataTypes.Add((UInt32)0x58D35B7C, typeof(WardrobePart));
            DataTypes.Add((UInt32)0x5BCCB897, typeof(MonsterQuality));

            DataTypes.Add((UInt32)0x6078CD93, typeof(InteractMenu));
            DataTypes.Add((UInt32)0x60CA8F60, typeof(MaterialsCollision));
            DataTypes.Add((UInt32)0x62ECA6E1, typeof(Achievements));
            DataTypes.Add((UInt32)0x63F90CA5, typeof(BackGroundSounds3D));
            DataTypes.Add((UInt32)0x64429E37, typeof(MonLevel));
            DataTypes.Add((UInt32)0x6635D021, typeof(MonScaling));
            DataTypes.Add((UInt32)0x686002E7, typeof(WardrobeBody));
            DataTypes.Add((UInt32)0x6CA52FE7, typeof(MeleeWeapons));

            DataTypes.Add((UInt32)0x71D76819, typeof(UIComponent));
            DataTypes.Add((UInt32)0x72477C36, typeof(StateEventTypes));
            DataTypes.Add((UInt32)0x7765138E, typeof(QuestCast));
            DataTypes.Add((UInt32)0x7A7D891E, typeof(BudgetsModel));
            DataTypes.Add((UInt32)0x7DF5E322, typeof(MusicGrooveLevels));
            DataTypes.Add((UInt32)0x7F15F865, typeof(AiInit));

            DataTypes.Add((UInt32)0x80DE708E, typeof(MonsterNames));
            DataTypes.Add((UInt32)0x86DC367C, typeof(BookMarks));
            DataTypes.Add((UInt32)0x887988C4, typeof(Items));
            DataTypes.Add((UInt32)0x8A5FF6B8, typeof(AiBehaviour));
            DataTypes.Add((UInt32)0x8B84B802, typeof(ConditionFunctions));
            DataTypes.Add((UInt32)0x8E1FFDA1, typeof(WardrobeBlendOp));
            DataTypes.Add((UInt32)0x8EF00B17, typeof(LevelsRoomIndex));
            DataTypes.Add((UInt32)0x8FEEC9AC, typeof(Inventory));

            DataTypes.Add((UInt32)0x904D8906, typeof(GameGlobals));
            DataTypes.Add((UInt32)0x95909737, typeof(UnitModeGroups));
            DataTypes.Add((UInt32)0x9923217F, typeof(InvLoc));
            DataTypes.Add((UInt32)0x99264BCB, typeof(EffectsIndex));
            DataTypes.Add((UInt32)0x9DF76E6C, typeof(Affixes));
            DataTypes.Add((UInt32)0x9FF616C5, typeof(Weather));

            DataTypes.Add((UInt32)0xA30E10D3, typeof(MusicScriptDebug));
            DataTypes.Add((UInt32)0xA42BCE8C, typeof(SoundVidCas));
            DataTypes.Add((UInt32)0xA5887717, typeof(PlayerLevels));
            DataTypes.Add((UInt32)0xA6D29E2E, typeof(WardrobeModel));
            DataTypes.Add((UInt32)0xA84F422C, typeof(SoundMixStateValues));
            DataTypes.Add((UInt32)0xAA0F158C, typeof(BadgeRewards));
            DataTypes.Add((UInt32)0xACB1C3DD, typeof(LevelScaling));
            DataTypes.Add((UInt32)0xAF168F4E, typeof(Dialog));
            DataTypes.Add((UInt32)0xAFBF5906, typeof(AiCommonState));

            DataTypes.Add((UInt32)0xB0593288, typeof(QuestStatus));
            DataTypes.Add((UInt32)0xB0DA4BE1, typeof(BackGroundSounds2D));
            DataTypes.Add((UInt32)0xB1B5294C, typeof(StateLighting));
            DataTypes.Add((UInt32)0xB28448F5, typeof(LevelsFilePath));
            DataTypes.Add((UInt32)0xB47A4EC5, typeof(SkillEventTypes));
            DataTypes.Add((UInt32)0xB7A70C96, typeof(LevelsRules));
            DataTypes.Add((UInt32)0xB7BB74D1, typeof(Faction));
            DataTypes.Add((UInt32)0xBAF5E904, typeof(Skills));
            DataTypes.Add((UInt32)0xBB554372, typeof(Act));
            DataTypes.Add((UInt32)0xBBC15A50, typeof(ColorSets));
            DataTypes.Add((UInt32)0xBBEBD669, typeof(SpawnClass));
            DataTypes.Add((UInt32)0xBCDCE6DE, typeof(LevelsDrlgChoice));
            DataTypes.Add((UInt32)0xBEE975EA, typeof(BudgetTextureMips));
            DataTypes.Add((UInt32)0xBF3BFFF5, typeof(Tasks));

            DataTypes.Add((UInt32)0xC625A079, typeof(Wardrobe));
            DataTypes.Add((UInt32)0xC67C9F70, typeof(MovieLists));
            DataTypes.Add((UInt32)0xC8071451, typeof(TextureTypes));
            DataTypes.Add((UInt32)0xC8471612, typeof(EffectsShaders));
            DataTypes.Add((UInt32)0xCC2486A8, typeof(MusicGrooveLevelTypes));
            DataTypes.Add((UInt32)0xCCE72560, typeof(Music));
            DataTypes.Add((UInt32)0xCD2DFD19, typeof(MovieSubTitles));
            DataTypes.Add((UInt32)0xCE724D43, typeof(ItemLevels));
            DataTypes.Add((UInt32)0xCF23C241, typeof(Sku));

            DataTypes.Add((UInt32)0xD1136038, typeof(LevelsThemes));
            DataTypes.Add((UInt32)0xD2FE445A, typeof(SkillGroups));
            DataTypes.Add((UInt32)0xD3FC2A56, typeof(Filter));
            DataTypes.Add((UInt32)0xD406BEF5, typeof(WardrobeTextureSet));
            DataTypes.Add((UInt32)0xD4AE7FA7, typeof(QuestTemplate));
            DataTypes.Add((UInt32)0xD4CB8A6A, typeof(Npc));
            DataTypes.Add((UInt32)0xD5910000, typeof(MusicConditions));
            DataTypes.Add((UInt32)0xD59E46B8, typeof(AnimationCondition));
            DataTypes.Add((UInt32)0xDB77DD54, typeof(SoundMixStates));
            DataTypes.Add((UInt32)0xDC35E3D0, typeof(ChatInstancedChannels));
            DataTypes.Add((UInt32)0xDDBAD110, typeof(Procs));
            DataTypes.Add((UInt32)0xDF1BE0CD, typeof(InitDb));

            DataTypes.Add((UInt32)0xE1A7A39A, typeof(RecipeLists));
            DataTypes.Add((UInt32)0xE70A388C, typeof(WeatherSets));
            DataTypes.Add((UInt32)0xEAC1CAA4, typeof(DamageTypes));
            DataTypes.Add((UInt32)0xEBE7DF6B, typeof(ItemLookGroups));

            DataTypes.Add((UInt32)0xF09E4089, typeof(RareNames));
            DataTypes.Add((UInt32)0xF303187F, typeof(EffectsFiles));
            DataTypes.Add((UInt32)0xF5E3E982, typeof(MusicStingers));
            DataTypes.Add((UInt32)0xF8A155D8, typeof(Tag));
            DataTypes.Add((UInt32)0xF934EB3B, typeof(SkillTabs));
            DataTypes.Add((UInt32)0xF98A5E41, typeof(LoadingTips));
            DataTypes.Add((UInt32)0xFA7B3939, typeof(WardrobeAppearanceGroup));
            DataTypes.Add((UInt32)0xFC8E3B0C, typeof(Interact));
            DataTypes.Add((UInt32)0xFD6839DE, typeof(States));
            DataTypes.Add((UInt32)0xFE47EF60, typeof(Palettes));

            DataTables = new KeyValuePair<String, UInt32>[]
            {
                new KeyValuePair<String, UInt32>("ACHIEVEMENTS", 0x62ECA6E1),
                new KeyValuePair<String, UInt32>("ACT", 0xBB554372),
                new KeyValuePair<String, UInt32>("AFFIXES", 0x9DF76E6C),
                new KeyValuePair<String, UInt32>("AFFIXTYPES", 0x106C109C),
                new KeyValuePair<String, UInt32>("AI_BEHAVIOR", 0x8A5FF6B8),
                new KeyValuePair<String, UInt32>("AI_INIT", 0x7F15F865),
                new KeyValuePair<String, UInt32>("AI_START", 0x102ECE59),
                new KeyValuePair<String, UInt32>("AICOMMON_STATE", 0xAFBF5906),
                new KeyValuePair<String, UInt32>("ANIMATION_CONDITION", 0xD59E46B8),
                new KeyValuePair<String, UInt32>("ANIMATION_GROUP", 0x03407879),
                new KeyValuePair<String, UInt32>("ANIMATION_STANCE", 0x45B08A9E),

                new KeyValuePair<String, UInt32>("BACKGROUNDSOUNDS", 0xD783DCDA),
                new KeyValuePair<String, UInt32>("BACKGROUNDSOUNDS2D", 0xB0DA4BE1),
                new KeyValuePair<String, UInt32>("BACKGROUNDSOUNDS3D", 0x63F90CA5),
                new KeyValuePair<String, UInt32>("BADGE_REWARDS", 0xAA0F158C),
                new KeyValuePair<String, UInt32>("BONES", 0x1EE32EF6),
                new KeyValuePair<String, UInt32>("BONEWEIGHTS", 0x1EE32EF6),
                new KeyValuePair<String, UInt32>("BOOKMARKS", 0x86DC367C),
                new KeyValuePair<String, UInt32>("BUDGETS_MODEL", 0x7A7D891E),
                new KeyValuePair<String, UInt32>("BUDGETS_TEXTURE_MIPS", 0xBEE975EA),

                new KeyValuePair<String, UInt32>("CHARACTER_CLASS", 0x08402828),
                new KeyValuePair<String, UInt32>("CHAT_INSTANCED_CHANNELS", 0xDC35E3D0),
                new KeyValuePair<String, UInt32>("CHATFILTER", 0xD3FC2A56),
                new KeyValuePair<String, UInt32>("COLORSETS", 0xBBC15A50),
                new KeyValuePair<String, UInt32>("CONDITION_FUNCTIONS", 0x8B84B802),

                new KeyValuePair<String, UInt32>("DAMAGEEFFECTS", 0x26BC8A8D),
                new KeyValuePair<String, UInt32>("DAMAGETYPES", 0xEAC1CAA4),
                new KeyValuePair<String, UInt32>("DIALOG", 0xAF168F4E),
                new KeyValuePair<String, UInt32>("DIFFICULTY", 0x5C719A50),
                new KeyValuePair<String, UInt32>("DISPLAY_CHAR", 0x4319D23D),
                new KeyValuePair<String, UInt32>("DISPLAY_ITEM", 0x4319D23D),

                new KeyValuePair<String, UInt32>("EXCELTABLES", 0x86DC367C),
                new KeyValuePair<String, UInt32>("EFFECT_FILES", 0xF303187F),
                new KeyValuePair<String, UInt32>("EFFECTS_INDEX", 0x99264BCB),
                new KeyValuePair<String, UInt32>("EFFECTS_SHADERS", 0xC8471612),

                new KeyValuePair<String, UInt32>("FACTION", 0xB7BB74D1),
                new KeyValuePair<String, UInt32>("FACTION_STANDING", 0x01A80106),
                new KeyValuePair<String, UInt32>("FONT", 0x4C5392D7),
                new KeyValuePair<String, UInt32>("FONTCOLOR", 0x472CEC2D),
                new KeyValuePair<String, UInt32>("FOOTSTEPS", 0x4506F984),

                new KeyValuePair<String, UInt32>("GAMEGLOBALS", 0x904D8906),
                new KeyValuePair<String, UInt32>("GLOBAL_THEMES", 0x57D269AF),
                new KeyValuePair<String, UInt32>("GLOBALINDEX", 0x4D232409),
                new KeyValuePair<String, UInt32>("GLOBALSTRING", 0x4D232409),
                new KeyValuePair<String, UInt32>("GOSSIP", 0x4F1EFCCD),

                new KeyValuePair<String, UInt32>("INITDB", 0xDF1BE0CD),
                new KeyValuePair<String, UInt32>("INTERACT", 0xFC8E3B0C),
                new KeyValuePair<String, UInt32>("INTERACT_MENU", 0x6078CD93),
                new KeyValuePair<String, UInt32>("INVENTORY", 0x8FEEC9AC),
                new KeyValuePair<String, UInt32>("INVENTORY_TYPES", 0x102ECE59),
                new KeyValuePair<String, UInt32>("INVLOC", 0x9923217F),
                new KeyValuePair<String, UInt32>("ITEM_LEVELS", 0xCE724D43),
                new KeyValuePair<String, UInt32>("ITEM_LOOK_GROUPS", 0xEBE7DF6B),
                new KeyValuePair<String, UInt32>("ITEM_LOOKS", 0x4FC6AEA2),
                new KeyValuePair<String, UInt32>("ITEMQUALITY", 0x2D83EDCC),
                new KeyValuePair<String, UInt32>("ITEMS", 0x887988C4),

                new KeyValuePair<String, UInt32>("LEVELS", 0x51C1C606),
                new KeyValuePair<String, UInt32>("LEVELS_DRLG_CHOICE", 0xBCDCE6DE),
                new KeyValuePair<String, UInt32>("LEVELS_DRLGS", 0x1CF9BDE9),
                new KeyValuePair<String, UInt32>("LEVELS_ENV", 0x4CC2F23D),
                new KeyValuePair<String, UInt32>("LEVELS_FILE_PATH", 0xB28448F5),
                new KeyValuePair<String, UInt32>("LEVELS_ROOM_INDEX", 0x8EF00B17),
                new KeyValuePair<String, UInt32>("LEVELS_RULES", 0xB7A70C96),
                new KeyValuePair<String, UInt32>("LEVELS_THEMES", 0xD1136038),
                new KeyValuePair<String, UInt32>("LEVELSCALING", 0xACB1C3DD),
                new KeyValuePair<String, UInt32>("LOADING_TIPS", 0xF98A5E41),

                new KeyValuePair<String, UInt32>("MATERIALS_COLLISION", 0x60CA8F60),
                new KeyValuePair<String, UInt32>("MATERIALS_GLOBAL", 0x40382E46),
                new KeyValuePair<String, UInt32>("MELEEWEAPONS", 0x6CA52FE7),
                new KeyValuePair<String, UInt32>("MISSILES", 0x887988C4),
                new KeyValuePair<String, UInt32>("MONLEVEL", 0x64429E37),
                new KeyValuePair<String, UInt32>("MONSCALING", 0x6635D021),
                new KeyValuePair<String, UInt32>("MONSTER_NAME_TYPES", 0x86DC367C),
                new KeyValuePair<String, UInt32>("MONSTER_NAMES", 0x80DE708E),
                new KeyValuePair<String, UInt32>("MONSTER_QUALITY", 0x5BCCB897),
                new KeyValuePair<String, UInt32>("MONSTERS", 0x887988C4),
                new KeyValuePair<String, UInt32>("MOVIE_SUBTITLES", 0xCD2DFD19),
                new KeyValuePair<String, UInt32>("MOVIELISTS", 0xC67C9F70),
                new KeyValuePair<String, UInt32>("MOVIES", 0x1481FC18),
                new KeyValuePair<String, UInt32>("MUSIC", 0xCCE72560),
                new KeyValuePair<String, UInt32>("MUSICCONDITIONS", 0xD5910000),
                new KeyValuePair<String, UInt32>("MUSICGROOVELEVELS", 0x7DF5E322),
                new KeyValuePair<String, UInt32>("MUSICGROOVELEVELTYPES", 0xCC2486A8),
                new KeyValuePair<String, UInt32>("MUSICREF", 0x2F942E56),
                new KeyValuePair<String, UInt32>("MUSICSCRIPTDEBUG", 0xA30E10D3),
                new KeyValuePair<String, UInt32>("MUSICSTINGERS", 0xF5E3E982),
                new KeyValuePair<String, UInt32>("MUSICSTINGERSETS", 0x1B82B5B5),

                new KeyValuePair<String, UInt32>("NAMEFILTER", 0xD3FC2A56),
                new KeyValuePair<String, UInt32>("NPC", 0xD4CB8A6A),

                new KeyValuePair<String, UInt32>("OBJECTS", 0x887988C4),
                new KeyValuePair<String, UInt32>("OBJECTTRIGGERS", 0x3723584E),
                new KeyValuePair<String, UInt32>("OFFER", 0x11302F85),

                new KeyValuePair<String, UInt32>("PALETTES", 0xFE47EF60),
                new KeyValuePair<String, UInt32>("PETLEVEL", 0x64429E37),
                new KeyValuePair<String, UInt32>("PLAYERSLEVELS", 0xA5887717),
                new KeyValuePair<String, UInt32>("PLAYERRACE", 0x0A36EF57),
                new KeyValuePair<String, UInt32>("PLAYERS", 0x887988C4),
                new KeyValuePair<String, UInt32>("PROCS", 0xDDBAD110),
                new KeyValuePair<String, UInt32>("PROPERTIES", 0x5876D156),
                new KeyValuePair<String, UInt32>("PROPS", 0x8EF00B17),

                new KeyValuePair<String, UInt32>("QUEST", 0x043A420D),
                new KeyValuePair<String, UInt32>("QUEST_CAST", 0x7765138E),
                new KeyValuePair<String, UInt32>("QUEST_STATE", 0x1A0A1C09),
                new KeyValuePair<String, UInt32>("QUEST_STATE_VALUE", 0x86DC367C),
                new KeyValuePair<String, UInt32>("QUEST_STATUS", 0xB0593288),
                new KeyValuePair<String, UInt32>("QUEST_TEMPALTE", 0xD4AE7FA7),

                new KeyValuePair<String, UInt32>("RARENAMES", 0xF09E4089),
                new KeyValuePair<String, UInt32>("RECIPELISTS", 0xE1A7A39A),
                new KeyValuePair<String, UInt32>("RECIPES", 0x3230B6BC),

                new KeyValuePair<String, UInt32>("SKILLEVENTTYPES", 0xB47A4EC5),
                new KeyValuePair<String, UInt32>("SKILLGROUPS", 0xD2FE445A),
                new KeyValuePair<String, UInt32>("SKILLS", 0xBAF5E904),
                new KeyValuePair<String, UInt32>("SKILLTABS", 0xF934EB3B),
                new KeyValuePair<String, UInt32>("SKU", 0xCF23C241),
                new KeyValuePair<String, UInt32>("SOUNDSBUSES", 0x1E760FB1),
                new KeyValuePair<String, UInt32>("SOUNDMIXSTATES", 0xDB77DD54),
                new KeyValuePair<String, UInt32>("SOUNDMIXSTATEVALUES", 0xA84F422C),
                new KeyValuePair<String, UInt32>("SOUNDOVERRIDES", 0x83228488),
                new KeyValuePair<String, UInt32>("SOUNDS", 0x1A4CAF8A),
                new KeyValuePair<String, UInt32>("SOUNDVCAS", 0xA42BCE8C),
                new KeyValuePair<String, UInt32>("SOUNDVCASETS", 0x50F90D15),
                new KeyValuePair<String, UInt32>("SPAWNCLASS", 0xBBEBD669),
                new KeyValuePair<String, UInt32>("STATES", 0xFD6839DE),
                new KeyValuePair<String, UInt32>("STATE_EVENT_TYPES", 0x72477C36),
                new KeyValuePair<String, UInt32>("STATE_LIGHTING", 0xB1B5294C),
                new KeyValuePair<String, UInt32>("STATS", 0x569C0513),
                new KeyValuePair<String, UInt32>("STATSFUNC", 0x2C085508),
                new KeyValuePair<String, UInt32>("STATSSELECTOR", 0x86DC367C),
                new KeyValuePair<String, UInt32>("STRING_FILES", 0x22FCCFEB),
                new KeyValuePair<String, UInt32>("SUBLEVEL", 0x1ACBB8F7),

                new KeyValuePair<String, UInt32>("TAG", 0xF8A155D8),
                new KeyValuePair<String, UInt32>("TASKS", 0xBF3BFFF5),
                new KeyValuePair<String, UInt32>("TASK_STATUS", 0x86DC367C),
                new KeyValuePair<String, UInt32>("TEXTURETYPES", 0xC8071451),
                new KeyValuePair<String, UInt32>("TREASURE", 0x01A8DA81),

                new KeyValuePair<String, UInt32>("UI_COMPONENT", 0x71D76819),
                new KeyValuePair<String, UInt32>("UNITEVENTS", 0x01082DBE),
                new KeyValuePair<String, UInt32>("UNITMODE_GROUPS", 0x95909737),
                new KeyValuePair<String, UInt32>("UNITMODES", 0x498E341C),
                new KeyValuePair<String, UInt32>("UNITTYPES", 0x1F9DDC98),

                new KeyValuePair<String, UInt32>("WARDROBE", 0xC625A079),
                new KeyValuePair<String, UInt32>("WARDROBE_APPEARANCE_GROUP", 0xFA7B3939),
                new KeyValuePair<String, UInt32>("WARDROBE_BLENDOP", 0x8E1FFDA1),
                new KeyValuePair<String, UInt32>("WARDROBE_BODY", 0x686002E7),
                new KeyValuePair<String, UInt32>("WARDROBE_LAYERSET", 0x8E1FFDA1),
                new KeyValuePair<String, UInt32>("WARDROBE_MODEL", 0xA6D29E2E),
                new KeyValuePair<String, UInt32>("WARDROBE_MODEL_GROUP", 0x1F0513C5),
                new KeyValuePair<String, UInt32>("WARDROBE_PART", 0x58D35B7C),
                new KeyValuePair<String, UInt32>("WARDROBE_TEXTURESET", 0xD406BEF5),
                new KeyValuePair<String, UInt32>("WARDROBE_TEXTURESET_GROUP", 0x1F0513C5),
                new KeyValuePair<String, UInt32>("WEATHER", 0x9FF616C5),
                new KeyValuePair<String, UInt32>("WEATHER_SETS", 0xE70A388C)
            };
            #endregion
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ExcelHeader
        {
            public UInt32 StructureID;
            public Int32 Unknown321;
            public Int32 Unknown322;
            public Int16 Unknown161;
            public Int16 Unknown162;
            public Int16 Unknown163;
            public Int16 Unknown164;
            public Int16 Unknown165;
            public Int16 Unknown166;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TableHeader
        {
            public Int32 Unknown1;
            public Int32 Unknown2;
            public Int16 VersionMajor;
            public Int16 Reserved1;
            public Int16 VersionMinor;
            public Int16 Reserved2;
        }

        [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
        public class OutputAttribute : Attribute
        {
            public bool IsBitmask { get; set; }
            public UInt32 DefaultBitmask { get; set; }
            public bool IsBool { get; set; }
            public bool IsStringOffset { get; set; }
            public bool IsStringIndex { get; set; }
            public bool IsIntOffset { get; set; }
            public bool IsStringID { get; set; }
            public bool IsTableIndex { get; set; }
            public String TableStringID { get; set; }
            public int SortAscendingID { get; set; }
            public int SortDistinctID { get; set; }
            public int SortPostOrderID { get; set; }
            public bool RequiresDefault { get; set; }
            public String SortColumnTwo { get; set; }
            public bool ExcludeZero { get; set; }
        }

        private abstract class Token
        {
            public const Int32 cxeh = 0x68657863;
            public const Int32 rcsh = 0x68736372;
            public const Int32 tysh = 0x68737974;
            public const Int32 mysh = 0x6873796D;
            public const Int32 dneh = 0x68656E64;
        }

        public abstract class ColumnTypeKeys
        {
            public const String IsFinalData = "IsFinalData";
            public const String IsIndiceData = "IsIndiceData";
            public const String IsStringOffset = "IsStringOffset";
            public const String IsStringIndex = "IsStringIndex";
            public const String IsStringId = "IsStringID";
            public const String IsRelationGenerated = "IsRelationGenerated";
            public const String IsTableIndex = "IsTableIndex";
            public const String IsBitmask = "IsBitmask";
            public const String IsBool = "IsBool";
            public const String IsIntOffset = "IsIntOffset";
            public const String RequiresDefault = "RequiresDefault";
            public const String SortAscendingID = "SortAscendingID";
            public const String SortColumnTwo = "SortColumnTwo";
            public const String SortDistinctID = "SortDistinctID";
            public const String SortPostOrderID = "SortPostOrderID";
            public const String ExcludeZero = "ExcludeZero";
        }
    }
}