// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.Runtime.Serialization;

namespace PostProcessor.Model
{
    [DataContract(Name = "LVAObject")]
    public class LVAObject
    {
        [DataMember(Name = "obj_id")]
        public int ObjID { get; set; }

        [DataMember(Name = "obj_name")]
        public string ObjName { get; set; }

        [DataMember(Name = "bbox")]
        public int[] Bbox { get; set; }

        [DataMember(Name = "prob")]
        public double Prob { get; set; }
    }
}