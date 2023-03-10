using System.Runtime.InteropServices.ComTypes;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Newtonsoft.Json.Linq;
using TMPro;
using System.Threading;
using KnobsAsset;

public class DJControllerwTracks : MonoBehaviour
{
    //-------------------------------------------- Sliders------------------------------------------------
    public GameObject bpmslider1;
    public GameObject bpmslider2;
    public SliderKnob sliderknob1;
    public SliderKnob sliderknob2;
    public GameObject volumeslider1;
    public GameObject volumeslider2;
    public SliderKnob vsliderknob1;
    public SliderKnob vsliderknob2;
    //--------------------------------------------JogWheelVariables---------------------------------------
    public float rotationSpeed = 10.0f;
    public float positionSpeed = 1.0f;
    private Vector3 lastMousePosition;
    public GameObject Wheel;
    private bool isDragging = false;
    private bool canchangepos = false;
    //--------------------------------------------OtherVariables------------------------------------------
    public VolumeControl volumecontrol;
    public TrackLoader trackLoader;
    public AudioSource audioSource;
    [HideInInspector]
    public float bpmpercentvalue = 0;
    public float[] loadedAudioData;
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
    //----------------------------------------------Ui----------------------------------------------------
    public UiTrackSelection trackselector;
    public TMP_Text Clipname;
    //------------------------------------------QuestManaging--------------------------------------------
    public QuestManager QuestManager;
    public QuestMiddleMan QuestMiddleMan;
    //-------------------------------------------QuestSpecifics-----------------------------------------
    public AudioSource otheraudiosource;
    public DJControllerwTracks othercontroller;
    //------------------------------------------ Level 1 -----------------------------------------------
    public bool hasloadedclip = false;
    public bool hasplayedclip = false;
    public bool iamcontroller1 = false;
    public bool iamcontroller2 = false;
    //----------------------------------------- Level 2 ------------------------------------------------
    public bool hasdonel2loading = false;
    public bool hastestedtempo = false;
    public bool hastestedjogwheel = false;
    public bool hasplayedclipl2 = false;
    //----------------------------------------- Level 3 ------------------------------------------------
    public bool hasdonel3loading = false;
    public bool hasplayedclipl3deck1 = false;
    public bool hasplayedclipl3deck2 = false;
    //----------------------------------------- Level 4 ------------------------------------------------
    public bool loweqdone = false;
    public bool mideqdone = false;
    public bool higheqdone = false;
    public bool mastereqdone = false;
    private float temploweq;
    private float tempmideq;
    private float temphigheq;
    private float tempmastereq;
    //---------------------------------------- Tracks ---------------------------------------------------
    public bool Track1loaded = false;
    public bool Track2loaded = false;
    public bool Track3loaded = false;
    public bool Track4loaded = false;
    public AudioClip Track1;
    public AudioClip Track2;
    public AudioClip Track3;
    public AudioClip Track4;
    //---------------------------------------- Clip On -------------------------------------------------
    public GameObject OnLight;
    public GameObject OffLight;
    //---------------------------------------- BPM -----------------------------------------------------
    public int currentbpm;
    public TMP_Text bpmcount;

    [Obsolete]
    void Start()
    {
        OnLight.SetActive(false);
        OffLight.SetActive(true);
        loadedAudioData = null;       
    }
    

