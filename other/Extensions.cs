﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSlimesPlus
{
    internal static class Extension
    {
        public static bool Matches(this SlimeDefinition a, Identifiable.Id id)
        {
            return a.IdentifiableId == id || (a.BaseSlimes != null && Enumerable.Any<SlimeDefinition>(a.BaseSlimes, (SlimeDefinition x) => x.IdentifiableId == id));
        }
    }
}
