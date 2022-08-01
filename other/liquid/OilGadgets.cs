using System;
using System.IO;
using System.Reflection;
using MonomiPark.SlimeRancher.DataModel;
using SRML.SR;
using SRML.SR.SaveSystem;
using SRML.SR.Translation;
using SRML.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MaterialSlimesPlus.other.liquid
{
    public class OilGadgets : GadgetModel, ISerializableModel
    {

        private int Version
        {
            get
            {
                return 0;
            }
        }

        public OilGadgets(Gadget.Id ident, string siteId, Transform transform) : base(ident, siteId, transform)
        {
        }

        public void LoadData(BinaryReader reader)
        {
            int num = reader.ReadInt32();
            this.testProperty = reader.ReadSingle();
        }

        public void WriteData(BinaryWriter writer)
        {
            writer.Write(this.Version);
            writer.Write(this.testProperty);
        }

        public float testProperty;


        static public void LoadOilExchangerB() // basic
        {
            // OBJECTS, PRODUCES, ETC
            GameObject gadgetObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.EXTRACTOR_PUMP_NOVICE).prefab);

            GameObject fx = gadgetObject.GetComponent<Extractor>().produces[0].spawnFX;

            var itemProduced = new Extractor.ProduceEntry[]
            {
                new Extractor.ProduceEntry() {
                    id = Ids.LiquidSlimes.OIL_PLORT,
                    weight = 10f,
                    restrictZone = false,
                    spawnFX = fx
                },
                new Extractor.ProduceEntry() {
                    id = Ids.LiquidSlimes.OIL_SLIME,
                    weight = 8f,
                    zone = ZoneDirector.Zone.MOSS,
                    restrictZone = true,
                    spawnFX = fx
                },
            };

            // GADGET COMPONENTS
            gadgetObject.GetComponent<Gadget>().id = gadgetIds.LiquidSlimes.OIL_EXCHANGER_BASIC;
            gadgetObject.GetComponent<Extractor>().produces = itemProduced;
            gadgetObject.GetComponent<Extractor>().cycles = 1;
            gadgetObject.GetComponent<Extractor>().produceMin = 4;
            gadgetObject.GetComponent<Extractor>().produceMax = 8;
            gadgetObject.GetComponent<Extractor>().hoursPerCycle = 2.5f;
            // gadgetObject.GetComponent<Extractor>().infiniteCycles = true;
            // UnityEngine.Object.Destroy(gadgetObject.GetComponent<Extractor>());


            // COLORING GADGET
            Color SecondColor = new Color32(219, 207, 92, 255);
            Color FirstColor = new Color32(55, 58, 54, 255);

            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material = Object.Instantiate(gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material = Object.Instantiate(gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material = Object.Instantiate(gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material);

            // recolor x4 shader thingy (core)
            // red
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color00", SecondColor);
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color01", FirstColor);
            // green
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color10", SecondColor);
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color11", FirstColor);
            // blue
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color20", SecondColor);
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color21", FirstColor);
            // black
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color30", SecondColor);
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color31", FirstColor);

            // recolor x4 shader thingy (ext)
            // red
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color00", SecondColor);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color01", FirstColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color00", SecondColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color01", FirstColor);
            // green
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color10", SecondColor);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color11", FirstColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color10", SecondColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color11", FirstColor);
            // blue
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color20", SecondColor);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color21", FirstColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color20", SecondColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color21", FirstColor);
            // black
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color30", SecondColor);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color31", FirstColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color30", SecondColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color31", FirstColor);


            // REGISTER THE GADGET
            Sprite GadgetIcon = OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_oilexchanger_basic.png"));
            LookupRegistry.RegisterGadget(new GadgetDefinition
            {
                prefab = gadgetObject, //Just use another, already, existing GameObject of a gadget. Tutorials about custom models ASAP.
                id = gadgetIds.LiquidSlimes.OIL_EXCHANGER_BASIC,
                pediaLink = PediaDirector.Id.EXTRACTORS,
                blueprintCost = 650,
                buyCountLimit = 10,
                icon = GadgetIcon,
                craftCosts = new GadgetDefinition.CraftCost[]
                {
                    new GadgetDefinition.CraftCost
                    {
                        amount = 1,
                        id = largoIds.LiquidSlimes.LARGE_OIL_LARGO
                    },
                    new GadgetDefinition.CraftCost
                    {
                        amount = 1,
                        id = Identifiable.Id.PUDDLE_SLIME
                    },
                },
            });

            // ADD CLASS, TRANSLATION, BLUEPRINT, OTHER STUFF THAT ENDS IT OFF
            Gadget.EXTRACTOR_CLASS.Add(gadgetIds.LiquidSlimes.OIL_EXCHANGER_BASIC);

            new GadgetTranslation(gadgetIds.LiquidSlimes.OIL_EXCHANGER_BASIC).SetNameTranslation("Oil Exchanger : Basic").SetDescriptionTranslation("Exchanges Large Oil Slimes that have been combined from Oil Slimes into Oil Plorts & Oil Slimes. Last one cycle(s).");

            // SaveRegistry.RegisterSerializableGadgetModel<Squeezer>(0);
            // DataModelRegistry.RegisterCustomGadgetModel(gadgetIds.SQUEEZER, typeof(Squeezer));
            GadgetRegistry.RegisterBlueprintLock(gadgetIds.LiquidSlimes.OIL_EXCHANGER_BASIC, x => x.CreateBasicLock(gadgetIds.LiquidSlimes.OIL_EXCHANGER_BASIC, Gadget.Id.NONE, ProgressDirector.ProgressType.UNLOCK_MOSS, 1f)); //Replace 'YOUR_ZONE' with the Zone you want.
        }

        static public void LoadOilExchangerA() // basic
        {
            // OBJECTS, PRODUCES, ETC
            GameObject gadgetObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.EXTRACTOR_PUMP_ABYSSAL).prefab);

            GameObject fx = gadgetObject.GetComponent<Extractor>().produces[0].spawnFX;

            var itemProduced = new Extractor.ProduceEntry[]
            {
                new Extractor.ProduceEntry() {
                    id = Ids.LiquidSlimes.OIL_PLORT,
                    weight = 12f,
                    restrictZone = false,
                    spawnFX = fx
                },
                new Extractor.ProduceEntry() {
                    id = Ids.LiquidSlimes.OIL_SLIME,
                    weight = 10f,
                    zone = ZoneDirector.Zone.MOSS,
                    restrictZone = true,
                    spawnFX = fx
                },
            };

            // GADGET COMPONENTS
            gadgetObject.GetComponent<Gadget>().id = gadgetIds.LiquidSlimes.OIL_EXCHANGER_ADVANCED;
            gadgetObject.GetComponent<Extractor>().produces = itemProduced;
            gadgetObject.GetComponent<Extractor>().cycles = 1;
            gadgetObject.GetComponent<Extractor>().produceMin = 6;
            gadgetObject.GetComponent<Extractor>().produceMax = 12;
            gadgetObject.GetComponent<Extractor>().hoursPerCycle = 3.5f;
            // gadgetObject.GetComponent<Extractor>().infiniteCycles = true;
            // UnityEngine.Object.Destroy(gadgetObject.GetComponent<Extractor>());


            // COLORING GADGET
            Color SecondColor = new Color32(219, 207, 92, 255);
            Color FirstColor = new Color32(55, 58, 54, 255);

            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material = Object.Instantiate(gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material = Object.Instantiate(gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material = Object.Instantiate(gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material);

            // recolor x4 shader thingy (core)
            // red
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color00", SecondColor);
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color01", FirstColor);
            // green
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color10", SecondColor);
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color11", FirstColor);
            // blue
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color20", SecondColor);
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color21", FirstColor);
            // black
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color30", SecondColor);
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color31", FirstColor);

            // recolor x4 shader thingy (ext)
            // red
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color00", SecondColor);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color01", FirstColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color00", SecondColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color01", FirstColor);
            // green
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color10", SecondColor);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color11", FirstColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color10", SecondColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color11", FirstColor);
            // blue
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color20", SecondColor);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color21", FirstColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color20", SecondColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color21", FirstColor);
            // black
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color30", SecondColor);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color31", FirstColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color30", SecondColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color31", FirstColor);


            // REGISTER THE GADGET
            Sprite GadgetIcon = OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_oilexchanger_advanced.png"));
            LookupRegistry.RegisterGadget(new GadgetDefinition
            {
                prefab = gadgetObject, //Just use another, already, existing GameObject of a gadget. Tutorials about custom models ASAP.
                id = gadgetIds.LiquidSlimes.OIL_EXCHANGER_ADVANCED,
                pediaLink = PediaDirector.Id.EXTRACTORS,
                blueprintCost = 850,
                buyCountLimit = 5,
                icon = GadgetIcon,
                craftCosts = new GadgetDefinition.CraftCost[]
                {
                    new GadgetDefinition.CraftCost
                    {
                        amount = 1,
                        id = largoIds.LiquidSlimes.LARGE_OIL_LARGO
                    },
                    new GadgetDefinition.CraftCost
                    {
                        amount = 2,
                        id = Identifiable.Id.PUDDLE_SLIME,
                    },
                },
            });

            // ADD CLASS, TRANSLATION, BLUEPRINT, OTHER STUFF THAT ENDS IT OFF
            Gadget.EXTRACTOR_CLASS.Add(gadgetIds.LiquidSlimes.OIL_EXCHANGER_ADVANCED);

            new GadgetTranslation(gadgetIds.LiquidSlimes.OIL_EXCHANGER_ADVANCED).SetNameTranslation("Oil Exchanger : Advanced").SetDescriptionTranslation("Exchanges Large Oil Slimes that have been combined from Oil Slimes into Oil Plorts & Oil Slimes. Produces more resources then Basic. Last one cycle(s).");

            // SaveRegistry.RegisterSerializableGadgetModel<Squeezer>(0);
            // DataModelRegistry.RegisterCustomGadgetModel(gadgetIds.SQUEEZER, typeof(Squeezer));
            GadgetRegistry.RegisterBlueprintLock(gadgetIds.LiquidSlimes.OIL_EXCHANGER_ADVANCED, x => x.CreateBasicLock(gadgetIds.LiquidSlimes.OIL_EXCHANGER_ADVANCED, Gadget.Id.NONE, ProgressDirector.ProgressType.UNLOCK_MOSS, 2f)); //Replace 'YOUR_ZONE' with the Zone you want.
        }
        static public void LoadOilCombiner() // basic
        {
            // OBJECTS, PRODUCES, ETC
            GameObject gadgetObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.EXTRACTOR_PUMP_ABYSSAL).prefab);

            GameObject fx = gadgetObject.GetComponent<Extractor>().produces[0].spawnFX;

            var itemProduced = new Extractor.ProduceEntry[]
            {
                new Extractor.ProduceEntry()
                {
                    id = Ids.LiquidSlimes.OIL_PLORT,
                    weight = 1f,
                    restrictZone = false,
                    spawnFX = fx
                },
                new Extractor.ProduceEntry() {
                    id = Ids.LiquidSlimes.OIL_SLIME,
                    weight = 12f,
                    zone = ZoneDirector.Zone.MOSS,
                    restrictZone = true,
                    spawnFX = fx
                },
                new Extractor.ProduceEntry() {
                    id = largoIds.LiquidSlimes.MEDIUM_OIL_LARGO,
                    weight = 6f,
                    zone = ZoneDirector.Zone.MOSS,
                    restrictZone = true,
                    spawnFX = fx
                },
            };

            // GADGET COMPONENTS
            gadgetObject.GetComponent<Gadget>().id = gadgetIds.LiquidSlimes.OIL_COMBINER;
            gadgetObject.GetComponent<Extractor>().produces = itemProduced;
            gadgetObject.GetComponent<Extractor>().cycles = 1;
            gadgetObject.GetComponent<Extractor>().produceMin = 12;
            gadgetObject.GetComponent<Extractor>().produceMax = 24;
            gadgetObject.GetComponent<Extractor>().hoursPerCycle = 5.5f;
            // gadgetObject.GetComponent<Extractor>().infiniteCycles = true;
            // UnityEngine.Object.Destroy(gadgetObject.GetComponent<Extractor>());


            // COLORING GADGET
            Color FirstColor = new Color32(219, 207, 92, 255);
            Color SecondColor = new Color32(255, 255, 255, 255);

            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material = Object.Instantiate(gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material = Object.Instantiate(gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material = Object.Instantiate(gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material);

            // recolor x4 shader thingy (core)
            // red
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color00", SecondColor);
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color01", FirstColor);
            // green
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color10", SecondColor);
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color11", FirstColor);
            // blue
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color20", SecondColor);
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color21", FirstColor);
            // black
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color30", SecondColor);
            gadgetObject.transform.Find("core").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color31", FirstColor);

            // recolor x4 shader thingy (ext)
            // red
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color00", SecondColor);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color01", FirstColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color00", SecondColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color01", FirstColor);
            // green
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color10", SecondColor);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color11", FirstColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color10", SecondColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color11", FirstColor);
            // blue
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color20", SecondColor);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color21", FirstColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color20", SecondColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color21", FirstColor);
            // black
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color30", SecondColor);
            gadgetObject.transform.Find("ext_pump23").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color31", FirstColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color30", SecondColor);
            gadgetObject.transform.Find("ext_r3").GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color31", FirstColor);


            // REGISTER THE GADGET
            Sprite GadgetIcon = OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_oilcombiner.png"));
            LookupRegistry.RegisterGadget(new GadgetDefinition
            {
                prefab = gadgetObject, //Just use another, already, existing GameObject of a gadget. Tutorials about custom models ASAP.
                id = gadgetIds.LiquidSlimes.OIL_COMBINER,
                pediaLink = PediaDirector.Id.EXTRACTORS,
                blueprintCost = 1250,
                buyCountLimit = 3,
                icon = GadgetIcon,
                craftCosts = new GadgetDefinition.CraftCost[]
                {
                    new GadgetDefinition.CraftCost
                    {
                        amount = 105,
                        id = Ids.LiquidSlimes.OIL_PLORT,
                    },
                },
            });

            // ADD CLASS, TRANSLATION, BLUEPRINT, OTHER STUFF THAT ENDS IT OFF
            Gadget.EXTRACTOR_CLASS.Add(gadgetIds.LiquidSlimes.OIL_COMBINER);

            new GadgetTranslation(gadgetIds.LiquidSlimes.OIL_COMBINER).SetNameTranslation("Oil Combiner").SetDescriptionTranslation("Creates Oil Slimes from Oil Plorts. Produces a lot of resources, this could include Medium Oil Slimes or Oil Plorts (rarely). Last one cycle(s).");

            // SaveRegistry.RegisterSerializableGadgetModel<Squeezer>(0);
            // DataModelRegistry.RegisterCustomGadgetModel(gadgetIds.SQUEEZER, typeof(Squeezer));
            GadgetRegistry.RegisterBlueprintLock(gadgetIds.LiquidSlimes.OIL_COMBINER, x => x.CreateBasicLock(gadgetIds.LiquidSlimes.OIL_COMBINER, Gadget.Id.NONE, ProgressDirector.ProgressType.UNLOCK_MOSS, 4f)); //Replace 'YOUR_ZONE' with the Zone you want.
        }
    }
}