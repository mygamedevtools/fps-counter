/**
 * FPSCounter.cs
 * Created by: João Borks [joao.borks@gmail.com]
 * Created on: 1/30/2021 (en-US)
 */

using UnityEngine;
using UnityEngine.Serialization;

namespace MyUnityTools.Stats
{
    [AddComponentMenu("Stats/FPS Counter")]
    public class FPSCounter : MonoBehaviour
    {
        public FPSBuffer FPSBuffer { get; private set; }

        [SerializeField, Range(15, 300), FormerlySerializedAs("bufferSize")]
        int _bufferSize = 60;

        void OnEnable() => FPSBuffer = new FPSBuffer(_bufferSize);

        void Update() => FPSBuffer.UpdateBuffer();
    }
}