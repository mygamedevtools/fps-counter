/**
 * FPSBuffer.cs
 * Created by: João Borks [joao.borks@gmail.com]
 * Created on: 1/30/2021 (en-US)
 */

using UnityEngine;

namespace MyGameDevTools.Stats
{
    public class FPSBuffer
    {
        /// <summary>
        /// Current FPS Values, ordered by <see cref="FPSMetricType"/>
        /// </summary>
        public int[] Values => _values;
        public int AverageFPS => _values[(int)FPSMetricType.Average];
        public int HighestFPS => _values[(int)FPSMetricType.Highest];
        public int LowestFPS => _values[(int)FPSMetricType.Lowest];

        readonly int[] _buffer;
        readonly int[] _values;

        int _bufferIndex;

        /// <summary>
        /// Creates a <see cref="FPSBuffer"/> to keep a buffer of framerate samples and calculate the average, highest and lowest FPS values.
        /// </summary>
        /// <param name="bufferSize">The amount of framerate samples to store</param>
        public FPSBuffer(int bufferSize)
        {
            _buffer = new int[bufferSize];
            _values = new int[System.Enum.GetValues(typeof(FPSMetricType)).Length];
            _bufferIndex = 0;
        }

        /// <summary>
        /// Adds the current framerate to the buffer and recalculates the FPS values
        /// </summary>
        public void UpdateBuffer()
        {
            _buffer[_bufferIndex] = (int)(1f / Time.unscaledDeltaTime);
            _bufferIndex++;
            if (_bufferIndex >= _buffer.Length)
                _bufferIndex = 0;
            CalculateFPS();
        }

        void CalculateFPS()
        {
            int sum = 0,
                highest = 0,
                lowest = int.MaxValue,
                fps,
                zeros = 0,
                bufferSize = _buffer.Length;
            for (int i = 0; i < bufferSize; i++)
            {
                fps = _buffer[i];
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
            _values[(int)FPSMetricType.Average] = sum / filledValues;
            _values[(int)FPSMetricType.Highest] = highest;
            _values[(int)FPSMetricType.Lowest] = lowest;
        }
    }
}