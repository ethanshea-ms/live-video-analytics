// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using DNNDetector.Config;
using Newtonsoft.Json.Linq;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Utils.Config;

namespace DNNDetector
{
    public class LineTriggeredHttp
    {
        private Dictionary<string, int> counts_prev = new Dictionary<string, int>();
        private FrameBuffer frameBufferLtDNNOnnxYolo;
        private string endpoint;

        public LineTriggeredHttp(string endpoint)
        {
            this.endpoint = endpoint;
            frameBufferLtDNNOnnxYolo = new FrameBuffer(DNNConfig.FRAME_SEARCH_RANGE);

            Utils.Utils.cleanFolder(@OutputFolder.OutputFolderLtDNN);
            Utils.Utils.cleanFolder(@OutputFolder.OutputFolderFrameDNNONNX);
        }

        public string Run(Mat frame, int frameIndex, Dictionary<string, int> counts, ref long teleCountsCheapDNN)
        {
            // buffer frame
            frameBufferLtDNNOnnxYolo.Buffer(frame);

            if (counts_prev.Count != 0)
            {
                foreach (string lane in counts.Keys)
                {
                    int diff = Math.Abs(counts[lane] - counts_prev[lane]);
                    if (diff > 0) //object detected by BGS
                    {
                        if (frameIndex >= DNNConfig.FRAME_SEARCH_RANGE)
                        {
                            // call onnx cheap model for crosscheck
                            int lineID = Array.IndexOf(counts.Keys.ToArray(), lane);
                            Mat[] frameBufferArray = frameBufferLtDNNOnnxYolo.ToArray();
                            int frameIndexOnnxYolo = frameIndex - 1;

                            while (frameIndex - frameIndexOnnxYolo < DNNConfig.FRAME_SEARCH_RANGE)
                            {
                                var index = DNNConfig.FRAME_SEARCH_RANGE - (frameIndex - frameIndexOnnxYolo);
                                Console.WriteLine($"** Invoking Http DNN on {index}");
                                Mat frameOnnx = frameBufferArray[index];

                                teleCountsCheapDNN++;
                                var result = string.Empty;
                                try
                                {
                                    using (var client = new HttpClient())
                                    {
                                        client.Timeout = TimeSpan.FromMinutes(1);
                                        var content = new ByteArrayContent(frameOnnx.ToBytes());
                                        var response = client.PostAsync(endpoint, content).Result;

                                        var contentResponse = response.Content.ReadAsStringAsync().Result;
                                        if (response.IsSuccessStatusCode)
                                        {
                                            result = contentResponse;

                                            if(!string.IsNullOrWhiteSpace(result))
                                            {
                                                JObject inferences = JObject.Parse(result);

                                                // get JSON result objects into a list
                                                IList<JToken> events = inferences["inferences"].Children().Where(x => x["event"] != null).Select(x => x["event"]).ToList();

                                                foreach (var @event in events)
                                                {
                                                    var count = @event["properties"]["count"].Value<int>();

                                                    if(count > 0)
                                                    {
                                                        // Detected
                                                        Console.WriteLine($"** Http DNN detected on: {index}");
                                                        return result;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            throw new Exception(contentResponse);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error invoking Yolo API: {ex.Message}");
                                    return null;
                                }
                                finally
                                {
                                    updateCount(counts);
                                }

                                frameIndexOnnxYolo--;
                            }
                        }
                    }
                }
            }
            updateCount(counts);
            return null;
        }

        void updateCount(Dictionary<string, int> counts)
        {
            foreach (string dir in counts.Keys)
            {
                counts_prev[dir] = counts[dir];
            }
        }
    }
}