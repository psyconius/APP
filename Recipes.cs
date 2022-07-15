using System.Collections.Generic;
using SideLoader;

namespace APP
{
    public class Recipes
    {
        // Recipe IDs
        public const string APICK_REC = "app.advpick";
        public const string EPICK_REC = "app.exppick";
        public const string APOON_REC = "app.advpoon";
        public const string EPOON_REC = "app.expoon";
        public const string MPICK_REC = "app.maspick";
        public const string MPOON_REC = "app.maspoon";
        public const string ASICK_REC = "app.advsick";
        public const string ESICK_REC = "app.expsick";
        public const string MSICK_REC = "app.massick";

        // Recipe Scroll IDs
        public const int APICK_REC_ID = -31010;
        public const int APOON_REC_ID = -31011;
        public const int EPICK_REC_ID = -31012;
        public const int EPOON_REC_ID = -31013;
        public const int MPICK_REC_ID = -31014;
        public const int MPOON_REC_ID = -31015;
        public const int ASICK_REC_ID = -31016;
        public const int ESICK_REC_ID = -31017;
        public const int MSICK_REC_ID = -31018;

        // Schematic costs
        public const int ADVTOOLCOST = 75;
        public const int EXPTOOLCOST = 125;
        public const int MASTOOLCOST = 200;

        // Ingredient IDs
        public const string ING_MININGPICK = "2120050";
        public const string ING_PALLADIUM = "6400070";
        public const string ING_AMMOLITE = "6200050";
        public const string ING_BEASTGOLEMSCRAPS = "6600130";
        public const string ING_GOLDINGOT = "6300030";
        public const string ING_AMETHYSTGEODE = "6000370";
        public const string ING_CHROMIUMSHARDS = "6000340";

        public const string ING_FISHINGHARPOON = "2130130";
        public const string ING_BLUESAND = "6400110";
        public const string ING_SHARKCARTILAGE = "6600170";
        public const string ING_PETRIFIEDORGANS = "6000440";
        public const string ING_DIGESTEDMANASTONE = "6000450";

        public const string ING_MACHETE = "2000060";
        public const string ING_WOOLSHROOM = "4000240";
        public const string ING_PETRIFIEDWOOD = "6400080";
        public const string ING_VOLTAICVINES = "6000410";
        public const string ING_BLOODROOT = "6000400";


        public static void CreateRecipes()
        {
            CreatePickRecipes();
            CreatePoonRecipes();
            CreateSickleRecipes();
            CreateMasterRecipes(); //! Not implemented yet
        }

