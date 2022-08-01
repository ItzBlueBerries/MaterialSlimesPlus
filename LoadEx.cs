using SRML.SR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Reflection;
using MaterialSlimesPlus.EX1;
using MaterialSlimesPlus.other.liquid;
using SRML.SR.Translation;
using MonomiPark.SlimeRancher.Regions;

namespace MaterialSlimesPlus.EX
{                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
    class LoadExtensions
    {
        static public void PreloadEx() 
        {
            // other stuff ig
            Identifiable.CRAFT_CLASS.Add(Identifiable.Id.PUDDLE_SLIME);
            Identifiable.CRAFT_CLASS.Add(largoIds.LiquidSlimes.LARGE_OIL_LARGO);

            // other translations ig
            TranslationPatcher.AddActorTranslation("l." + Ids.LiquidSlimes.DECOMPOSING_FLUIDS_CRAFT.ToString().ToLower(), "Decomposing Fluids");

            // pedia translations ig
            // blood slime
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, Ids.LiquidSlimes.BLOOD_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(Ids.LiquidSlimes.BLOOD_SLIME_ENTRY, Ids.LiquidSlimes.BLOOD_SLIME);
            PediaRegistry.SetPediaCategory(Ids.LiquidSlimes.BLOOD_SLIME_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(Ids.LiquidSlimes.BLOOD_SLIME_ENTRY)
                .SetTitleTranslation("Blood Slime")
                .SetIntroTranslation("Take photos of its slime splats, they look like a crime scene.")
                .SetDietTranslation("Slimes, Meat")
                .SetFavoriteTranslation("Tabby Slime, Painted Hen")
                .SetSlimeologyTranslation("These slimes definitely seem interesting.. aren't they? They are the Blood Slimes, leftover blood of an existing slime when fed Decomposing Fluids. These slimes can be eaten by other slimes, which will make them produce Blood Plorts.. although there is always a possibility that an Infected Blood Plort will appear. When this happens, slimes can eat these plorts and become Infected Blood Slimes, more info on them at their Slimepedias. These slimes will also duplicate themself twice if fed, which is them reproducing their own blood. Even more Blood Slimes will appear if they eat their favorites that is.")
                .SetRisksTranslation("Slimes that eat Blood Slimes could produce Infected Blood Plorts instead of Blood Plorts sometimes. This could be bad in fact, but also good if you want to ranch them for Infected Blood Plorts.. which may or may not have more values depending on the Plort Market.")
                .SetPlortonomicsTranslation("Blood Plorts do not do anything special really, they are just sellable for a good amount of newbucks. Infected Blood Plorts.. well that's another story.");
            // TranslationPatcher.AddPediaTranslation("m.obtained_by.blood_slime_entry", "Decomposing Fluids. (Obtained from Material Extractor)");
            
            // infected blood slime
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, Ids.LiquidSlimes.INFECTED_BLOOD_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(Ids.LiquidSlimes.INFECTED_BLOOD_SLIME_ENTRY, Ids.LiquidSlimes.INFECTED_BLOOD_SLIME);
            PediaRegistry.SetPediaCategory(Ids.LiquidSlimes.INFECTED_BLOOD_SLIME_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(Ids.LiquidSlimes.INFECTED_BLOOD_SLIME_ENTRY)
                .SetTitleTranslation("Infected Blood Slime")
                .SetIntroTranslation("How disgusting.. I'm sorry, but infected blood is not something good.")
                .SetDietTranslation("Slimes")
                .SetFavoriteTranslation("Tabby Slime")
                .SetSlimeologyTranslation("This may be wrong to say about a slime, but its materials are absolutely disgusting. Infected Blood Slimes are infected versions of the Blood Slime. They eat slimes then reproduce by duplicating themself twice, which creates more Infected Blood Slimes. If they eat their favorites, it just creates even more.. they could be ranchable however, if you'd like to ranch their plorts. Any slime besides Blood Slimes that eats these slimes will become Infected Blood Slimes as well, same with Infected Blood Plorts.")
                .SetRisksTranslation("Infected Blood Slimes should be kept away from other slimes, otherwise the slimes will eat them. This will cause them to become Infected Blood Slimes, somewhat like the Blood Slimes. Infected Blood Plorts will also cause slimes to become Infected Blood Slimes, taking over their body using their infected blood.")
                .SetPlortonomicsTranslation("Infected Blood Plorts have somewhat value, but is mainly a threat to other slimes. Its been said multiple times on why.");
            // TranslationPatcher.AddPediaTranslation("m.obtained_by.infected_blood_slime_entry", "Infected Blood Plorts. (Obtained from Slimes that eat Blood Slimes)");

            // oil slime
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, Ids.LiquidSlimes.OIL_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(Ids.LiquidSlimes.OIL_SLIME_ENTRY, Ids.LiquidSlimes.OIL_SLIME);
            PediaRegistry.SetPediaCategory(Ids.LiquidSlimes.OIL_SLIME_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(Ids.LiquidSlimes.OIL_SLIME_ENTRY)
                .SetTitleTranslation("Oil Slime")
                .SetIntroTranslation("These guys will combine until they're huge enough to crush you!")
                .SetDietTranslation("Fruits, Veggies")
                .SetFavoriteTranslation("Odd Onion, Pogofruit")
                .SetSlimeologyTranslation("Oil Slimes seem very cute, don't they? Well eventually they get tiresome. Oil Slimes LOVE sticking together, sometimes they won't bother but most of the time.. they'll go for it. Sticking together will combine them into an even larger Oil Slime, some of these larger variations actually produce more resources or even Oil Slimes! Although, some are too big to handle.. so its best to stay on the Medium - Large range. If you want to ranch the regular Oil Slimes, its best to keep them separated or different sizes. You can exchange Large Oil Slimes for Oil Plorts/Slimes at an Oil Exchanger in Slime Science as well!")
                .SetRisksTranslation("Oil Slimes don't really have any risk, besides be cautious of how you handle them. If they get too big and you can't control them anymore, it could be very bad for you. Some Oil Slime sizes produce way too much which could result in a lot more Oil Slime combinations, etc. Luckily, the Oil Slimes don't go too big.. but they go big enough to cause trouble.")
                .SetPlortonomicsTranslation("Oil Plorts aren't anything special really, they have good value. Probably can get a ton of them from an Oil Exchanger.");

            // item translations ig
            // decomposing fluids apparently
            PediaRegistry.RegisterIdentifiableMapping(Ids.LiquidSlimes.DECOMPOSING_FLUIDS_ENTRY, Ids.LiquidSlimes.DECOMPOSING_FLUIDS_CRAFT);
            PediaRegistry.RegisterIdEntry(Ids.LiquidSlimes.DECOMPOSING_FLUIDS_ENTRY, OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_decomposing_fluids.png")));
            PediaRegistry.SetPediaCategory(Ids.LiquidSlimes.DECOMPOSING_FLUIDS_ENTRY, (PediaRegistry.PediaCategory)2);
            new SlimePediaEntryTranslation(Ids.LiquidSlimes.DECOMPOSING_FLUIDS_ENTRY).SetTitleTranslation("Decomposing Fluids").SetIntroTranslation("Deadly or Not Deadly? Sometimes you just can't really tell.");
            TranslationPatcher.AddPediaTranslation("m.resource_type.decomposing_fluids_entry", "Slime Science Material");
            TranslationPatcher.AddPediaTranslation("m.favored_by.decomposing_fluids_entry", "All Slimes. (Excluding Blood & Infected Blood Slimes)");
            TranslationPatcher.AddPediaTranslation("m.desc.decomposing_fluids_entry", "Decomposing Fluids do exactly what the name says, it will decompose a slimes body.. all the way until its just blood left. Although, it gives you a blood slime so- is it that deadly?");

            // plort translations ig
            // red one
            TranslationPatcher.AddActorTranslation("l." + Ids.LiquidSlimes.BLOOD_PLORT.ToString().ToLower(), "Blood Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.LiquidSlimes.BLOOD_PLORT);
            Identifiable.PLORT_CLASS.Add(Ids.LiquidSlimes.BLOOD_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(Ids.LiquidSlimes.BLOOD_PLORT);

            // infected red one
            TranslationPatcher.AddActorTranslation("l." + Ids.LiquidSlimes.INFECTED_BLOOD_PLORT.ToString().ToLower(), "Infected Blood Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.LiquidSlimes.INFECTED_BLOOD_PLORT);
            Identifiable.PLORT_CLASS.Add(Ids.LiquidSlimes.INFECTED_BLOOD_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(Ids.LiquidSlimes.INFECTED_BLOOD_PLORT);

            // some kinda oil one lol
            TranslationPatcher.AddActorTranslation("l." + Ids.LiquidSlimes.OIL_PLORT.ToString().ToLower(), "Oil Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.LiquidSlimes.OIL_PLORT);
            Identifiable.PLORT_CLASS.Add(Ids.LiquidSlimes.OIL_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(Ids.LiquidSlimes.OIL_PLORT);

            // spawners
            // oil slime spawner
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.MOSS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.LiquidSlimes.OIL_SLIME),
                                weight = 0.05f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });

            // medium oil slime spawner
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.MOSS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(largoIds.LiquidSlimes.MEDIUM_OIL_LARGO),
                                weight = 0.1f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
        }

        static public void LoadEx()
        {
            // other funcs and all

            // red liquid ig
            (SlimeDefinition, GameObject) BloodTuple = LiquidSlimes.CreateBloodSlime(Ids.LiquidSlimes.BLOOD_SLIME, "Blood Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition BloodDef = BloodTuple.Item1;
            GameObject BloodObj = BloodTuple.Item2;

            Color LS_SlimeColor1 = new Color32(138, 3, 3, 255); // blood slime color

            BloodObj.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, BloodObj);
            LookupRegistry.RegisterVacEntry(Ids.LiquidSlimes.BLOOD_SLIME, LS_SlimeColor1, OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_blood.png")));
            TranslationPatcher.AddPediaTranslation("t." + Ids.LiquidSlimes.BLOOD_SLIME.ToString().ToLower(), "Blood Slime");

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(BloodObj);
            SlimeRegistry.RegisterSlimeDefinition(BloodDef);


            (SlimeDefinition, GameObject) InfectedBloodTuple = LiquidSlimes.CreateInfectedBloodSlime(Ids.LiquidSlimes.INFECTED_BLOOD_SLIME, "Infected Blood Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition InfectedBloodDef = InfectedBloodTuple.Item1;
            GameObject InfectedBloodObj = InfectedBloodTuple.Item2;

            Color LS_SlimeColor2 = new Color32(125, 3, 3, 255); // infected blood slime color

            InfectedBloodObj.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, InfectedBloodObj);
            LookupRegistry.RegisterVacEntry(Ids.LiquidSlimes.INFECTED_BLOOD_SLIME, LS_SlimeColor2, OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_infected_blood.png")));
            TranslationPatcher.AddPediaTranslation("t." + Ids.LiquidSlimes.INFECTED_BLOOD_SLIME.ToString().ToLower(), "Infected Blood Slime");

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(InfectedBloodObj);
            SlimeRegistry.RegisterSlimeDefinition(InfectedBloodDef);


            // red liquid plorts ig
            GameObject BloodPlortTuple = LiquidPlorts.BloodPlort();

            GameObject BloodPlortObj = BloodPlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, BloodPlortObj);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite BloodPlortIcon = OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_blood_plort.png"));
            Color LS_PlortColor1 = new Color32(138, 3, 3, 255); // blood plort color
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.LiquidSlimes.BLOOD_PLORT, LS_PlortColor1, BloodPlortIcon));
            AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, Ids.LiquidSlimes.BLOOD_PLORT);

            float plortPrice1 = 50f; //Starting price for plort
            float plortSaturated1 = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(Ids.LiquidSlimes.BLOOD_PLORT, plortPrice1, plortSaturated1); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(Ids.LiquidSlimes.BLOOD_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(Ids.LiquidSlimes.BLOOD_PLORT);


            GameObject InfectedBloodPlortTuple = LiquidPlorts.InfectedBloodPlort();

            GameObject InfectedBloodPlortObj = InfectedBloodPlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, InfectedBloodPlortObj);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite InfectedBloodPlortIcon = OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_infected_blood_plort.png"));
            Color LS_PlortColor2 = new Color32(125, 3, 3, 255); // infected blood plort color
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.LiquidSlimes.INFECTED_BLOOD_PLORT, LS_PlortColor2, InfectedBloodPlortIcon));
            AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, Ids.LiquidSlimes.INFECTED_BLOOD_PLORT);

            float plortPrice2 = 30f; //Starting price for plort
            float plortSaturated2 = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(Ids.LiquidSlimes.INFECTED_BLOOD_PLORT, plortPrice2, plortSaturated2); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(Ids.LiquidSlimes.INFECTED_BLOOD_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(Ids.LiquidSlimes.INFECTED_BLOOD_PLORT);


            // oil liquid ig
            (SlimeDefinition, GameObject) OilTuple = LiquidSlimes.CreateOilSlime(Ids.LiquidSlimes.OIL_SLIME, "Oil Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition OilDef = OilTuple.Item1;
            GameObject OilObj = OilTuple.Item2;

            Color LS_SlimeColor3 = new Color32(219, 207, 92, 255); // blood slime color

            OilObj.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, OilObj);
            LookupRegistry.RegisterVacEntry(Ids.LiquidSlimes.OIL_SLIME, LS_SlimeColor3, OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_oil.png")));
            TranslationPatcher.AddPediaTranslation("t." + Ids.LiquidSlimes.OIL_SLIME.ToString().ToLower(), "Oil Slime");

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(OilObj);
            SlimeRegistry.RegisterSlimeDefinition(OilDef);


            // oil liquid plorts ig
            GameObject OilPlortTuple = LiquidPlorts.OilPlort();

            GameObject OilPlortObj = OilPlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, OilPlortObj);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite OilPlortIcon = OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_oil_plort.png"));
            Color LS_PlortColor3 = new Color32(219, 207, 92, 255); // infected blood plort color
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.LiquidSlimes.OIL_PLORT, LS_PlortColor3, OilPlortIcon));
            AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, Ids.LiquidSlimes.OIL_PLORT);

            float plortPrice3 = 48f; //Starting price for plort
            float plortSaturated3 = 3f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(Ids.LiquidSlimes.OIL_PLORT, plortPrice3, plortSaturated3); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(Ids.LiquidSlimes.OIL_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(Ids.LiquidSlimes.OIL_PLORT);

            // even other funcs and all
            LargoLibFunc.LoadLargoLib(); // largo stuff
            OilGadgets.LoadOilExchangerB(); // basic oil exchanger
            OilGadgets.LoadOilExchangerA(); // advanced oil exchanger
            OilGadgets.LoadOilCombiner(); // oil combiner

            return;
        }

        static public void PostloadEx()
        {
            // discovery 3000
            Extractor component = SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition((Gadget.Id)Enum.Parse(typeof(Gadget.Id), "DISCOVERY_3000")).prefab.GetComponent<Extractor>();
            Extractor.ProduceEntry item = new Extractor.ProduceEntry
            {
                id = Ids.LiquidSlimes.OIL_SLIME,
                weight = 1f, //the luck/probability you have to get it, here it's 10%
                restrictZone = false,
                spawnFX = component.produces[0].spawnFX //The effects that comes once your item gets extracted (particles)
            };
            List<Extractor.ProduceEntry> list = new List<Extractor.ProduceEntry>(); //Create a new list
            foreach (Extractor.ProduceEntry item2 in component.produces) //For each thing it produces
            {
                list.Add(item2); //Add it to the list
            }
            list.Add(item); //Add your custom 'Extractor.ProduceEntry' to the list
            component.produces = list.ToArray(); //Set the new list

            DecomposingFluids.LoadDecomposingFluids(); 
        }
    }
}
