using UnityEngine;
using UnityEngine.Audio;

namespace KnobsAsset
{
    /// <summary>
    /// Knob listener for assigning a knob value to an exposed mixer parameter.
    /// </summary>
    public class RightVolumeListener : KnobListener
    {
        public VolumeControl controller;

        public override void OnKnobValueChange(float knobPercentValue)
        {
            controller.rightvolume = 1- knobPercentValue;

        }
    }
}