    void Update()
    {

        if (loadedAudioData == null & !Track1loaded & !Track2loaded & !Track3loaded & !Track4loaded)
        {
            OnLight.SetActive(false);
            OffLight.SetActive(true);
        }
        else if (loadedAudioData != null)
        {
            OnLight.SetActive(true);
            OffLight.SetActive(false);
        }
        else if (Track1loaded & !Track2loaded & !Track3loaded & !Track4loaded & loadedAudioData == null)
        {
            OnLight.SetActive(true);
            OffLight.SetActive(false);
        }
        else if (!Track1loaded & Track2loaded & !Track3loaded & !Track4loaded & loadedAudioData == null)
        {
            OnLight.SetActive(true);
            OffLight.SetActive(false);
        }
        else if (!Track1loaded & !Track2loaded & Track3loaded & !Track4loaded & loadedAudioData == null)
        {
            OnLight.SetActive(true);
            OffLight.SetActive(false);
        }
        else if (!Track1loaded & !Track2loaded & !Track3loaded & Track4loaded & loadedAudioData == null)
        {
            OnLight.SetActive(true);
            OffLight.SetActive(false);
        }

        if (loadedAudioData == null & !Track1loaded & !Track2loaded & !Track3loaded & !Track4loaded)
        {
            Clipname.text = "";
        }
        else if (Track1loaded & !Track2loaded & !Track3loaded & !Track4loaded & loadedAudioData == null)
        {
            Clipname.text = "Track1";
        }
        else if (!Track1loaded & Track2loaded & !Track3loaded & !Track4loaded & loadedAudioData == null)
        {
            Clipname.text = "Track2";
        }
        else if (!Track1loaded & !Track2loaded & Track3loaded & !Track4loaded & loadedAudioData == null)
        {
            Clipname.text = "Track3";
        }
        else if (!Track1loaded & !Track2loaded & !Track3loaded & Track4loaded & loadedAudioData == null)
        {
            Clipname.text = "Track4";
        }
        if (iamcontroller2 & QuestManager.currentquest == QuestManager.L1Final & !QuestManager.currentquest.isComplete )
        {
            Debug.Log(otheraudiosource.clip.length - otheraudiosource.time);
            float timer = otheraudiosource.clip.length - otheraudiosource.time;
            if (timer < 0.1)
            {
                QuestManager.currentquest.CompleteQuest();
                QuestManager.currentquest = QuestManager.L1Task1;
                othercontroller.loadedAudioData = null;
                loadedAudioData = null;
                audioSource.time = 0;
                audioSource.Pause();
                QuestManager.currentquest.StartQuest();
            }
        }
        if (iamcontroller2 & QuestManager.currentquest == QuestManager.L3Task4 & !QuestManager.currentquest.isComplete)
        {
            Debug.Log(otheraudiosource.clip.length - otheraudiosource.time);
            float timer = otheraudiosource.clip.length - otheraudiosource.time;
            if (timer < 0.1)
            {
                QuestManager.currentquest.CompleteQuest();
                QuestManager.currentquest = QuestManager.L3Task3;
                audioSource.time = 0;
                audioSource.Pause();
                otheraudiosource.time= 0;
                otheraudiosource.Pause();
                QuestManager.currentquest.StartQuest();
            }
        }
        if (audioSource.isPlaying)
        {
           //ApplyAudioPosition and BPM
           ChangeAudioTime();
           ChangeAudioBPM();

        }
        else if (!audioSource.isPlaying)
        {
            audioSource.pitch = bpmpercentvalue;
        }
        if (iamcontroller1 & QuestManager.currentquest == QuestManager.L2Final & !QuestManager.currentquest.isComplete)
        {
            Debug.Log(otheraudiosource.clip.length - otheraudiosource.time);
            float timer = otheraudiosource.clip.length - otheraudiosource.time;
            if (timer < 0.1)
            {
                ResetControls();
                QuestManager.currentquest.CompleteQuest();
                QuestManager.currentquest = QuestManager.L2Task1;
                audioSource.time = 0;
                audioSource.Pause();
                otheraudiosource.time = 0;
                QuestManager.currentquest.StartQuest();
            }
        }
        float bpm = currentbpm * audioSource.pitch;
        int bpmint = Mathf.RoundToInt(bpm);
        bpmcount.text = bpmint.ToString();
        Debug.Log(bpm);
    }
    public void SettempEq()
    {
        temploweq = loweqmultiplier;
        tempmideq = mideqmultiplier;
        temphigheq = higheqmultiplier;
        tempmastereq = totaleqmultiplier;
    }
    public void ApplyEQ()
    {
       
        if (QuestManager.currentquest == QuestManager.L4Task1 & !QuestManager.currentquest.isComplete & !loweqdone)
        {
            if (loweqmultiplier != temploweq)
            {
                loweqdone = true;
                QuestMiddleMan.loweqdone += 1;
            }
            
        }
        if (QuestManager.currentquest == QuestManager.L4Task2 & !QuestManager.currentquest.isComplete & !mideqdone)
        {
            if (mideqmultiplier != tempmideq)
            {
                mideqdone = true;
                QuestMiddleMan.mideqdone += 1;
            }

        }
        if (QuestManager.currentquest == QuestManager.L4Task3 & !QuestManager.currentquest.isComplete & !higheqdone)
        {
            if (higheqmultiplier != temphigheq)
            {
                higheqdone = true;
                QuestMiddleMan.higheqdone += 1;
            }

        }
        if (QuestManager.currentquest == QuestManager.L4Task4 & !QuestManager.currentquest.isComplete & !mastereqdone)
        {
            if (totaleqmultiplier != tempmastereq)
            {
                mastereqdone = true;
                QuestMiddleMan.mastereqdone += 1;
            }

        }
        if (loadedAudioData != null & !Track1loaded & !Track2loaded & !Track3loaded & !Track4loaded)
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
                audioSource.time = pretime;
                Debug.Log("done");
            }
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
        if (QuestManager.currentquest == QuestManager.L1Task2 & iamcontroller1 & !QuestManager.currentquest.isComplete)
        {
            hasplayedclip = true;

        }
        if (QuestManager.currentquest == QuestManager.L3Task3 & iamcontroller1 & !QuestManager.currentquest.isComplete)
        {
            hasplayedclipl3deck1 = true;

        }
        //Pause the Audio
        if (loadedAudioData == null & !Track1loaded & !Track2loaded & !Track3loaded & !Track4loaded)
        {

        }else if (audioSource.isPlaying ) 
        {
            pausestore = audioSource.time;
            audioSource.Pause();

        }
        //Play the video by making a new clip and applying filters
        else if (!audioSource.isPlaying & loadedAudioData != null & !Track1loaded & !Track2loaded & !Track3loaded & !Track4loaded)
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
        else if (!audioSource.isPlaying & loadedAudioData == null & Track1loaded & !Track2loaded & !Track3loaded & !Track4loaded)
        {
            audioSource.clip = Track1;
            audioSource.Play();
            Debug.Log("done");
            audioSource.time = pausestore;
        }
        else if (!audioSource.isPlaying & loadedAudioData == null & !Track1loaded & Track2loaded & !Track3loaded & !Track4loaded)
        {
            audioSource.clip = Track2;
            audioSource.Play();
            Debug.Log("done");
            audioSource.time = pausestore;
        }
        else if (!audioSource.isPlaying & loadedAudioData == null & !Track1loaded & !Track2loaded & Track3loaded & !Track4loaded)
        {
            audioSource.clip = Track3;
            audioSource.Play();
            Debug.Log("done");
            audioSource.time = pausestore;
        }
        else if (!audioSource.isPlaying & loadedAudioData == null & !Track1loaded & !Track2loaded & !Track3loaded & Track4loaded)
        {
            audioSource.clip = Track4;
            audioSource.Play();
            Debug.Log("done");
            audioSource.time = pausestore;
        }

