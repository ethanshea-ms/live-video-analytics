// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.Runtime.Serialization;

namespace PostProcessor.Model
{
    [DataContract(Name = "LVADetectionResults")]
    public class LVADetectionResults
    {
        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "time")]
        public string Time { get; set; }
        
        [DataMember(Name = "object_count")]
        public int ObjectCount { get; set; }

        [DataMember(Name = "objects")]
        public LVAObject[] Objects { get; set; }
    }
}