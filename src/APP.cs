﻿using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SideLoader;
using System.Collections.Generic;
using System.Linq;

namespace APP
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        // Choose a GUID for your project. Change "myname" and "mymod".
        public const string GUID = "APP";
        // Choose a NAME for your project, generally the same as your Assembly Name.
        public const string NAME = "Advanced Picks & 'Poons";
        // Increment the VERSION when you release a new version of your mod.
        public const string VERSION = "0.9.6";

        // For accessing your BepInEx Logger from outside of this class (eg Plugin.Log.LogMessage("");)
        public static ManualLogSource Log;

        //! If you need settings, define them like so:
        //! public static ConfigEntry<bool> ExampleConfig;

        // Default IDs
        public const int DEFPICK_ID = 2120050;
        public const int DEFPOON_ID = 2130130;
        public const int DEFSICK_ID = 2000060;

        // Unique Item IDs
        public const int APICK_ID = -31000;
        public const int APOON_ID = -31001;
        public const int EPICK_ID = -31002;
        public const int EPOON_ID = -31003;
        public const int MPICK_ID = -31004;
        public const int MPOON_ID = -31005;
        public const int ASICK_ID = -31006;
        public const int ESICK_ID = -31007;
        public const int MSICK_ID = -31008;

        // Durability for the tools
        public const int APICK_DURABILITY = 350;
        public const int APOON_DURABILITY = 250;
        public const int EPICK_DURABILITY = 400;
        public const int EPOON_DURABILITY = 300;

        // Silver value of the tools
        public const int APICK_VALUE = 40;
        public const int APOON_VALUE = 40;
        public const int EPICK_VALUE = 75;
        public const int EPOON_VALUE = 75;
        public const int ASICK_VALUE = 40;
        public const int ESICK_VALUE = 75;

        internal void Awake()
        {
            Log = this.Logger;
            Log.LogMessage($"{NAME} {VERSION} successfully loaded!");

            //! Any config settings you define should be set up like this:
            //! ExampleConfig = Config.Bind("ExampleCategory", "ExampleSetting", false, "This is an example setting.");

            SL.OnPacksLoaded += SL_OnPacksLoaded;

            Harmony.CreateAndPatchAll(typeof(Harmonize));
        }

        // Wait for packages to load to initialize items
        private void SL_OnPacksLoaded()
        {
            SetUpPicks();
            SetUpPoons();
            SetUpSickles();
            AddToolsToDictionary();
            Recipes.CreateRecipes();
            Recipes.CreateRecipeScrolls();
            Recipes.AddRecipesToMerchants();
        }

        private void AddToolsToDictionary()
        {
            ItemUtilities.instance.m_gatherableToolEquivalences[DEFPICK_ID] = ItemUtilities.instance.m_gatherableToolEquivalences[DEFPICK_ID].Append(APICK_ID).ToArray();
            ItemUtilities.instance.m_gatherableToolEquivalences[DEFPICK_ID] = ItemUtilities.instance.m_gatherableToolEquivalences[DEFPICK_ID].Append(EPICK_ID).ToArray();
            ItemUtilities.instance.m_gatherableToolEquivalences[DEFPOON_ID] = ItemUtilities.instance.m_gatherableToolEquivalences[DEFPOON_ID].Append(APOON_ID).ToArray();
            ItemUtilities.instance.m_gatherableToolEquivalences[DEFPOON_ID] = ItemUtilities.instance.m_gatherableToolEquivalences[DEFPOON_ID].Append(EPOON_ID).ToArray();

        }
       
        private void SetUpSickles()
        {
            //TODO Think on durability. -ROTATE MODEL
            SL_Weapon advSickle = new SL_Weapon()
            {
                Target_ItemID = DEFSICK_ID,
                New_ItemID = ASICK_ID,
                Name = "Advanced Sickle",
                Description = "A quality sickle used to gather items more efficiently.",
                StatsHolder = new SL_WeaponStats()
                {
                    BaseDamage = new List<SL_Damage>()
                    {
                        new SL_Damage()
                        {
                            Damage = 17f,
                            Type = DamageType.Types.Physical
                        },
                    },
                    MaxDurability = APICK_DURABILITY,
                    BaseValue = APICK_VALUE,
                },
               
                ItemVisuals = new SL_ItemVisual()
                {
                    Prefab_SLPack = "APP",
                    Prefab_AssetBundle = "sickle-a",
                    Prefab_Name = "sickle-a"
                },
                
                SpecialItemVisuals = new SL_ItemVisual()
                {
                    Prefab_SLPack = "APP",
                    Prefab_AssetBundle = "ssickle-a",
                    Prefab_Name = "ssickle-a"
                },
                
            };
            advSickle.SLPackName = "APP";
            advSickle.SubfolderName = "AdvancedSickle";
            advSickle.ApplyTemplate();

            SL_Weapon expSickle = new SL_Weapon()
            {
                Target_ItemID = DEFSICK_ID,
                New_ItemID = ESICK_ID,
                Name = "Expert Sickle",
                Description = "A quality sickle used to gather items more efficiently.",
                StatsHolder = new SL_WeaponStats()
                {
                    BaseDamage = new List<SL_Damage>()
                    {
                        new SL_Damage()
                        {
                            Damage = 20f,
                            Type = DamageType.Types.Physical
                        },
                    },
                    MaxDurability = EPICK_DURABILITY,
                    BaseValue = EPICK_VALUE,
                },
                
                ItemVisuals = new SL_ItemVisual()
                {
                    Prefab_SLPack = "APP",
                    Prefab_AssetBundle = "sickle-a",
                    Prefab_Name = "sickle-a"
                },

                
                SpecialItemVisuals = new SL_ItemVisual()
                {
                    Prefab_SLPack = "APP",
                    Prefab_AssetBundle = "ssickle-a",
                    Prefab_Name = "ssickle-a"
                },
                
            };
            expSickle.SLPackName = "APP";
            expSickle.SubfolderName = "ExpertSickle";
            expSickle.ApplyTemplate();
        }

        private void SetUpPicks()
        {
            SL_MeleeWeapon advMiningPick = new SL_MeleeWeapon()
            {
                Target_ItemID = DEFPICK_ID,
                New_ItemID = APICK_ID,
                Name = "Advanced Mining Pick",
                Description = "A mining pick of greater quality that is capable of mining more efficiently.",
                StatsHolder = new SL_WeaponStats()
                {
                    BaseDamage = new List<SL_Damage>()
                    {
                        new SL_Damage()
                        {
                            Damage = 20f,
                            Type = DamageType.Types.Physical
                        },
                    },
                    MaxDurability = APICK_DURABILITY,
                    BaseValue = APICK_VALUE,
                },
            };
            advMiningPick.SLPackName = "APP";
            advMiningPick.SubfolderName = "AdvancedPick";
            advMiningPick.ApplyTemplate();

            SL_MeleeWeapon expMiningPick = new SL_MeleeWeapon()
            {
                Target_ItemID = DEFPICK_ID,
                New_ItemID = EPICK_ID,
                Name = "Expert Mining Pick",
                Description = "A mining pick of exceptional quality that is capable of mining a great deal more efficiently.",
                StatsHolder = new SL_WeaponStats()
                {
                    BaseDamage = new List<SL_Damage>()
                    {
                        new SL_Damage()
                        {
                            Damage = 26f,
                            Type = DamageType.Types.Physical
                        },
                    },
                    MaxDurability = EPICK_DURABILITY,
                    BaseValue = EPICK_VALUE,
                },
            };
            expMiningPick.SLPackName = "APP";
            expMiningPick.SubfolderName = "ExpertPick";
            expMiningPick.ApplyTemplate();
        }

        private void SetUpPoons()
        {
            SL_MeleeWeapon advPoon = new SL_MeleeWeapon()
            {
                Target_ItemID = DEFPOON_ID,
                New_ItemID = APOON_ID,
                Name = "Advanced Fishing Harpoon",
                Description = "A harpoon of greater quality that is capable of fishing more effectively.",
                StatsHolder = new SL_WeaponStats()
                {
                    BaseDamage = new List<SL_Damage>()
                    {
                        new SL_Damage()
                        {
                            Damage = 20f,
                            Type = DamageType.Types.Physical
                        },
                    },
                    MaxDurability = APOON_DURABILITY,
                    BaseValue = APOON_VALUE,
                },
            };
            advPoon.SLPackName = "APP";
            advPoon.SubfolderName = "AdvancedPoon";
            advPoon.ApplyTemplate();

            SL_MeleeWeapon expPoon = new SL_MeleeWeapon()
            {
                Target_ItemID = DEFPOON_ID,
                New_ItemID = EPOON_ID,
                Name = "Expert Fishing Harpoon",
                Description = "A harpoon of exceptional quality that is capable of fishing a great deal more effectively.",
                StatsHolder = new SL_WeaponStats()
                {
                    BaseDamage = new List<SL_Damage>()
                    {
                        new SL_Damage()
                        {
                            Damage = 26f,
                            Type = DamageType.Types.Physical
                        },
                    },
                    MaxDurability = EPOON_DURABILITY,
                    BaseValue = EPOON_VALUE,
                },
            };
            expPoon.SLPackName = "APP";
            expPoon.SubfolderName = "ExpertPoon";
            expPoon.ApplyTemplate();
        }
    }
}
