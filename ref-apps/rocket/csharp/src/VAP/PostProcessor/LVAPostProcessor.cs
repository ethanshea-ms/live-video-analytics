// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using DNNDetector.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace PostProcessor
{
    public class LVAPostProcessor
    {
        static Model.LVACountingResults countingConsolidation;

        public static string SerializeDetectionResult(List<Item> detectionItems)
        {
            if (detectionItems != null && detectionItems.Count != 0)
            {
                foreach (Item item in detectionItems)
                {
                    Console.WriteLine($"{item.ObjName}\t{item.ObjId}\t{item.Confidence}\t{item.X}");
                }

                Model.LVADetectionResults detectionConsolidation = new Model.LVADetectionResults();
                detectionConsolidation.Status = 0;
                detectionConsolidation.ObjectCount = detectionItems.Count;
                detectionConsolidation.Time = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");

                Model.LVAObject[] objects = new Model.LVAObject[detectionItems.Count];
                for (int i = 0; i < detectionItems.Count; i++)
                {
                    objects[i] = new Model.LVAObject();
                    objects[i].ObjID = detectionItems[i].ObjId;
                    objects[i].ObjName = detectionItems[i].ObjName;
                    objects[i].Prob = detectionItems[i].Confidence;
                    objects[i].Bbox = new int[] { detectionItems[i].X, detectionItems[i].Y, detectionItems[i].Width, detectionItems[i].Height };
                }
                detectionConsolidation.Objects = objects;

                //Create a stream to serialize the object to.  
                MemoryStream ms = new MemoryStream();

                // Serializer the User object to the stream.  
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Model.LVADetectionResults));
                ser.WriteObject(ms, detectionConsolidation);
                byte[] json = ms.ToArray();
                ms.Close();
                return Encoding.UTF8.GetString(json, 0, json.Length);
            }

            return null;
        }


        public static void InitializeCountingResult(List<Tuple<string, int[]>> lines)
        {
            countingConsolidation = new Model.LVACountingResults(lines);
        }

        public static string SerializeCountingResultFromItemList(List<Item> detectionItems, double processTime)
        {
            countingConsolidation.Status = 0;
            countingConsolidation.Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            countingConsolidation.ProcessTime = processTime;
            foreach (Model.LVACountingResults.LineResult lResult in countingConsolidation.Result)
            {
                if (detectionItems != null && detectionItems.Count != 0)
                {
                    int previousAccuCounts = lResult.AccuCounts;
                    foreach (Item item in detectionItems)
                    {
                        if (lResult.Line == item.TriggerLine)
                        {
                            lResult.AccuCounts++;
                        }
                    }
                    lResult.Counts = lResult.AccuCounts - previousAccuCounts;
                }
                else
                {
                    lResult.Counts = 0;
                }
            }

            //Create a stream to serialize the object to.  
            MemoryStream ms = new MemoryStream();

            // Serializer the User object to the stream.  
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Model.LVACountingResults));
            ser.WriteObject(ms, countingConsolidation);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json, 0, json.Length);
        }

        public static string SerializeCountingResultFromCounts(Dictionary<string, int> counts, double processTime)
        {
            countingConsolidation.Status = 0;
            countingConsolidation.Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            countingConsolidation.ProcessTime = processTime;
            foreach (Model.LVACountingResults.LineResult lResult in countingConsolidation.Result)
            {
                lResult.Counts = counts[lResult.Line] - lResult.AccuCounts;
                lResult.AccuCounts = counts[lResult.Line];
            }

            //Create a stream to serialize the object to.  
            MemoryStream ms = new MemoryStream();

            // Serializer the User object to the stream.  
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Model.LVACountingResults));
            ser.WriteObject(ms, countingConsolidation);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json, 0, json.Length);
        }
    }
}
