﻿using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class StatusData
    {   
        public List<Dictionary<string, ColorAssignment>> lstypes { get; set; }
        public List<Dictionary<string, ColorAssignment> >codes { get; set; }
    }
}