using HarmonyLib;
using NodeCanvas.DialogueTrees;
using System.Collections.Generic;

namespace APP
{
    public class Harmonize
    {
        // To allow access from patches
        public static Harmonize Instance { get; private set; }

        static bool isMining = false;
        static bool isFishing = false;
        static bool isDialoguePatched = false;

        internal void Awake()
        {
            Instance = this;
        }

        [HarmonyPrefix, HarmonyPatch(typeof(Gatherable), nameof(Gatherable.OnGatherInteraction))]
        private static void GatherPatch(Character _gatherer, Gatherable __instance)
        {
            if (isMining)
            {
                //TODO Master tool
                // Check for highest mining tool
                if (_gatherer.Inventory.OwnsItem(Plugin.APICK_ID) && !_gatherer.Inventory.OwnsItem(Plugin.EPICK_ID))
                {
                    int rng = UnityEngine.Random.Range(1, 100);

                    // 25 percent change of extra gather
                    if (rng < 26)
                    {
                        __instance.StartInit();
                    }
                }

                if (_gatherer.Inventory.OwnsItem(Plugin.EPICK_ID))
                {
                    int rng = UnityEngine.Random.Range(1, 100);

                    // 50 percent chance of extra gather
                    if (rng < 51)
                    {
                        __instance.StartInit();
                    }
                }

                isMining = false;
            }
            else if (isFishing)
            {
                //TODO Master tool
                // Check for highest fishing tool
                if (_gatherer.Inventory.OwnsItem(Plugin.APOON_ID) && !_gatherer.Inventory.OwnsItem(Plugin.EPOON_ID))
                {
                    int rng = UnityEngine.Random.Range(1, 100);

                    if (rng < 26)
                    {
                        __instance.StartInit();
                    }
                }

                if (_gatherer.Inventory.OwnsItem(Plugin.EPOON_ID))
                {
                    int rng = UnityEngine.Random.Range(1, 100);

                    // 50 percent chance of extra gather
                    if (rng < 51)
                    {
                        __instance.StartInit();
                    }
                }

                isFishing = false;
            }
            else
            {
                //TODO Master tool
                // Check for highest harvest sickle
                if (_gatherer.Inventory.OwnsItem(Plugin.ASICK_ID) && !_gatherer.Inventory.OwnsItem(Plugin.ESICK_ID))
                {
                    int rng = UnityEngine.Random.Range(1, 100);

                    // 25 percent chance of extra gather
                    //! Consider changing to lower
                    if (rng < 26)
                    {
                        __instance.StartInit();
                    }
                }

                if (_gatherer.Inventory.OwnsItem(Plugin.ESICK_ID))
                {
                    int rng = UnityEngine.Random.Range(1, 100);

                    // 50 percent chance of extra gather
                    //! Consider changing to lower
                    if (rng < 51)
                    {
                        __instance.StartInit();
                    }
                }
            }
        }
        [HarmonyPostfix, HarmonyPatch(typeof(CharacterInventory), nameof(CharacterInventory.GetCompatibleGatherableTool))]
        private static void GetToolPatch(int _sourceToolID)
        {
            //Finds the current tool type to decide if mining or fishing
            //NOTE: The game treats all tools in the dictionary as default tools at this point
            if (_sourceToolID == Plugin.DEFPICK_ID)
            {
                isMining = true;
                isFishing = false;
            }
            else if (_sourceToolID == Plugin.DEFPOON_ID)
            {
                isMining = false;
                isFishing = true;
            }
            else
            {
                isMining = false;
                isFishing = false;
            }
        }

        [HarmonyPrefix, HarmonyPatch(typeof(NPCInteraction), nameof(NPCInteraction.OnActivate))]
        private static void NPCInteractionPatch(NPCInteraction __instance)
        {
            if (__instance.DialogueActor.name == "Loud-Hammer" && !isDialoguePatched) //Specific NPC name and make sure we haven't already patched
            {
                var graphController = __instance.DialogueActor.GetComponentInChildren<DialogueTreeController>();
                var graph = graphController.graph;
                List<MultipleChoiceNodeExt> MultipleChoiceNodes = graph.GetAllNodesOfType<MultipleChoiceNodeExt>();

                // Find root choice
                MultipleChoiceNodeExt rootChoice = MultipleChoiceNodes[0];

                // Initalise a new choice 
                MultipleChoiceNodeExt.Choice yourMultiChoice = new MultipleChoiceNodeExt.Choice()
                {
                    // The option the player has
                    statement = new Statement("Is there anything else you can teach me?")
                };
                // Add new choice to original statement tree
                rootChoice.availableChoices.Add(yourMultiChoice);

                // Set the NPC reply
                var answer = graph.AddNode<StatementNodeExt>();
                answer.statement = new Statement("If you are interested in discovering the secrets of more efficient gathering tools, seek out other blacksmiths in far away cities!");
                answer.SetActorName("Loud-Hammer");

                // Add and connect nodes
                graph.allNodes.Add(answer);
                graph.ConnectNodes(rootChoice, answer, 6);

                isDialoguePatched = true; //So we don't infinitely add this each time we talk to NPC
            }
        }
    }
}


