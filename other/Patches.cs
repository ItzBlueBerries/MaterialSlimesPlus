using HarmonyLib;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MaterialSlimesPlus
{
    [HarmonyPatch(typeof(SlimeEat), "EatAndProduce")]
    class SlimePatches_EatAndProduce
    {
        static void Postfix(SlimeEat __instance, SlimeDiet.EatMapEntry em)
        {
            if (!__instance.slimeDefinition.Matches(Ids.LiquidSlimes.INFECTED_BLOOD_SLIME) && !__instance.slimeDefinition.Matches(Ids.LiquidSlimes.BLOOD_SLIME))
            {
                List<Identifiable.Id> idList = new List<Identifiable.Id>();

                idList.Add(Ids.LiquidSlimes.BLOOD_PLORT);
                idList.Add(Ids.LiquidSlimes.BLOOD_PLORT);
                idList.Add(Ids.LiquidSlimes.BLOOD_PLORT);

                idList.Add(Ids.LiquidSlimes.INFECTED_BLOOD_PLORT);
                idList.Add(Ids.LiquidSlimes.INFECTED_BLOOD_PLORT);

                if (em.eats == Ids.LiquidSlimes.BLOOD_SLIME)
                    em.producesId = idList.RandomObject();
            }
        }
    }
}
