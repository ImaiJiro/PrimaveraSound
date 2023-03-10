using System;
using UnityEngine;
using UnityEngine.Audio;

namespace KnobsAsset
{
    /// <summary>
    /// Knob listener for assigning a knob value to an exposed mixer parameter.
    /// </summary>
    public class BPMSliderListener : KnobListener
    {
        public DJControllerwTracks controller;

        public override void OnKnobValueChange(float knobPercentValue)
        {
            float newValue = (1.25f - 0.75f) * (1f - knobPercentValue) / (1f - 0f) + 0.75f;
            controller.bpmpercentvalue = newValue;
            Debug.Log(controller.bpmpercentvalue);


        }
    }
}