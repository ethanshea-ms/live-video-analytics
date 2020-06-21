// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using DNNDetector.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace PostProcessor
{
    public class LVAPostProcessor
    {
        static Model.LVACountingResults countingConsolidation;

        public static string SerializeDetectionResult(List<Item> detectionItems, double processTime, int w, int h)
        {
            if (detectionItems != null && detectionItems.Count != 0)
            {
                foreach (Item item in detectionItems)
                {
                    Console.WriteLine($"{item.ObjName}\t{item.ObjId}\t{item.Confidence}\t{item.X}");
                }

                Model.LVADetectionResults detectionConsolidation = new Model.LVADetectionResults();
                detectionConsolidation.dInference = new object[detectionItems.Count + 1];
                
                //Compose other
                Model.LVAOther other = new Model.LVAOther();
                other.other = new Model.LVAOther.Oth();
                other.other.inferenceTime = processTime;
                other.other.count = detectionItems.Count;
                detectionConsolidation.dInference[0] = other;

                //Compose entity
                for (int i = 0; i < detectionItems.Count; i++)
                {
                    Model.LVAEntity obj = new Model.LVAEntity();
                    obj.entity = new Model.LVAEntity.Entity();
                    obj.entity.tag = new Model.LVAEntity.Entity.Tag();
                    obj.entity.tag.value = detectionItems[i].ObjName;
                    obj.entity.tag.confidence = detectionItems[i].Confidence;
                    obj.entity.box = new Model.LVAEntity.Entity.Box();
                    obj.entity.box.t = (double)detectionItems[i].Y / h;
                    obj.entity.box.l = (double)detectionItems[i].X / w;
                    obj.entity.box.w = (double)detectionItems[i].Width / w;
                    obj.entity.box.h = (double)detectionItems[i].Height / h;
                    detectionConsolidation.dInference[i + 1] = obj;
                }

                //Create a stream to serialize the object to.  
                MemoryStream ms = new MemoryStream();

                //Serializer the User object to the stream.
                var settings = new DataContractJsonSerializerSettings();
                settings.EmitTypeInformation = EmitTypeInformation.Never;
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Model.LVADetectionResults), settings);
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
