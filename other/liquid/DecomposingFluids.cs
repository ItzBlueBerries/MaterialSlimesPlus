using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MaterialSlimesPlus.other.liquid
{
    class DecomposingFluids
    {
        static public void LoadDecomposingFluids()
        {
            GameObject decomposingFluids = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.DEEP_BRINE_CRAFT));
            decomposingFluids.GetComponent<Identifiable>().id = Ids.LiquidSlimes.DECOMPOSING_FLUIDS_CRAFT;
            decomposingFluids.name = "resourceDecomposingFluids";

            Material BloodMaterial = Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.LiquidSlimes.BLOOD_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
            Material InfectedBloodMaterial = Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Ids.LiquidSlimes.INFECTED_BLOOD_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);

            decomposingFluids.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().material = InfectedBloodMaterial;
            decomposingFluids.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = BloodMaterial;

            LookupRegistry.RegisterIdentifiablePrefab(decomposingFluids);
            AmmoRegistry.RegisterSiloAmmo((SiloStorage.StorageType x) => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.CRAFTING, Ids.LiquidSlimes.DECOMPOSING_FLUIDS_CRAFT);
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Ids.LiquidSlimes.DECOMPOSING_FLUIDS_CRAFT));
            AmmoRegistry.RegisterRefineryResource(Ids.LiquidSlimes.DECOMPOSING_FLUIDS_CRAFT);
            LookupRegistry.RegisterVacEntry(Ids.LiquidSlimes.DECOMPOSING_FLUIDS_CRAFT, Color.red, OtherFunc.MSPCreateSprite(OtherFunc.MSPLoadImage("assets.liquid.liquid_decomposing_fluids.png")));
            GameObject prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Ids.LiquidSlimes.DECOMPOSING_FLUIDS_CRAFT);
            prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            // risky material extractor stuff
            Extractor component = SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition((Gadget.Id)Enum.Parse(typeof(Gadget.Id), "RISKY_MATERIAL_EXTRACTOR")).prefab.GetComponent<Extractor>();
            Extractor.ProduceEntry item = new Extractor.ProduceEntry
            {
                id = Ids.LiquidSlimes.DECOMPOSING_FLUIDS_CRAFT,
                weight = 4f, //the luck/probability you have to get it, here it's 10%
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
        }
    }
}
