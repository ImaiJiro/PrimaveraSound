using UnityEngine;
using UnityEngine.Audio;

namespace KnobsAsset
{
    /// <summary>
    /// Knob listener for assigning a knob value to an exposed mixer parameter.
    /// </summary>
    public class HighEqListener : KnobListener
    {
        public DJControllerwTracks controller;

        public override void OnKnobValueChange(float knobPercentValue)
        {
            float newValue = ((2.5f - 0.5f) * knobPercentValue) ;

            controller.higheqmultiplier = newValue;
            controller.ApplyEQ();
            Debug.Log(newValue);
        }
    }
}
