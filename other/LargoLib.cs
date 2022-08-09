using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static LargoLibFuncProps.LiquidSlimes;
using static SRML.SR.SlimeRegistry;
using SRML.Utils;
using SRML.SR;

class LargoLibFuncProps
{
    internal class LiquidSlimes
    {
        // liquid slimes
        // oil largos
        public static GameObject CreateMediumOilLargo(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
        {
            TranslationPatcher.AddActorTranslation("l." + largoIds.LiquidSlimes.MEDIUM_OIL_LARGO.ToString().ToLower(), "Medium Oil Slime");
            CraftLargo(largoId, slime1, slime2, LargoProps.NONE, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);
            largoDef.Name = "Medium Oil Slime";

            return largoObj;
        }
        public static GameObject CreateLargeOilLargo(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
        {
            TranslationPatcher.AddActorTranslation("l." + largoIds.LiquidSlimes.LARGE_OIL_LARGO.ToString().ToLower(), "Large Oil Slime");
            CraftLargo(largoId, slime1, slime2, LargoProps.NONE, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);
            largoObj.transform.localScale *= 2;
            largoDef.Diet.FavoriteProductionCount = 3;
            largoDef.Name = "Large Oil Slime";

            largoDef.Diet.Produces = new Identifiable.Id[4]
            {
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_PLORT,
                Ids.LiquidSlimes.OIL_PLORT
            };

            return largoObj;
        }
        public static GameObject CreateExtraLargeOilLargo(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
        {
            TranslationPatcher.AddActorTranslation("l." + largoIds.LiquidSlimes.EXL_OIL_LARGO.ToString().ToLower(), "Extra Large Oil Slime");
            CraftLargo(largoId, slime1, slime2, LargoProps.NONE, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);
            largoObj.transform.localScale *= 3;
            largoDef.Diet.FavoriteProductionCount = 4;
            largoDef.Name = "Extra Large Oil Slime";

            largoDef.Diet.Produces = new Identifiable.Id[4]
            {
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME
            };

            return largoObj;
        }

        public static GameObject CreateEvenLargerOilLargo(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
        {
            TranslationPatcher.AddActorTranslation("l." + largoIds.LiquidSlimes.EVL_OIL_LARGO.ToString().ToLower(), "Even Larger Oil Slime");
            CraftLargo(largoId, slime1, slime2, LargoProps.NONE, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);
            largoObj.transform.localScale *= 4;
            largoDef.Diet.FavoriteProductionCount = 5;
            largoDef.Name = "Even Larger Oil Slime";

            largoDef.Diet.Produces = new Identifiable.Id[6]
            {
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME
            };

            return largoObj;
        }
        public static GameObject CreateMegaOilLargo(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
        {
            TranslationPatcher.AddActorTranslation("l." + largoIds.LiquidSlimes.MEGA_OIL_LARGO.ToString().ToLower(), "Mega Oil Slime");
            CraftLargo(largoId, slime1, slime2, LargoProps.NONE, out SlimeDefinition largoDef, out SlimeAppearance largoApp, out GameObject largoObj);
            largoObj.transform.localScale *= 5;
            largoDef.Diet.FavoriteProductionCount = 6;
            largoDef.Name = "Mega Oil Slime";

            largoDef.Diet.Produces = new Identifiable.Id[8]
            {
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME
            };

            return largoObj;
        }
    }
}

class LargoLibFunc
{
    public class SlimeID
    {
        public static Identifiable.Id Blood = Ids.LiquidSlimes.BLOOD_SLIME;
        public static Identifiable.Id InfBlood = Ids.LiquidSlimes.INFECTED_BLOOD_SLIME;
        public static Identifiable.Id Oil = Ids.LiquidSlimes.OIL_SLIME;
    }

    static public void LoadLargoLib()
    {
        LoadLiquidLargos();
        return;
    }

    static public void LoadLiquidLargos()
    {
        CreateMediumOilLargo(SlimeID.Oil, SlimeID.Oil, largoIds.LiquidSlimes.MEDIUM_OIL_LARGO);
        CreateLargeOilLargo(SlimeID.Oil, SlimeID.Oil, largoIds.LiquidSlimes.LARGE_OIL_LARGO);
        CreateExtraLargeOilLargo(SlimeID.Oil, SlimeID.Oil, largoIds.LiquidSlimes.EXL_OIL_LARGO);
        CreateEvenLargerOilLargo(SlimeID.Oil, SlimeID.Oil, largoIds.LiquidSlimes.EVL_OIL_LARGO);
        CreateMegaOilLargo(SlimeID.Oil, SlimeID.Oil, largoIds.LiquidSlimes.MEGA_OIL_LARGO);
        return;
    }
}