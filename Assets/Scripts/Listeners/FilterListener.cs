using UnityEngine;
using UnityEngine.Audio;

namespace KnobsAsset
{
    /// <summary>
    /// Knob listener for assigning a knob value to an exposed mixer parameter.
    /// </summary>
    public class FilterListener : KnobListener
    {
        public DJControllerwTracks controller;

        public override void OnKnobValueChange(float knobPercentValue)
        {

            controller.totaleqmultiplier = knobPercentValue;
            controller.ApplyEQ();
        }
    }
}