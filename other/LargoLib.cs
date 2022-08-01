using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using LargoLibrary;
using static LargoLibrary.LargoGenerator;
using static LargoLibFuncProps.LiquidSlimes;
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
            LargoProperties[] properties = new LargoProperties[0];
            TranslationPatcher.AddActorTranslation("l." + largoIds.LiquidSlimes.MEDIUM_OIL_LARGO.ToString().ToLower(), "Medium Oil Slime");
            GameObject largoObject = CreateLargo(slime1, slime2, largoId, properties);
            SlimeDefinition largoDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(largoId);
            largoDefinition.Diet.FavoriteProductionCount = 2;
            largoDefinition.Diet.RefreshEatMap(GameContext.Instance.SlimeDefinitions, largoDefinition);
            largoDefinition.Name = "Medium Oil Slime";

            /*SceneContext.Instance.SlimeAppearanceDirector.RegisterDependentAppearances(largoDefinition, largoDefinition.AppearancesDefault[0]);
            SceneContext.Instance.SlimeAppearanceDirector.UpdateChosenSlimeAppearance(largoDefinition, largoDefinition.AppearancesDefault[0]);*/

            return largoObject;
        }
        public static GameObject CreateLargeOilLargo(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
        {
            LargoProperties[] properties = new LargoProperties[0];
            TranslationPatcher.AddActorTranslation("l." + largoIds.LiquidSlimes.LARGE_OIL_LARGO.ToString().ToLower(), "Large Oil Slime");
            GameObject largoObject = CreateLargo(slime1, slime2, largoId, properties);
            largoObject.transform.localScale *= 2;
            SlimeDefinition largoDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(largoId);
            largoDefinition.Diet.FavoriteProductionCount = 3;
            largoDefinition.Diet.RefreshEatMap(GameContext.Instance.SlimeDefinitions, largoDefinition);
            largoDefinition.Name = "Large Oil Slime";

            largoDefinition.Diet.Produces = new Identifiable.Id[4]
            {
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_PLORT,
                Ids.LiquidSlimes.OIL_PLORT
            };

            /*SceneContext.Instance.SlimeAppearanceDirector.RegisterDependentAppearances(largoDefinition, largoDefinition.AppearancesDefault[0]);
            SceneContext.Instance.SlimeAppearanceDirector.UpdateChosenSlimeAppearance(largoDefinition, largoDefinition.AppearancesDefault[0]);*/

            return largoObject;
        }
        public static GameObject CreateExtraLargeOilLargo(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
        {
            LargoProperties[] properties = new LargoProperties[0];
            TranslationPatcher.AddActorTranslation("l." + largoIds.LiquidSlimes.EXL_OIL_LARGO.ToString().ToLower(), "Extra Large Oil Slime");
            GameObject largoObject = CreateLargo(slime1, slime2, largoId, properties);
            largoObject.transform.localScale *= 3;
            SlimeDefinition largoDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(largoId);
            largoDefinition.Diet.FavoriteProductionCount = 4;
            largoDefinition.Diet.RefreshEatMap(GameContext.Instance.SlimeDefinitions, largoDefinition);
            largoDefinition.Name = "Extra Large Oil Slime";

            largoDefinition.Diet.Produces = new Identifiable.Id[4]
            {
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME
            };

            /*SceneContext.Instance.SlimeAppearanceDirector.RegisterDependentAppearances(largoDefinition, largoDefinition.AppearancesDefault[0]);
            SceneContext.Instance.SlimeAppearanceDirector.UpdateChosenSlimeAppearance(largoDefinition, largoDefinition.AppearancesDefault[0]);*/

            return largoObject;
        }

        public static GameObject CreateEvenLargerOilLargo(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
        {
            LargoProperties[] properties = new LargoProperties[0];
            TranslationPatcher.AddActorTranslation("l." + largoIds.LiquidSlimes.EVL_OIL_LARGO.ToString().ToLower(), "Even Larger Oil Slime");
            GameObject largoObject = CreateLargo(slime1, slime2, largoId, properties);
            largoObject.transform.localScale *= 4;
            SlimeDefinition largoDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(largoId);
            largoDefinition.Diet.FavoriteProductionCount = 5;
            largoDefinition.Diet.RefreshEatMap(GameContext.Instance.SlimeDefinitions, largoDefinition);
            largoDefinition.Name = "Even Larger Oil Slime";

            largoDefinition.Diet.Produces = new Identifiable.Id[6]
            {
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME,
                Ids.LiquidSlimes.OIL_SLIME
            };

            /*SceneContext.Instance.SlimeAppearanceDirector.RegisterDependentAppearances(largoDefinition, largoDefinition.AppearancesDefault[0]);
            SceneContext.Instance.SlimeAppearanceDirector.UpdateChosenSlimeAppearance(largoDefinition, largoDefinition.AppearancesDefault[0]);*/

            return largoObject;
        }
        public static GameObject CreateMegaOilLargo(Identifiable.Id slime1, Identifiable.Id slime2, Identifiable.Id largoId)
        {
            LargoProperties[] properties = new LargoProperties[0];
            TranslationPatcher.AddActorTranslation("l." + largoIds.LiquidSlimes.MEGA_OIL_LARGO.ToString().ToLower(), "Mega Oil Slime");
            GameObject largoObject = CreateLargo(slime1, slime2, largoId, properties);
            largoObject.transform.localScale *= 5;
            SlimeDefinition largoDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(largoId);
            largoDefinition.Diet.FavoriteProductionCount = 6;
            largoDefinition.Diet.RefreshEatMap(GameContext.Instance.SlimeDefinitions, largoDefinition);
            largoDefinition.Name = "Mega Oil Slime";

            largoDefinition.Diet.Produces = new Identifiable.Id[8]
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

            /*SceneContext.Instance.SlimeAppearanceDirector.RegisterDependentAppearances(largoDefinition, largoDefinition.AppearancesDefault[0]);
            SceneContext.Instance.SlimeAppearanceDirector.UpdateChosenSlimeAppearance(largoDefinition, largoDefinition.AppearancesDefault[0]);*/

            return largoObject;
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