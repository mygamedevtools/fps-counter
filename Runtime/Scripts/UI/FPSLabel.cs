/**
 * FPSLabel.cs
 * Created by: João Borks [joao.borks@gmail.com]
 * Created on: 5/30/2021 (en-US)
 */

using TMPro;
using UnityEngine;

namespace JoaoBorks.Stats.UI
{
    [System.Serializable]
    public struct FPSLabel
    {
        public TextMeshProUGUI Label;
        public bool UseColorGradient;
        public Gradient ColorGradient;

        public void UpdateLabel(string fpsString, float targetFpsRatio)
        {
            if (!Label)
                return;
            Label.SetText(fpsString);
            if (UseColorGradient)
                Label.color = ColorGradient.Evaluate(targetFpsRatio);
        }
    }
}