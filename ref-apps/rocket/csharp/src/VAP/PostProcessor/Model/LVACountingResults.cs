// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.Runtime.Serialization;
using System;
using System.Collections.Generic;

namespace PostProcessor.Model
{
    [DataContract(Name = "LVACountingResults")]
    public class LVACountingResults
    {
        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        [DataMember(Name = "time")]
        public double ProcessTime { get; set; }

        [DataMember(Name = "result")]
        public List<LineResult> Result { get; set; }

        [DataContract]
        public class LineResult
        {
            [DataMember(Name = "line")]
            public string Line { get; set; }

            [DataMember(Name = "counts")]
            public int Counts { get; set; }

            [DataMember(Name = "accumulativecounts")]
            public int AccuCounts { get; set; }
        }

        public LVACountingResults(List<Tuple<string, int[]>> lines)
        {
            Result = new List<LineResult>();
            foreach (Tuple<string, int[]> line in lines)
            {
                LineResult lResult = new LineResult();
                lResult.Line = line.Item1;
                lResult.Counts = 0;
                Result.Add(lResult);
            }            
        }
    }
}