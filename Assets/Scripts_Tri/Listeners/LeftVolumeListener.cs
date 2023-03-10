using UnityEngine;
using UnityEngine.Audio;

namespace KnobsAsset
{
    /// <summary>
    /// Knob listener for assigning a knob value to an exposed mixer parameter.
    /// </summary>
    public class LeftVolumeListener : KnobListener
    {
        public VolumeControl controller;

        public override void OnKnobValueChange(float knobPercentValue)
        {
            controller.leftvolume = 1- knobPercentValue;

        }
    }
}