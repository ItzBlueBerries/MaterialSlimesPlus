using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRML.Utils.Enum;

[EnumHolder]
internal class Ids
{
    [EnumHolder]
    internal class LiquidSlimes
    {
        // blood

        public static readonly Identifiable.Id BLOOD_SLIME;

        public static readonly Identifiable.Id BLOOD_PLORT;

        // infected blood

        public static readonly Identifiable.Id INFECTED_BLOOD_SLIME;

        public static readonly Identifiable.Id INFECTED_BLOOD_PLORT;

        // oil

        public static readonly Identifiable.Id OIL_SLIME;

        public static readonly Identifiable.Id OIL_PLORT;

        // entries/slimepedia

        public static readonly PediaDirector.Id BLOOD_SLIME_ENTRY;

        public static readonly PediaDirector.Id INFECTED_BLOOD_SLIME_ENTRY;

        public static readonly PediaDirector.Id OIL_SLIME_ENTRY;

        // items

        public static readonly Identifiable.Id DECOMPOSING_FLUIDS_CRAFT;

        public static readonly PediaDirector.Id DECOMPOSING_FLUIDS_ENTRY;
    }
}

[EnumHolder]
internal class largoIds
{

    [EnumHolder]
    internal class LiquidSlimes
    {
        public static readonly Identifiable.Id MEDIUM_OIL_LARGO;

        public static readonly Identifiable.Id LARGE_OIL_LARGO;

        public static readonly Identifiable.Id EXL_OIL_LARGO;

        public static readonly Identifiable.Id EVL_OIL_LARGO;

        public static readonly Identifiable.Id MEGA_OIL_LARGO;
    }
}

[EnumHolder]
internal class gadgetIds
{

    [EnumHolder]
    internal class LiquidSlimes
    {
        public static readonly Gadget.Id OIL_EXCHANGER_BASIC;

        public static readonly Gadget.Id OIL_EXCHANGER_ADVANCED;

        public static readonly Gadget.Id OIL_COMBINER;
    }
}