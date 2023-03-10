using System.Runtime.InteropServices.ComTypes;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Newtonsoft.Json.Linq;

public class DJControllerwTracks : MonoBehaviour
{
    //--------------------------------------------JogWheelVariables---------------------------------------
    public float rotationSpeed = 10.0f;
    public float positionSpeed = 1.0f;
    private Vector3 lastMousePosition;
    public GameObject Wheel;
    private bool isDragging = false;
    private bool canchangepos = false;
    //--------------------------------------------OtherVariables------------------------------------------
    public TrackLoader trackLoader;
    public AudioSource audioSource;
    [HideInInspector]
    public float bpmpercentvalue = 0;
    private float[] loadedAudioData;
    private AudioClip filteredClip;
    private float pausestore;
    public bool Loaddone=false;
    //-----------------------------------------------EQCONTROLS--------------------------------------------
    [HideInInspector]
    public float loweqmultiplier;
    [HideInInspector]
    public float mideqmultiplier;
    [HideInInspector]
    public float higheqmultiplier;
    [HideInInspector]
    public float totaleqmultiplier;
    //----------------------------------------------Filters----------------------------------------------
    private PeakingFiltor lowFilter = new PeakingFiltor(100, 1.0f, 6.0f, 44100);
    private PeakingFiltor midFilter = new PeakingFiltor(1000, 1.0f, 3.0f, 44100);
    private PeakingFiltor highFilter = new PeakingFiltor(10000, 1.0f, 6.0f, 44100);

    [Obsolete]
    void Start()
    {
       
            
        
    }
    private void LoadFirst()
    {
        //Play Something by setting the audiodata into a clip
        loadedAudioData = trackLoader.Loop2;
        //Apply Filters
        float[] samples = loadedAudioData;
        float[] lowOutput = lowFilter.Process(samples);
        float[] midOutput = midFilter.Process(samples);
        float[] highOutput = highFilter.Process(samples);
        float[] mixOutputs = new float[samples.Length];
        for (int i = 0; i < samples.Length; i++)
        {
            float mixedSample = (lowOutput[i] * loweqmultiplier + midOutput[i] * mideqmultiplier + highOutput[i] * higheqmultiplier) / 3;
            mixedSample = samples[i] * (1 - totaleqmultiplier) + mixedSample * totaleqmultiplier;


            mixOutputs[i] = mixedSample;
        }
        //CreateNewClipAndLoadItToPlay
        AudioClip filteredClip = AudioClip.Create("Filtered", mixOutputs.Length / 2, 2, (int)44100, false);
        filteredClip.SetData(mixOutputs, 0);
        audioSource.clip = filteredClip;
        audioSource.Play();
        Debug.Log("done");
    }

