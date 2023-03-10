using UnityEngine;

public class PeakingFiltor
{
    // Filter coefficients
    private float b0, b1, b2, a1, a2;

    // Filter state
    private float x1 = 0, x2 = 0, y1 = 0, y2 = 0;

    // Initialize the filter coefficients
    private void CalculateCoefficients(float frequency, float q, float gain, float sampleRate)
    {
        float w0 = 2 * Mathf.PI * frequency / sampleRate;
        float cosW0 = Mathf.Cos(w0);
        float sinW0 = Mathf.Sin(w0);
        float alpha = sinW0 / (2 * q);
        float a = Mathf.Pow(10, gain / 40);

        b0 = 1 + alpha * a;
        b1 = -2 * cosW0;
        b2 = 1 - alpha * a;
        a1 = 2 * alpha * (a - 1) * cosW0;
        a2 = (1 - alpha * a) - alpha * (a + 1) * cosW0;
    }

    // Process a single audio sample
    public float[] Process(float[] samples)
    {
        int length = samples.Length;
        float[] outputs = new float[length];

        for (int i = 0; i < length; i++)
        {
            float output = b0 * samples[i] + b1 * x1 + b2 * x2 - a1 * y1 - a2 * y2;
            x2 = x1;
            x1 = samples[i];
            y2 = y1;
            y1 = output;
            outputs[i] = output;
        }

        return outputs;
    }


    // Constructor
    public PeakingFiltor(float frequency, float q, float gain, float sampleRate)
    {
        CalculateCoefficients(frequency, q, gain, sampleRate);
    }
}

