using SRML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaterialSlimesPlus.EX;
using SRML.SR;
using UnityEngine;
using SRML.Utils;

namespace MaterialSlimesPlus
{
    public class Main : ModEntryPoint
    {
        // Called before GameContext.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();
            LoadExtensions.PreloadEx();
        }

        // Called before GameContext.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {
            if (!SRModLoader.IsModPresent("materialslimesog"))
            {
                throw new Exception("[MATERIAL_SLIMES_PLUS+] This is an Extension to Material Slimes, it does require Material Slimes in order to run correctly.");
            }
            LoadExtensions.LoadEx();
        }

        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {
            if (SRModLoader.IsModPresent("materialslimesog"))
                SRML.Console.Console.LogSuccess("[MATERIAL_SLIMES_PLUS+] Loaded MaterialSlimesPlus+ Successfully.");
            else
                SRML.Console.Console.LogError("[MATERIAL_SLIMES_PLUS+] Didn't load MaterialSlimesPlus+ Successfully. (Is Material Slimes installed?)");
            LoadExtensions.PostloadEx();
            /*SlimeDefinition largoDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(largoIds.LiquidSlimes.MEGA_OIL_LARGO);
            foreach (Identifiable.Id produces in largoDefinition.Diet.Produces)
                SRML.Console.Console.Log(produces.ToString());*/
            /*GameObject gadgetObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(gadgetIds.LiquidSlimes.OIL_EXCHANGER_BASIC).prefab);
            foreach (Transform childs in gadgetObject.transform.Find("ext_pump23"))
                SRML.Console.Console.Log(childs.ToString());*/
        }

    }
}