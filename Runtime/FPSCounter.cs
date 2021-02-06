/**
 * FPSCounter.cs
 * Created by: João Borks [joao.borks@gmail.com]
 * Created on: 1/30/2021 (en-US)
 */

using UnityEngine;

namespace UnityTools.Stats
{
    [AddComponentMenu("Stats/FPS Counter")]
    public class FPSCounter : MonoBehaviour
    {
        public FPSBuffer FPSBuffer { get; private set; }

        [SerializeField, Range(15, 300)]
        int bufferSize = 60;

        void Awake() => FPSBuffer = new FPSBuffer(bufferSize);

        void Update() => FPSBuffer.UpdateBuffer();
    }
}