        private static void CreatePickRecipes()
        {
            SL_Recipe advPickRecipe = new SL_Recipe()
            {
                UID = APICK_REC,
                StationType = Recipe.CraftingType.Survival,
                Ingredients = new List<SL_Recipe.Ingredient>()
                {
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_MININGPICK },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_PALLADIUM },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_AMMOLITE },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_BEASTGOLEMSCRAPS }
                },
                Results = new List<SL_Recipe.ItemQty>()
                {
                    new SL_Recipe.ItemQty(){ ItemID = Plugin.APICK_ID, Quantity = 1 },
                }
            };
            advPickRecipe.ApplyTemplate();

            SL_Recipe expPickRecipe = new SL_Recipe()
            {
                UID = EPICK_REC,
                StationType = Recipe.CraftingType.Survival,
                Ingredients = new List<SL_Recipe.Ingredient>()
                {
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = Plugin.APICK_ID.ToString() },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_GOLDINGOT },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_AMETHYSTGEODE },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_CHROMIUMSHARDS }
                },
                Results = new List<SL_Recipe.ItemQty>()
                {
                    new SL_Recipe.ItemQty(){ ItemID = Plugin.EPICK_ID, Quantity = 1 },
                }
            };
            expPickRecipe.ApplyTemplate();
        }

        private static void CreatePoonRecipes()
        {
            SL_Recipe advPoonRecipe = new SL_Recipe()
            {
                UID = APOON_REC,
                StationType = Recipe.CraftingType.Survival,
                Ingredients = new List<SL_Recipe.Ingredient>()
                {
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue =  ING_FISHINGHARPOON },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue =  ING_PALLADIUM },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue =  ING_BLUESAND },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue =  ING_SHARKCARTILAGE }
                },
                Results = new List<SL_Recipe.ItemQty>()
                {
                    new SL_Recipe.ItemQty(){ ItemID = Plugin.APOON_ID, Quantity = 1 },
                }
            };
            advPoonRecipe.ApplyTemplate();

            SL_Recipe expPoonRecipe = new SL_Recipe()
            {
                UID = EPOON_REC,
                StationType = Recipe.CraftingType.Survival,
                Ingredients = new List<SL_Recipe.Ingredient>()
                {
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = Plugin.APOON_ID.ToString() },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_GOLDINGOT },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_PETRIFIEDORGANS },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_DIGESTEDMANASTONE }
                },
                Results = new List<SL_Recipe.ItemQty>()
                {
                    new SL_Recipe.ItemQty(){ ItemID = Plugin.EPOON_ID, Quantity = 1 },
                }
            };
            expPoonRecipe.ApplyTemplate();
        }

        private static void CreateSickleRecipes()
        {
            SL_Recipe advSickRecipe = new SL_Recipe()
            {
                UID = ASICK_REC,
                StationType = Recipe.CraftingType.Survival,
                Ingredients = new List<SL_Recipe.Ingredient>()
                {
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue =  ING_MACHETE },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue =  ING_PALLADIUM },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue =  ING_WOOLSHROOM },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue =  ING_PETRIFIEDWOOD }
                },
                Results = new List<SL_Recipe.ItemQty>()
                {
                    new SL_Recipe.ItemQty(){ ItemID = Plugin.ASICK_ID, Quantity = 1 },
                }
            };
            advSickRecipe.ApplyTemplate();

            SL_Recipe expSickRecipe = new SL_Recipe()
            {
                UID = ESICK_REC,
                StationType = Recipe.CraftingType.Survival,
                Ingredients = new List<SL_Recipe.Ingredient>()
                {
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = Plugin.ASICK_ID.ToString() },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_GOLDINGOT },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_VOLTAICVINES },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_BLOODROOT }
                },
                Results = new List<SL_Recipe.ItemQty>()
                {
                    new SL_Recipe.ItemQty(){ ItemID = Plugin.ESICK_ID, Quantity = 1 },
                }
            };
            expSickRecipe.ApplyTemplate();
        }

        public static void CreateMasterRecipes()
        {
            //TODO Make Master recipes
        }
        public static void CreateRecipeScrolls()
        {
            //Picks
            SL_RecipeItem advPickRecipeScroll = new SL_RecipeItem()
            {
                RecipeUID = APICK_REC,
                Target_ItemID = 5700187, // Old lantern recipe, for visual
                New_ItemID = APICK_REC_ID,
                Name = "Crafting: Advanced Mining Pick",
                Description = "Schematic that teaches the user how to craft an Advanced Mining Pick",
                StatsHolder = new SL_ItemStats { BaseValue = ADVTOOLCOST }
            };
            advPickRecipeScroll.ApplyTemplate();

            SL_RecipeItem expPickRecipeScroll = new SL_RecipeItem()
            {
                RecipeUID = EPICK_REC,
                Target_ItemID = 5700187, // Old lantern recipe, for visual
                New_ItemID = EPICK_REC_ID,
                Name = "Crafting: Expert Mining Pick",
                Description = "Schematic that teaches the user how to craft an Expert Mining Pick",
                StatsHolder = new SL_ItemStats { BaseValue = EXPTOOLCOST }
            };
            expPickRecipeScroll.ApplyTemplate();

            //Poons
            SL_RecipeItem advPoonRecipeScroll = new SL_RecipeItem()
            {
                RecipeUID = APOON_REC,
                Target_ItemID = 5700187, // Old lantern recipe, for visual
                New_ItemID = APOON_REC_ID,
                Name = "Crafting: Advanced Fishing Harpoon",
                Description = "Schematic that teaches the user how to craft an Advanced Fishing Harpoon",
                StatsHolder = new SL_ItemStats { BaseValue = ADVTOOLCOST }
            };
            advPoonRecipeScroll.ApplyTemplate();

            SL_RecipeItem expPoonRecipeScroll = new SL_RecipeItem()
            {
                RecipeUID = EPOON_REC,
                Target_ItemID = 5700187, // Old lantern recipe, for visual
                New_ItemID = EPOON_REC_ID,
                Name = "Crafting: Expert Fishing Harpoon",
                Description = "Schematic that teaches the user how to craft an Expert Fishing Harpoon",
                StatsHolder = new SL_ItemStats { BaseValue = EXPTOOLCOST }
            };
            expPoonRecipeScroll.ApplyTemplate();

            //Sicks
            SL_RecipeItem advSickRecipeScroll = new SL_RecipeItem()
            {
                RecipeUID = ASICK_REC,
                Target_ItemID = 5700187, // Old lantern recipe, for visual
                New_ItemID = ASICK_REC_ID,
                Name = "Crafting: Advanced Sickle",
                Description = "Schematic that teaches the user how to craft an Advanced Harvesting Sickle",
                StatsHolder = new SL_ItemStats { BaseValue = ADVTOOLCOST }
            };
            advSickRecipeScroll.ApplyTemplate();

            SL_RecipeItem expSickRecipeScroll = new SL_RecipeItem()
            {
                RecipeUID = ESICK_REC,
                Target_ItemID = 5700187, // Old lantern recipe, for visual
                New_ItemID = ESICK_REC_ID,
                Name = "Crafting: Expert Sickle",
                Description = "Schematic that teaches the user how to craft an Expert Harvesting Sickle",
                StatsHolder = new SL_ItemStats { BaseValue = EXPTOOLCOST }

            };
            expSickRecipeScroll.ApplyTemplate();
        }

        public static void AddRecipesToMerchants()
        {
            const string ADVTOOLSDT_ID = "gothiska.advtools";
            const string EXPTOOLSDT_ID = "gothiska.exptools";

            SL_DropTable advToolsDT = new SL_DropTable()
            {
                UID = ADVTOOLSDT_ID,
                GuaranteedDrops = new List<SL_ItemDrop>()
                {
                    new SL_ItemDrop { DroppedItemID = APICK_REC_ID, MinQty = 1, MaxQty = 1 },
                    new SL_ItemDrop { DroppedItemID = APOON_REC_ID, MinQty = 1, MaxQty = 1 },
                    new SL_ItemDrop { DroppedItemID = ASICK_REC_ID, MinQty = 1, MaxQty = 1 }
                },
            };
            advToolsDT.ApplyTemplate();

            SL_DropTable expToolsDT = new SL_DropTable()
            {
                UID = EXPTOOLSDT_ID,
                GuaranteedDrops = new List<SL_ItemDrop>()
                {
                    new SL_ItemDrop { DroppedItemID = EPICK_REC_ID, MinQty = 1, MaxQty = 1 },
                    new SL_ItemDrop { DroppedItemID = EPOON_REC_ID, MinQty = 1, MaxQty = 1 },
                    new SL_ItemDrop { DroppedItemID = ESICK_REC_ID, MinQty = 1, MaxQty = 1 }
                },
            };
            expToolsDT.ApplyTemplate();

            //TODO Master tool DT
            
            SL_DropTableAddition advRecipeVendor = new SL_DropTableAddition
            {
                SelectorTargets = {
                    "3Rx_R0XDLUmYaNWm66SVCQ", // Berg smith
                    "3Rx_R0XDLUmYaNWm66SVCQ", // Monsoon smith
                    "3Rx_R0XDLUmYaNWm66SVCQ", // Levant smith (ID1)
                    "EYhBqM653UGhDd5kcdMFXg", // Levant smith (ID2)
                    "Zdg-qTDRa0-qOzzNSbtvzg", // Harmattan smith
                    "-MSrkT502k63y3CV2j98TQ"  //TODO Sirocco Caravanner - GET SAL DUMAS ID
                },
                DropTableUIDsToAdd = { advToolsDT.UID }
            };
            advRecipeVendor.ApplyTemplate();

            SL_DropTableAddition expRecipeVendor = new SL_DropTableAddition
            {
                SelectorTargets = {
                    "Zdg-qTDRa0-qOzzNSbtvzg", // Harmattan smith
                    "-MSrkT502k63y3CV2j98TQ"  //TODO Sirocco Caravanner - GET SAL DUMAS ID
                },
                DropTableUIDsToAdd = { expToolsDT.UID }
            };
            expRecipeVendor.ApplyTemplate();
        }
    } 
}
