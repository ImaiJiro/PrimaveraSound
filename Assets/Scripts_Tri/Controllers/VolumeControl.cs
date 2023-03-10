using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    //-------------------------------------SliderValues---------------------------------------------
    public float fadervalue;
    //-------------------------------------CalculatedValues-----------------------------------------
    public float rightfadervalue;
    public float leftfadervalue;
    //-------------------------------------AudioSources---------------------------------------------
    public AudioSource leftaudio;
    public AudioSource rightaudio;
    //-------------------------------------VolumeFromSliders----------------------------------------
    public float leftvolume;
    public float rightvolume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Change Volumes Every Frame
        ChangeVolume();
    }
    void ChangeVolume()
    {
        //If Fader is in Middle
        if (fadervalue == 0.5f)
        {
            rightfadervalue= 1f;
            leftfadervalue= 1f;
            leftaudio.volume = leftvolume * leftfadervalue;
            rightaudio.volume = rightvolume * rightfadervalue;
        }
        //If Fader is on Left
        else if (fadervalue > 0.5)
        {
            rightfadervalue = 1f - (fadervalue - 0.5f) * 2f;
            leftfadervalue = 1f;
            leftaudio.volume = leftvolume * leftfadervalue;
            rightaudio.volume = rightvolume * rightfadervalue;

        }
        //If Fader is on Right
        else if (fadervalue  < 0.5)
        {
            rightfadervalue = 1f;
            leftfadervalue = fadervalue * 2;
            leftaudio.volume = leftvolume * leftfadervalue;
            rightaudio.volume = rightvolume * rightfadervalue;
        }
    }
}
