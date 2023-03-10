using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMiddleMan : MonoBehaviour
{
    public DJControllerwTracks controller1;
    public DJControllerwTracks controller2;
    public VolumeControl volumeControl;
    public QuestManager QuestManager;
    public GameObject Level1Finish;
    public GameObject Level2Finish;
    public int hasloadedclipl2 = 0;
    public int hasloadedclipl3 = 0;
    public int loweqdone = 0;
    public int mideqdone = 0;
    public int higheqdone = 0;
    public int mastereqdone = 0;
    private void Start()
    {
        Level1Finish.SetActive(false);
        controller1.iamcontroller1 = true;
        controller2.iamcontroller2 = true;
    }
    private void Update()
    {
        if (controller1.hasloadedclip == true & QuestManager.currentquest == QuestManager.L1Task1 & !QuestManager.currentquest.isComplete) 
        { 
            controller1.hasloadedclip= false;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L1Task2;
            QuestManager.currentquest.StartQuest();

        }
        if (controller1.hasplayedclip == true & QuestManager.currentquest == QuestManager.L1Task2 & !QuestManager.currentquest.isComplete)
        {
            controller1.hasplayedclip= false;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L1Task3;
            QuestManager.currentquest.StartQuest();

        }
        if (controller2.hasloadedclip == true & QuestManager.currentquest == QuestManager.L1Task3 & !QuestManager.currentquest.isComplete)
        {
            controller2.hasloadedclip= false;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L1Final;
            QuestManager.currentquest.StartQuest();

        }
        if (controller2.hasplayedclip == true & QuestManager.currentquest == QuestManager.L1Final & !QuestManager.currentquest.isComplete)
        {
            StartCoroutine(Level2Task0(10f));
            controller1.ResetControls();

        }
        if (hasloadedclipl2 == 2 & QuestManager.currentquest == QuestManager.L2Task0 & !QuestManager.currentquest.isComplete)
        {
            hasloadedclipl2 = 0;
            controller1.hasdonel2loading = false;
            controller2.hasdonel2loading= false;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L2Task1;
            QuestManager.currentquest.StartQuest();

        }
        if (controller2.hastestedtempo == true & QuestManager.currentquest == QuestManager.L2Task1 & !QuestManager.currentquest.isComplete)
        {
            controller2.hastestedtempo = false;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L2Task2;
            QuestManager.currentquest.StartQuest();

        }
        if (controller2.hastestedjogwheel == true & QuestManager.currentquest == QuestManager.L2Task2 & !QuestManager.currentquest.isComplete)
        {
            controller2.hastestedjogwheel = false;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L2Final;
            QuestManager.currentquest.StartQuest();
            controller2.audioSource.time = 0;

        }
        if (controller1.hasplayedclipl2 == true & QuestManager.currentquest == QuestManager.L2Final & !QuestManager.currentquest.isComplete)
        {
            StartCoroutine(Level3Task1(10f));
        }
        if (hasloadedclipl3 == 2 & QuestManager.currentquest == QuestManager.L3Task0 & !QuestManager.currentquest.isComplete)
        {
            hasloadedclipl3 = 0;
            controller1.hasdonel3loading = false;
            controller2.hasdonel3loading = false;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L3Task1;
            QuestManager.currentquest.StartQuest();
            controller1.audioSource.time = 0;
            controller1.audioSource.Play();
            controller2.audioSource.time = 0;
            controller2.audioSource.Pause();

        }
        if (volumeControl.LeftVolumeSliderChangedValue == true & QuestManager.currentquest == QuestManager.L3Task1 & !QuestManager.currentquest.isComplete)
        {
            volumeControl.LeftVolumeSliderChangedValue = false;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L3Task2;
            QuestManager.currentquest.StartQuest();
            controller1.audioSource.time = 0;
            controller1.audioSource.Pause();
            controller2.audioSource.time = 0;
            controller2.audioSource.Play();

        }
        if (volumeControl.RightVolumeSliderChangedValue == true & QuestManager.currentquest == QuestManager.L3Task2 & !QuestManager.currentquest.isComplete)
        {
            volumeControl.RightVolumeSliderChangedValue = false;
            StartCoroutine(Level3Task2(3));
            

        }
        if (controller1.hasplayedclipl3deck1 == true & QuestManager.currentquest == QuestManager.L3Task3 & !QuestManager.currentquest.isComplete)
        {
            controller1.hasplayedclipl3deck1 = false;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L3Task4;
            QuestManager.currentquest.StartQuest();

        }
        if (volumeControl.hasturnedfaderleft == true & QuestManager.currentquest == QuestManager.L3Task4 & !QuestManager.currentquest.isComplete)
        {

            volumeControl.hasturnedfaderleft = false;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L3Task5;
            QuestManager.currentquest.StartQuest();
        }
        if (controller2.hasplayedclipl3deck2 == true & QuestManager.currentquest == QuestManager.L3Task5 & !QuestManager.currentquest.isComplete)
        {

            controller1.hasplayedclipl3deck2 = false;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L3Final;
            QuestManager.currentquest.StartQuest();
        }
        if (volumeControl.hasturnedfaderright == true & QuestManager.currentquest == QuestManager.L3Final & !QuestManager.currentquest.isComplete)
        {
            volumeControl.hasturnedfaderright= false;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L4Task1;
            QuestManager.currentquest.StartQuest();
            controller1.SettempEq();
            controller2.SettempEq();
            controller1.ResetControls();
        }
        if (loweqdone == 2 & QuestManager.currentquest == QuestManager.L4Task1 & !QuestManager.currentquest.isComplete)
        {
            loweqdone = 0;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L4Task2;
            QuestManager.currentquest.StartQuest();
            controller1.SettempEq();
            controller2.SettempEq();
        }
        if (mideqdone == 2 & QuestManager.currentquest == QuestManager.L4Task2 & !QuestManager.currentquest.isComplete)
        {
            mideqdone = 0;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L4Task3;
            QuestManager.currentquest.StartQuest();
            controller1.SettempEq();
            controller2.SettempEq();
        }
        if (higheqdone == 2 & QuestManager.currentquest == QuestManager.L4Task3 & !QuestManager.currentquest.isComplete)
        {
            higheqdone = 0;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L4Task4;
            QuestManager.currentquest.StartQuest();
            controller1.SettempEq();
            controller2.SettempEq();
        }
        if (mastereqdone == 2 & QuestManager.currentquest == QuestManager.L4Task4 & !QuestManager.currentquest.isComplete)
        {
            mastereqdone = 0;
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L5Finish;
            QuestManager.currentquest.StartQuest();
            controller1.SettempEq();
            controller2.SettempEq();
        }
    }
    public void ConnectWires()
    {
        if (QuestManager.currentquest == QuestManager.conectwires)
        {
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.conectheadphones;
            QuestManager.currentquest.StartQuest();
        }
    }
    public void ConnectHeadphones()
    {
        if (QuestManager.currentquest == QuestManager.conectheadphones)
        {
            QuestManager.currentquest.CompleteQuest();
            QuestManager.currentquest = QuestManager.L1Task1;
            QuestManager.currentquest.StartQuest();
        }
    }
    IEnumerator Level2Task0(float time)
    {
        controller2.hasplayedclip = false;
        QuestManager.currentquest.CompleteQuest();
        yield return new WaitForSeconds(time);
        Level1Finish.SetActive(true);
    }
    IEnumerator Level3Task1(float time)
    {
        controller1.hasplayedclipl2 = false;
        QuestManager.currentquest.CompleteQuest();
        yield return new WaitForSeconds(time);
        Level2Finish.SetActive(true);
    }
    public void Level1Finished()
    {
       
        QuestManager.currentquest = QuestManager.L2Task0;
        controller1.loadedAudioData = null;
        controller2.loadedAudioData = null;
        controller1.audioSource.time = 0;
        controller2.audioSource.time = 0;
        controller1.audioSource.Pause();
        controller2.audioSource.Pause();
        QuestManager.currentquest.StartQuest();
        Level1Finish.SetActive(false);
    }
    public void Level2Finished()
    {
        QuestManager.currentquest = QuestManager.L3Task0;
        QuestManager.currentquest.StartQuest();
        controller1.audioSource.time = 0;
        controller1.audioSource.Pause();
        controller2.audioSource.time = 0;
        controller2.audioSource.Pause();
        controller1.loadedAudioData = null;
        controller2.loadedAudioData = null;
        controller1.ResetControls();
        Level2Finish.SetActive(false);
    }
    IEnumerator Level3Task2(float time)
    {
        yield return new WaitForSeconds(time);
        QuestManager.currentquest.CompleteQuest();
        QuestManager.currentquest = QuestManager.L3Task3;
        QuestManager.currentquest.StartQuest();
        controller1.audioSource.time = 0;
        controller1.audioSource.Pause();
        controller2.audioSource.time = 0;
        controller2.audioSource.Pause();
    }
}
