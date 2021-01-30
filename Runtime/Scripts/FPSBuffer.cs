/**
 * FPSBuffer.cs
 * Created by: João Borks [joao.borks@gmail.com]
 * Created on: 1/30/2021 (en-US)
 */

using UnityEngine;

namespace JoaoBorks.Stats
{
    public class FPSBuffer
    {
        public int[] Values => values;
        public int AverageFPS => values[(int)FPSMetricType.Average];
        public int HighestFPS => values[(int)FPSMetricType.Highest];
        public int LowestFPS => values[(int)FPSMetricType.Lowest];

        readonly int[] buffer;

        int[] values;
        int bufferIndex;

        public FPSBuffer(int bufferSize)
        {
            buffer = new int[bufferSize];
            values = new int[System.Enum.GetValues(typeof(FPSMetricType)).Length];
            bufferIndex = 0;
        }

        public void UpdateBuffer()
        {
            buffer[bufferIndex] = (int)(1f / Time.unscaledDeltaTime);
            bufferIndex++;
            if (bufferIndex >= buffer.Length)
                bufferIndex = 0;
            CalculateFPS();
        }

        void CalculateFPS()
        {
            int sum = 0,
                highest = 0,
                lowest = int.MaxValue,
                fps,
                zeros = 0,
                bufferSize = buffer.Length;
            for (int i = 0; i < bufferSize; i++)
            {
                fps = buffer[i];
                if (fps != 0)
                {
                    sum += fps;
                    if (fps > highest)
                        highest = fps;
                    if (fps < lowest)
                        lowest = fps;
                }
                else
                    zeros++;
            }
            int filledValues = Mathf.Max(1, bufferSize - zeros);
            values[(int)FPSMetricType.Average] = sum / filledValues;
            values[(int)FPSMetricType.Highest] = highest;
            values[(int)FPSMetricType.Lowest] = lowest;
        }
    }
}