        if (QuestManager.currentquest == QuestManager.L1Final & iamcontroller2 & !QuestManager.currentquest.isComplete)
        {

            float outsection = otheraudiosource.clip.length * 0.2f;
            outsection = otheraudiosource.clip.length - outsection;
            if (otheraudiosource.time < outsection)
            {
                QuestManager.currentquest.CompleteQuest();
                QuestManager.currentquest = QuestManager.L1Task1;
                loadedAudioData = null;
                audioSource.time = 0;
                audioSource.Pause();
                othercontroller.loadedAudioData = null;
                otheraudiosource.time = 0;
                otheraudiosource.Pause();

                QuestManager.currentquest.StartQuest();
            }
            else if (otheraudiosource.time > outsection)
            {
                hasplayedclip = true;
            }


        }
        if (QuestManager.currentquest == QuestManager.L2Final & iamcontroller1 & !QuestManager.currentquest.isComplete)
        {

            float outsection = otheraudiosource.clip.length * 0.2f;
            outsection = otheraudiosource.clip.length - outsection;
            if (otheraudiosource.time < outsection)
            {
                ResetControls();
                QuestManager.currentquest.CompleteQuest();
                QuestManager.currentquest = QuestManager.L2Task1;
                audioSource.time = 0;
                audioSource.Pause();
                otheraudiosource.time = 0;
                otheraudiosource.Play();
                QuestManager.currentquest.StartQuest();
            }
            else if (otheraudiosource.time > outsection)
            {
                hasplayedclipl2 = true;
            }
        }
        if (QuestManager.currentquest == QuestManager.L3Task5 & iamcontroller2 & !QuestManager.currentquest.isComplete)
        {
            hasplayedclipl3deck2 = true;

        }
        


    }
    public void CueClip()
    {


        if (audioSource.isPlaying)
        {
            pausestore = 0;
            audioSource.Pause();

        }
        //Play the audio by making a new clip and applying filters
        else if (!audioSource.isPlaying & loadedAudioData != null & !Track1loaded & !Track2loaded & !Track3loaded & !Track4loaded)
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
            audioSource.time = pausestore;

        }
        else if (!audioSource.isPlaying & loadedAudioData == null & Track1loaded & !Track2loaded & !Track3loaded & !Track4loaded)
        {
            audioSource.clip = Track1;
            audioSource.Play();
            Debug.Log("done");
            audioSource.time = pausestore;
        }
        else if (!audioSource.isPlaying & loadedAudioData == null & !Track1loaded & Track2loaded & !Track3loaded & !Track4loaded)
        {
            audioSource.clip = Track2;
            audioSource.Play();
            Debug.Log("done");
            audioSource.time = pausestore;
        }
        else if (!audioSource.isPlaying & loadedAudioData == null & !Track1loaded & !Track2loaded & Track3loaded & !Track4loaded)
        {
            audioSource.clip = Track3;
            audioSource.Play();
            Debug.Log("done");
            audioSource.time = pausestore;
        }
        else if (!audioSource.isPlaying & loadedAudioData == null & !Track1loaded & !Track2loaded & !Track3loaded & Track4loaded)
        {
            audioSource.clip = Track4;
            audioSource.Play();
            Debug.Log("done");
            audioSource.time = pausestore;
        }
    }
    public void CueOnPlaying()
    {
        pausestore = 0;
        audioSource.Pause();
    }
    public void ChangeClip(string clipname)
    {
        if (QuestManager.currentquest == QuestManager.L2Task0 & !QuestManager.currentquest.isComplete & !hasdonel2loading)
        {
            QuestMiddleMan.hasloadedclipl2 += 1;
            hasdonel2loading= true;

        }
        if (QuestManager.currentquest == QuestManager.L3Task0 & !QuestManager.currentquest.isComplete & !hasdonel3loading)
        {
            QuestMiddleMan.hasloadedclipl3 += 1;
            hasdonel2loading = true;

        }
        if (QuestManager.currentquest == QuestManager.L1Task1 & iamcontroller1 & !QuestManager.currentquest.isComplete)
        {
            hasloadedclip = true;

        }
        if (QuestManager.currentquest == QuestManager.L1Task3 & iamcontroller2 & !QuestManager.currentquest.isComplete)
        {
            hasloadedclip = true;

        }
        //Change Clips Based On The String Given Through a Button(Track Selection)
        if (!audioSource.isPlaying)
        {
            trackselector.HideBothSelector();
            switch (clipname)
            {
                case "Loop1":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop1;
                    pausestore= 0;
                    break;
                case "Loop2":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop2;
                    pausestore = 0;
                    break;
                case "Loop3":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop3;
                    pausestore = 0;
                    break;
                case "Loop4":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop4;
                    pausestore = 0;
                    break;
                case "Loop5":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop5;
                    pausestore = 0;
                    break;
                case "Loop6":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop6;
                    pausestore = 0;
                    break;
                case "Loop7":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop7;
                    pausestore = 0;
                    break;
                case "Loop8":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop8;
                    pausestore = 0;
                    break;
                case "Loop9":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop9;
                    pausestore = 0;
                    break;
                case "Loop10":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop10;
                    pausestore = 0;
                    break;
                case "Track1":
                    Clipname.text = clipname;
                    Track1loaded = true;
                    Track2loaded = false;
                    Track3loaded = false;
                    Track4loaded = false;
                    loadedAudioData = null;
                    pausestore = 0;
                    break;
                case "Track2":
                    Clipname.text = clipname;
                    Track1loaded = false;
                    Track2loaded = true;
                    Track3loaded = false;
                    Track4loaded = false;
                    loadedAudioData = null;
                    pausestore = 0;
                    break;
                case "Track3":
                    Clipname.text = clipname;
                    Track1loaded = false;
                    Track2loaded = false;
                    Track3loaded = true;
                    Track4loaded = false;
                    loadedAudioData = null;
                    pausestore = 0;
                    break;
                case "Track4":
                    Clipname.text = clipname;
                    Track1loaded = false;
                    Track2loaded = false;
                    Track3loaded = false;
                    Track4loaded = true;
                    loadedAudioData = null;
                    pausestore = 0;
                    break;
                default:
                    Debug.LogError("Invalid loop number");
                    break;
            }

        }else if (audioSource.isPlaying)
        {
            trackselector.HideBothSelector();
            switch (clipname)
            {
                case "Loop1":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop1;
                    ApplyEQonClipChange();
                    break;
                case "Loop2":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop2;
                    ApplyEQonClipChange();
                    break;
                case "Loop3":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop3;
                    ApplyEQonClipChange();
                    break;
                case "Loop4":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop4;
                    ApplyEQonClipChange();
                    break;
                case "Loop5":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop5;
                    ApplyEQonClipChange();
                    break;
                case "Loop6":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop6;
                    ApplyEQonClipChange();
                    break;
                case "Loop7":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop7;
                    ApplyEQonClipChange();
                    break;
                case "Loop8":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop8;
                    ApplyEQonClipChange();
                    break;
                case "Loop9":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop9;
                    ApplyEQonClipChange();
                    break;
                case "Loop10":
                    Clipname.text = clipname;
                    loadedAudioData = trackLoader.Loop10;
                    ApplyEQonClipChange();
                    break;
                case "Track1":
                    Clipname.text = clipname;
                    Track1loaded = true;
                    Track2loaded = false;
                    Track3loaded = false;
                    Track4loaded = false;
                    loadedAudioData = null;
                    audioSource.clip = Track1;
                    audioSource.Play();
                    break;
                case "Track2":
                    Clipname.text = clipname;
                    Track1loaded = false;
                    Track2loaded = true;
                    Track3loaded = false;
                    Track4loaded = false;
                    loadedAudioData = null;
                    audioSource.clip = Track2;
                    audioSource.Play();
                    break;
                case "Track3":
                    Clipname.text = clipname;
                    Track1loaded = false;
                    Track2loaded = false;
                    Track3loaded = true;
                    Track4loaded = false;
                    loadedAudioData = null;
                    audioSource.clip = Track3;
                    audioSource.Play();
                    break;
                case "Track4":
                    Clipname.text = clipname;
                    Track1loaded = false;
                    Track2loaded = false;
                    Track3loaded = false;
                    Track4loaded = true;
                    loadedAudioData = null;
                    audioSource.clip = Track4;
                    audioSource.Play();
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
        float temppitch = audioSource.pitch;
        audioSource.pitch = bpmpercentvalue;
        if (audioSource.pitch != temppitch)
        {
            if (QuestManager.currentquest == QuestManager.L2Task1 & iamcontroller2 & !QuestManager.currentquest.isComplete)
            {
                hastestedtempo = true;
            }
            else if (QuestManager.currentquest == QuestManager.L2Task1 & iamcontroller1 & !QuestManager.currentquest.isComplete)
            {
                hastestedtempo = true;
            }
        }
        
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
            if (QuestManager.currentquest == QuestManager.L2Task2 & iamcontroller2 & !QuestManager.currentquest.isComplete)
            {
               hastestedjogwheel= true;
            }else if (QuestManager.currentquest == QuestManager.L2Task2 & iamcontroller1 & !QuestManager.currentquest.isComplete)
            {
                hastestedjogwheel = true;
            }
        }
    }
    public void ResetControls()
    {
        //------------------------BPM------------------------------------
        float AmountMoved = 2;
        float MinPosition = -2;
        Vector3 minPosition = (Vector3.forward * MinPosition);
        bpmslider1.transform.localPosition = minPosition + (Vector3.forward * AmountMoved);
        bpmslider2.transform.localPosition = minPosition + (Vector3.forward * AmountMoved);
        sliderknob1.AmountMoved = 2;
        sliderknob2.AmountMoved = 2;
        bpmpercentvalue = 1;
        othercontroller.bpmpercentvalue = 1;
        ChangeAudioBPM();
        othercontroller.ChangeAudioBPM();
        //---------------------Volume-------------------------------------
        volumeslider1.transform.localPosition = minPosition + (Vector3.forward * AmountMoved);
        volumeslider2.transform.localPosition = minPosition + (Vector3.forward * AmountMoved);
        vsliderknob1.AmountMoved = 2;
        vsliderknob2.AmountMoved = 2;
        volumecontrol.leftvolume = 1;
        volumecontrol.rightvolume = 1;
        volumecontrol.ChangeVolume();
    }
}
