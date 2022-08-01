using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MaterialSlimesPlus.EX1
{
    // plort
    class LiquidPlorts
    {
        public static GameObject BloodPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.RAD_PLORT)); //It can be any plort, but pink works the best. 
            Prefab.name = "Blood Plort";

            Prefab.GetComponent<Identifiable>().id = Ids.LiquidSlimes.BLOOD_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Color RedColor = new Color32(138, 3, 3, 255);
            Color DarkerRedColor = new Color32(125, 3, 3, 255);
            // SET PLORT COLORS HERE!! Btw above is if you want color vars-
            //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want. (man frosty and his comments collide with mines lol)
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", RedColor);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", DarkerRedColor);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", RedColor);

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
        public static GameObject InfectedBloodPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.RAD_PLORT)); //It can be any plort, but pink works the best. 
            Prefab.name = "Infected Blood Plort";

            Prefab.GetComponent<Identifiable>().id = Ids.LiquidSlimes.INFECTED_BLOOD_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Color EvenDarkerRedColor = new Color32(115, 3, 3, 255);
            Color DarkerRedColor = new Color32(125, 3, 3, 255);
            // SET PLORT COLORS HERE!! Btw above is if you want color vars-
            //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want. (man frosty and his comments collide with mines lol)
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", DarkerRedColor);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", EvenDarkerRedColor);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", DarkerRedColor);

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
        public static GameObject OilPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.RAD_PLORT)); //It can be any plort, but pink works the best. 
            Prefab.name = "Oil Plort";

            Prefab.GetComponent<Identifiable>().id = Ids.LiquidSlimes.OIL_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Color OilColor = new Color32(219, 207, 92, 255);
            Color DarkerOilColor = new Color32(209, 207, 92, 255);
            // SET PLORT COLORS HERE!! Btw above is if you want color vars-
            //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want. (man frosty and his comments collide with mines lol)
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", OilColor);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", DarkerOilColor);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", OilColor);

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
    }

    // slime
    class LiquidSlimes
    {
        public static (SlimeDefinition, GameObject) CreateBloodSlime(Identifiable.Id SlimeId, String SlimeName) // that red one lol
        {
            // DEFINE
            SlimeDefinition bloodSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PUDDLE_SLIME); // make sure to make slimeNameDefiniton your slime name btw-
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(bloodSlimeDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[2]
            {
                Ids.LiquidSlimes.BLOOD_SLIME,
                Ids.LiquidSlimes.BLOOD_SLIME
            };
            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[2]
            {
                SlimeEat.FoodGroup.NONTARRGOLD_SLIMES,
                SlimeEat.FoodGroup.MEAT
            };
            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[1] { Ids.LiquidSlimes.INFECTED_BLOOD_SLIME }; // additional foods
            slimeDefinition.Diet.Favorites = new Identifiable.Id[2] // favorites
            {
                Identifiable.Id.TABBY_SLIME,
                Identifiable.Id.PAINTED_HEN,
            };
            slimeDefinition.Diet.EatMap?.Clear(); // don't touch this unless your probably a little more advanced, idk
            // TARR SUPPORT (this is if you want it)
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TARR_SLIME);
            slimeByIdentifiableId.Diet.AdditionalFoods = new Identifiable.Id[1]
            {
                Ids.LiquidSlimes.BLOOD_SLIME
            };
            slimeDefinition.CanLargofy = false;
            slimeDefinition.FavoriteToys = new Identifiable.Id[1];
            slimeDefinition.Name = "Blood Slime";
            slimeDefinition.IdentifiableId = Ids.LiquidSlimes.BLOOD_SLIME;
            // OBJECT
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
            slimeObject.name = "slimeBlood";
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<Identifiable>().id = Ids.LiquidSlimes.BLOOD_SLIME;
            slimeObject.AddComponent<PuddleSlimeScoot>();
            // .AddComponent for new components, below with UnityEngine shows how to destroy components, and get them is pretty obvious.
            UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
            // APPEARANCE
            Color SlimeColor = new Color32(138, 3, 3, 255);
            Color OtherColor = new Color32(255, 255, 255, 255);
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(bloodSlimeDefinition.AppearancesDefault[0]);
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
            {
                Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
                if (defaultMaterials != null && defaultMaterials.Length != 0)
                {
                    // SET MATERIALS HERE!! Btw above is if you want color vars-
                    Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PUDDLE_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                    material.SetColor("_TopColor", SlimeColor);
                    material.SetColor("_MiddleColor", SlimeColor);
                    material.SetColor("_BottomColor", SlimeColor);
                    material.SetColor("_SpecColor", SlimeColor);
                    // material.SetFloat("_Shininess", 1f); // idk what these are for tbh, but you can use it if you want
                    // material.SetFloat("_Gloss", 1f); // same thing here lol
                    slimeAppearanceStructure.DefaultMaterials[0] = material;
                }
            }
            SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", OtherColor);
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", OtherColor);
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", OtherColor);
                }
                if ((bool)slimeExpressionFace.Eyes)
                {   /* this is the default one in frosty's wiki I think
                slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(205, 190, 255, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(182, 170, 226, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(182, 170, 205, 255));
                */
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", OtherColor);
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", OtherColor);
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", OtherColor);
                }
            }
            slimeAppearance.Icon = OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_blood.png"));
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = SlimeColor,
                Middle = SlimeColor,
                Bottom = SlimeColor
            };
            PediaRegistry.RegisterIdEntry(Ids.LiquidSlimes.BLOOD_SLIME_ENTRY, OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_blood.png")));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            return (slimeDefinition, slimeObject);
        }
        public static (SlimeDefinition, GameObject) CreateInfectedBloodSlime(Identifiable.Id SlimeId, String SlimeName) // that red one lol
        {
            // DEFINE
            SlimeDefinition infectedBloodSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PUDDLE_SLIME); // make sure to make slimeNameDefiniton your slime name btw-
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(infectedBloodSlimeDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[2]
            {
                Ids.LiquidSlimes.INFECTED_BLOOD_SLIME,
                Ids.LiquidSlimes.INFECTED_BLOOD_SLIME
            };
            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[1]
            {
                SlimeEat.FoodGroup.NONTARRGOLD_SLIMES
            };
            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[1] { Ids.LiquidSlimes.BLOOD_SLIME }; // additional foods
            slimeDefinition.Diet.Favorites = new Identifiable.Id[1] // favorites
            {
                Identifiable.Id.TABBY_SLIME,
            };
            slimeDefinition.Diet.EatMap?.Clear(); // don't touch this unless your probably a little more advanced, idk
            // TARR SUPPORT (this is if you want it)
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TARR_SLIME);
            slimeByIdentifiableId.Diet.AdditionalFoods = new Identifiable.Id[1]
            {
                Ids.LiquidSlimes.INFECTED_BLOOD_SLIME
            };
            slimeDefinition.CanLargofy = false;
            slimeDefinition.FavoriteToys = new Identifiable.Id[1];
            slimeDefinition.Name = "Infected Blood Slime";
            slimeDefinition.IdentifiableId = Ids.LiquidSlimes.INFECTED_BLOOD_SLIME;
            // OBJECT
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
            slimeObject.name = "slimeInfectedBlood";
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<Identifiable>().id = Ids.LiquidSlimes.INFECTED_BLOOD_SLIME;
            slimeObject.AddComponent<PuddleSlimeScoot>();
            // .AddComponent for new components, below with UnityEngine shows how to destroy components, and get them is pretty obvious.
            UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
            // APPEARANCE
            Color SlimeColor = new Color32(125, 3, 3, 255);
            Color OtherColor = Color.black;
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(infectedBloodSlimeDefinition.AppearancesDefault[0]);
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
            {
                Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
                if (defaultMaterials != null && defaultMaterials.Length != 0)
                {
                    // SET MATERIALS HERE!! Btw above is if you want color vars-
                    Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PUDDLE_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                    material.SetColor("_TopColor", SlimeColor);
                    material.SetColor("_MiddleColor", SlimeColor);
                    material.SetColor("_BottomColor", SlimeColor);
                    material.SetColor("_SpecColor", SlimeColor);
                    // material.SetFloat("_Shininess", 1f); // idk what these are for tbh, but you can use it if you want
                    // material.SetFloat("_Gloss", 1f); // same thing here lol
                    slimeAppearanceStructure.DefaultMaterials[0] = material;
                }
            }
            SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", OtherColor);
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", OtherColor);
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", OtherColor);
                }
                if ((bool)slimeExpressionFace.Eyes)
                {   /* this is the default one in frosty's wiki I think
                slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(205, 190, 255, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(182, 170, 226, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(182, 170, 205, 255));
                */
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", OtherColor);
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", OtherColor);
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", OtherColor);
                }
            }
            slimeAppearance.Icon = OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_infected_blood.png"));
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = SlimeColor,
                Middle = SlimeColor,
                Bottom = SlimeColor
            };
            PediaRegistry.RegisterIdEntry(Ids.LiquidSlimes.INFECTED_BLOOD_SLIME_ENTRY, OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_infected_blood.png")));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            return (slimeDefinition, slimeObject);
        }
        public static (SlimeDefinition, GameObject) CreateOilSlime(Identifiable.Id SlimeId, String SlimeName) // that red one lol
        {
            // DEFINE
            SlimeDefinition oilSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PUDDLE_SLIME); // make sure to make slimeNameDefiniton your slime name btw-
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(oilSlimeDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[1]
            {
                Ids.LiquidSlimes.OIL_PLORT
            };
            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[2]
            {
                SlimeEat.FoodGroup.FRUIT,
                SlimeEat.FoodGroup.VEGGIES
            };
            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[0]; // additional foods
            slimeDefinition.Diet.Favorites = new Identifiable.Id[2] // favorites
            {
                Identifiable.Id.ONION_VEGGIE,
                Identifiable.Id.POGO_FRUIT
            };
            slimeDefinition.Diet.EatMap?.Clear(); // don't touch this unless your probably a little more advanced, idk
            // TARR SUPPORT (this is if you want it)
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TARR_SLIME);
            slimeByIdentifiableId.Diet.AdditionalFoods = new Identifiable.Id[1]
            {
                Ids.LiquidSlimes.OIL_SLIME
            };
            slimeDefinition.CanLargofy = false;
            slimeDefinition.FavoriteToys = new Identifiable.Id[1];
            slimeDefinition.Name = "Oil Slime";
            slimeDefinition.IdentifiableId = Ids.LiquidSlimes.OIL_SLIME;
            // OBJECT
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
            slimeObject.name = "slimeOil";
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<Identifiable>().id = Ids.LiquidSlimes.OIL_SLIME;
            slimeObject.AddComponent<PuddleSlimeScoot>();
            /*slimeObject.AddComponent<FeralizeOnLargoTransformed>();
            slimeObject.AddComponent<GotoPlayer>();
            slimeObject.AddComponent<AttackPlayer>();*/
            // .AddComponent for new components, below with UnityEngine shows how to destroy components, and get them is pretty obvious.
            UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
            // APPEARANCE
            Color SlimeColor = new Color32(219, 207, 92, 255);
            Color OtherColor = new Color32(55, 58, 54, 255);
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(oilSlimeDefinition.AppearancesDefault[0]);
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
            {
                Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
                if (defaultMaterials != null && defaultMaterials.Length != 0)
                {
                    // SET MATERIALS HERE!! Btw above is if you want color vars-
                    Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PUDDLE_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                    material.SetColor("_TopColor", SlimeColor);
                    material.SetColor("_MiddleColor", SlimeColor);
                    material.SetColor("_BottomColor", SlimeColor);
                    material.SetColor("_SpecColor", SlimeColor);
                    // material.SetFloat("_Shininess", 1f); // idk what these are for tbh, but you can use it if you want
                    // material.SetFloat("_Gloss", 1f); // same thing here lol
                    slimeAppearanceStructure.DefaultMaterials[0] = material;
                }
            }
            SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", OtherColor);
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", OtherColor);
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", OtherColor);
                }
                if ((bool)slimeExpressionFace.Eyes)
                {   /* this is the default one in frosty's wiki I think
                slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(205, 190, 255, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(182, 170, 226, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(182, 170, 205, 255));
                */
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", OtherColor);
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", OtherColor);
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", OtherColor);
                }
            }
            slimeAppearance.Icon = OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_oil.png"));
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = SlimeColor,
                Middle = SlimeColor,
                Bottom = SlimeColor
            };
            PediaRegistry.RegisterIdEntry(Ids.LiquidSlimes.OIL_SLIME_ENTRY, OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_oil.png")));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            return (slimeDefinition, slimeObject);
        }
    }
}
