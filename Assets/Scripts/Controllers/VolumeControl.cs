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
    private float elapsedTime = 0f;
    private bool isTimerRunning = false;
    //-------------------------------------AudioSources---------------------------------------------
    public AudioSource leftaudio;
    public AudioSource rightaudio;
    //-------------------------------------VolumeFromSliders----------------------------------------
    public float leftvolume;
    public float rightvolume;
    //-------------------------------------Level 3-------------------------------------------------
    public bool Fadervaluechanged = false;
    public bool LeftVolumeSliderChangedValue = false;
    public bool RightVolumeSliderChangedValue = false;
    public QuestManager QuestManager;
    public bool hasturnedfaderleft = false;
    public bool hasturnedfaderright = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Change Volumes Every Frame
        ChangeVolume();
        // check if the timer is running
        if (isTimerRunning)
        {
            // add the elapsed time since the last frame to the total elapsed time
            elapsedTime += Time.deltaTime;
        }
    }
    public void ChangeVolume()
    {
        float templeftvalue = leftaudio.volume;
        float temprightvalue = rightaudio.volume;
        /*if (QuestManager.currentquest == QuestManager.L3Task4 & !QuestManager.currentquest.isComplete  & isTimerRunning)
        {
            if (elapsedTime > 7)
            {
                StopTimer();
                QuestManager.currentquest.CompleteQuest();
                QuestManager.currentquest = QuestManager.L3Task3;
                QuestManager.currentquest.StartQuest();
                leftaudio.time = 0;
                leftaudio.Pause();
            }

        }
        
        if (QuestManager.currentquest == QuestManager.L3Task4  & !QuestManager.currentquest.isComplete & fadervalue > 0.95 & isTimerRunning)
        {
            StopTimer();
            if (elapsedTime >= 2 & elapsedTime <= 7)
            {
                StopTimer();
                hasturnedfaderleft = true;
            }
            if (elapsedTime < 2)
            {
                QuestManager.currentquest.CompleteQuest();
                QuestManager.currentquest = QuestManager.L3Task3;
                QuestManager.currentquest.StartQuest();
                leftaudio.time = 0;
                leftaudio.Pause();

            }
            
        }
        if (QuestManager.currentquest == QuestManager.L3Final & !QuestManager.currentquest.isComplete & fadervalue < 0.05 & isTimerRunning)
        {
            StopTimer();
            if (elapsedTime >= 2 & elapsedTime <= 7)
            {
                hasturnedfaderright = true;
            }
            else if (elapsedTime < 2)
            {
                QuestManager.currentquest.CompleteQuest();
                QuestManager.currentquest = QuestManager.L3Task3;
                QuestManager.currentquest.StartQuest();
                leftaudio.time = 0;
                leftaudio.Pause();

            }
           
        }
        if (QuestManager.currentquest == QuestManager.L3Final & !QuestManager.currentquest.isComplete  & isTimerRunning)
        {
            if (elapsedTime > 7)
            {
                StopTimer();
                QuestManager.currentquest.CompleteQuest();
                QuestManager.currentquest = QuestManager.L3Task3;
                QuestManager.currentquest.StartQuest();
                leftaudio.time = 0;
                leftaudio.Pause();
            }
            
            
        }
        if (QuestManager.currentquest == QuestManager.L3Task4 & !QuestManager.currentquest.isComplete & fadervalue > 0.5 & !isTimerRunning)
        {
            StartTimer();

        }
        if (QuestManager.currentquest == QuestManager.L3Final & !QuestManager.currentquest.isComplete & fadervalue < 0.9 & !isTimerRunning)
        {
            StartTimer();

        }*/
        //If Fader is in Middle
        if (QuestManager.currentquest == QuestManager.L3Task4 & !QuestManager.currentquest.isComplete & fadervalue > 0.95 )
        {
           
                hasturnedfaderleft = true;
         

        }
        if (QuestManager.currentquest == QuestManager.L3Final & !QuestManager.currentquest.isComplete & fadervalue < 0.05 )
        {
            hasturnedfaderright = true;

        }
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
        if (templeftvalue != leftaudio.volume & QuestManager.currentquest == QuestManager.L3Task1 & !QuestManager.currentquest.isComplete)
        {
            LeftVolumeSliderChangedValue = true;
        }
        else if (temprightvalue != rightaudio.volume & QuestManager.currentquest == QuestManager.L3Task2 & !QuestManager.currentquest.isComplete)
        {
            RightVolumeSliderChangedValue = true;
        }

    }
    public void StartTimer()
    {
        elapsedTime= 0;
        isTimerRunning = true;
    }

    // stop the timer and return the elapsed time
    public float StopTimer()
    {
        
        isTimerRunning = false;
        return elapsedTime;
    }
}
