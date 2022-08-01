using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSlimesPlus
{
    [HarmonyPatch(typeof(SlimeDiet), "RefreshEatMap")]
    class EatMapPatch_LiquidSlimes
    {
        static void Postfix(SlimeDiet __instance, SlimeDefinitions definitions, SlimeDefinition definition)
        {
            // just some casual eatmaps lol
            if (definition.IdentifiableId != Ids.LiquidSlimes.BLOOD_SLIME && definition.IdentifiableId != Ids.LiquidSlimes.INFECTED_BLOOD_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == Ids.LiquidSlimes.BLOOD_SLIME);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = Ids.LiquidSlimes.BLOOD_PLORT,
                    eats = Ids.LiquidSlimes.BLOOD_SLIME,
                    minDrive = 1
                });
            }
            /*if (definition.IdentifiableId == Ids.LiquidSlimes.BLOOD_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == Ids.LiquidSlimes.INFECTED_BLOOD_SLIME);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = Ids.LiquidSlimes.BLOOD_SLIME,
                    eats = Ids.LiquidSlimes.INFECTED_BLOOD_SLIME,
                    minDrive = 1
                });
            }
            if (definition.IdentifiableId == Ids.LiquidSlimes.INFECTED_BLOOD_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == Ids.LiquidSlimes.BLOOD_SLIME);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    producesId = Ids.LiquidSlimes.INFECTED_BLOOD_SLIME,
                    eats = Ids.LiquidSlimes.BLOOD_SLIME,
                    minDrive = 1
                });
            }*/
            if (definition.IdentifiableId != Ids.LiquidSlimes.INFECTED_BLOOD_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == Ids.LiquidSlimes.INFECTED_BLOOD_PLORT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = Ids.LiquidSlimes.INFECTED_BLOOD_SLIME,
                    eats = Ids.LiquidSlimes.INFECTED_BLOOD_PLORT,
                    minDrive = 0.5f
                });
            }
            if (definition.IdentifiableId != Ids.LiquidSlimes.INFECTED_BLOOD_SLIME && definition.IdentifiableId != Ids.LiquidSlimes.BLOOD_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == Ids.LiquidSlimes.INFECTED_BLOOD_SLIME);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = Ids.LiquidSlimes.INFECTED_BLOOD_SLIME,
                    eats = Ids.LiquidSlimes.INFECTED_BLOOD_SLIME,
                    minDrive = 0.5f
                });
            }
            // ooo largos
            if (definition.IdentifiableId == Ids.LiquidSlimes.OIL_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == Ids.LiquidSlimes.OIL_SLIME);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = largoIds.LiquidSlimes.MEDIUM_OIL_LARGO,
                    eats = Ids.LiquidSlimes.OIL_SLIME,
                    minDrive = 0.8f
                });
            }
            if (definition.IdentifiableId == largoIds.LiquidSlimes.MEDIUM_OIL_LARGO)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == largoIds.LiquidSlimes.MEDIUM_OIL_LARGO);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = largoIds.LiquidSlimes.LARGE_OIL_LARGO,
                    eats = largoIds.LiquidSlimes.MEDIUM_OIL_LARGO,
                    minDrive = 0.8f
                });
            }
            if (definition.IdentifiableId == largoIds.LiquidSlimes.LARGE_OIL_LARGO)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == largoIds.LiquidSlimes.LARGE_OIL_LARGO);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = largoIds.LiquidSlimes.EXL_OIL_LARGO,
                    eats = largoIds.LiquidSlimes.LARGE_OIL_LARGO,
                    minDrive = 0.8f
                });
            }
            if (definition.IdentifiableId == largoIds.LiquidSlimes.EXL_OIL_LARGO)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == largoIds.LiquidSlimes.EXL_OIL_LARGO);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = largoIds.LiquidSlimes.EVL_OIL_LARGO,
                    eats = largoIds.LiquidSlimes.EXL_OIL_LARGO,
                    minDrive = 0.8f
                });
            }
            if (definition.IdentifiableId == largoIds.LiquidSlimes.EVL_OIL_LARGO)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == largoIds.LiquidSlimes.EVL_OIL_LARGO);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = largoIds.LiquidSlimes.MEGA_OIL_LARGO,
                    eats = largoIds.LiquidSlimes.EVL_OIL_LARGO,
                    minDrive = 0.8f
                });
            }
            /*if (definition.IdentifiableId == largoIds.LiquidSlimes.MEGA_OIL_LARGO)
            { 
                __instance.EatMap.RemoveAll((x) => x.eats == Ids.LiquidSlimes.OIL_PLORT); 
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry() { eats = Ids.LiquidSlimes.OIL_PLORT, minDrive = 0.8f, producesId = Ids.LiquidSlimes.OIL_SLIME }); 
            }*/
            // items?
            if (definition.IdentifiableId != Ids.LiquidSlimes.INFECTED_BLOOD_SLIME && definition.IdentifiableId != Ids.LiquidSlimes.BLOOD_SLIME)
            {
                __instance.EatMap.RemoveAll((x) => x.eats == Ids.LiquidSlimes.DECOMPOSING_FLUIDS_CRAFT);
                __instance.EatMap.Add(new SlimeDiet.EatMapEntry()
                {
                    becomesId = Ids.LiquidSlimes.BLOOD_SLIME,
                    eats = Ids.LiquidSlimes.DECOMPOSING_FLUIDS_CRAFT,
                    minDrive = 0.5f
                });
            }
        }
    }
}