    void Update()
    {
        if (Loaddone)
        {
            //Load Something
            LoadFirst();
            // Make it False so its not called again
            Loaddone= false;
        }
        if (audioSource.isPlaying)
        {
           //ApplyAudioPosition and BPM
           ChangeAudioTime();
           ChangeAudioBPM();

        }

    }
    public void ApplyEQ()
    {
        if (audioSource.isPlaying)
        {
            //Apply Filters
            float[] samples = loadedAudioData;
            float[] lowOutput = lowFilter.Process(samples);
            float[] midOutput = midFilter.Process(samples);
            float[] highOutput = highFilter.Process(samples);
            float[] mixOutputs = new float[samples.Length];
            for (int i = 0; i < samples.Length; i++)
            {
                float mixedSample = (lowOutput[i] * loweqmultiplier + midOutput[i] * mideqmultiplier + highOutput[i] * higheqmultiplier) / 3;
                mixedSample = samples[i] * (1 - totaleqmultiplier) + mixedSample * totaleqmultiplier;


                mixOutputs[i] = mixedSample;
            }
            float pretime = audioSource.time;
            //CreateNewClipAndLoadItToPlay
            AudioClip filteredClip = AudioClip.Create("Filtered", mixOutputs.Length / 2, 2, (int)44100, false);
            filteredClip.SetData(mixOutputs, 0);
            audioSource.clip = filteredClip;
            audioSource.Play();
            audioSource.time= pretime;
            Debug.Log("done");
        }
        
    }
    public void ApplyEQonClipChange()
    {
        if (audioSource.isPlaying)
        {
            //Apply Filters
            float[] samples = loadedAudioData;
            float[] lowOutput = lowFilter.Process(samples);
            float[] midOutput = midFilter.Process(samples);
            float[] highOutput = highFilter.Process(samples);
            float[] mixOutputs = new float[samples.Length];
            for (int i = 0; i < samples.Length; i++)
            {
                float mixedSample = (lowOutput[i] * loweqmultiplier + midOutput[i] * mideqmultiplier + highOutput[i] * higheqmultiplier) / 3;
                mixedSample = samples[i] * (1 - totaleqmultiplier) + mixedSample * totaleqmultiplier;


                mixOutputs[i] = mixedSample;
            }
            //CreateNewClipAndLoadItToPlay
            AudioClip filteredClip = AudioClip.Create("Filtered", mixOutputs.Length / 2, 2, (int)44100, false);
            filteredClip.SetData(mixOutputs, 0);
            audioSource.clip = filteredClip;
            audioSource.Play();
            audioSource.time = 0;
            Debug.Log("done");
        }

    }
    public void PlayPause()
    {
        //Pause the Audio
        if (audioSource.isPlaying) {
            pausestore = audioSource.time;
            audioSource.Pause();

        }
        //Play the video by making a new clip and applying filters
        else if (!audioSource.isPlaying)
        {
            float[] samples = loadedAudioData;
            float[] lowOutput = lowFilter.Process(samples);
            float[] midOutput = midFilter.Process(samples);
            float[] highOutput = highFilter.Process(samples);
            float[] mixOutputs = new float[samples.Length];
            for (int i = 0; i < samples.Length; i++)
            {
                float mixedSample = (lowOutput[i] * loweqmultiplier + midOutput[i] * mideqmultiplier + highOutput[i] * higheqmultiplier) / 3;
                mixedSample = samples[i] * (1 - totaleqmultiplier) + mixedSample * totaleqmultiplier;


                mixOutputs[i] = mixedSample;
            }
            AudioClip filteredClip = AudioClip.Create("Filtered", mixOutputs.Length / 2, 2, (int)44100, false);
            filteredClip.SetData(mixOutputs, 0);
            audioSource.clip = filteredClip;
            audioSource.Play();
            Debug.Log("done");
            audioSource.time= pausestore;
        }
    }
    public void ChangeClip(string clipname)
    {
        //Change Clips Based On The String Given Through a Button(Track Selection)
        if (!audioSource.isPlaying)
        {
            switch (clipname)
            {
                case "Loop1":
                    loadedAudioData = trackLoader.Loop1;
                    pausestore= 0;
                    break;
                case "Loop2":
                    loadedAudioData = trackLoader.Loop2;
                    pausestore = 0;
                    break;
                case "Loop3":
                    loadedAudioData = trackLoader.Loop3;
                    pausestore = 0;
                    break;
                case "Loop4":
                    loadedAudioData = trackLoader.Loop4;
                    pausestore = 0;
                    break;
                case "Loop5":
                    loadedAudioData = trackLoader.Loop5;
                    pausestore = 0;
                    break;
                default:
                    Debug.LogError("Invalid loop number");
                    break;
            }

        }else if (audioSource.isPlaying)
        {
            switch (clipname)
            {
                case "Loop1":
                    loadedAudioData = trackLoader.Loop1;
                    ApplyEQonClipChange();
                    break;
                case "Loop2":
                    loadedAudioData = trackLoader.Loop2;
                    ApplyEQonClipChange();
                    break;
                case "Loop3":
                    loadedAudioData = trackLoader.Loop3;
                    ApplyEQonClipChange();
                    break;
                case "Loop4":
                    loadedAudioData = trackLoader.Loop4;
                    ApplyEQonClipChange();
                    break;
                case "Loop5":
                    loadedAudioData = trackLoader.Loop5;
                    ApplyEQonClipChange();
                    break;
                default:
                    Debug.LogError("Invalid loop number");
                    break;
            }
        }
        
    }

    private void ChangeAudioBPM()
    {
        //Change The Pitch Based On BPM Slider
        audioSource.pitch = bpmpercentvalue;
    }



    private void ChangeAudioTime()
    {
        // Rotate the DJ wheel based on the mouse movement
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse click is on the wheel
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == Wheel)
            {
                isDragging = true;
                lastMousePosition = Input.mousePosition;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            Wheel.transform.Rotate(Vector3.up, -mouseDelta.x * rotationSpeed, Space.World);
            // Restrict the rotation to the vertical axis
            Wheel.transform.localEulerAngles = new Vector3(0, Wheel.transform.localEulerAngles.y, 0);

            lastMousePosition = Input.mousePosition;
            canchangepos = true;

        }
        if (isDragging == false & canchangepos)
        {
            canchangepos = false;
            float position = Wheel.transform.localEulerAngles.y / 360.0f;
            audioSource.time = Mathf.Lerp(0.0f, audioSource.clip.length, positionSpeed * position);
        }
    }
   
}
