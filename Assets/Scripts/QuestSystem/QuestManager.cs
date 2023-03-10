using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public GameObject JogWheelLeftBlock;
    public GameObject JogWheelRightBlock;
    public GameObject EqBlock;
    public GameObject FaderSliderBlock;
    public GameObject VolumeBlock;
    public GameObject TempoBlockLeft;
    public GameObject TempoBlockRight;
    public GameObject ConnectWire;
    public GameObject ConnectHeadphones;
    //---------------------------------------------------Quests----------------------------------------------------------------------------
    public Quest currentquest;
    //--------------------------------------------------Level 0----------------------------------------------------------------------------
    public ConnectWires conectwires = new ConnectWires();
    public ConnectHeadphones conectheadphones = new ConnectHeadphones();
    //--------------------------------------------------Level 1----------------------------------------------------------------------------
    public L1Task1 L1Task1 = new L1Task1();
    public L1Task2 L1Task2 = new L1Task2();
    public L1Task3 L1Task3 = new L1Task3();
    public L1Final L1Final = new L1Final();
    //--------------------------------------------------Level 2----------------------------------------------------------------------------
    public L2Task0 L2Task0 = new L2Task0();
    public L2Task1 L2Task1 = new L2Task1();
    public L2Task2 L2Task2 = new L2Task2();
    public L2Final L2Final = new L2Final();
    //--------------------------------------------------Level 3----------------------------------------------------------------------------
    public L3Task0 L3Task0 = new L3Task0();
    public L3Task1 L3Task1 = new L3Task1();
    public L3Task2 L3Task2 = new L3Task2();
    public L3Task3 L3Task3 = new L3Task3();
    public L3Task4 L3Task4 = new L3Task4();
    public L3Task5 L3Task5 = new L3Task5();
    public L3Final L3Final = new L3Final();
    //--------------------------------------------------Level 4----------------------------------------------------------------------------
    public L4Task1 L4Task1 = new L4Task1();
    public L4Task2 L4Task2 = new L4Task2();
    public L4Task3 L4Task3 = new L4Task3();
    public L4Task4 L4Task4 = new L4Task4();
    //--------------------------------------------------Level 5----------------------------------------------------------------------------
    public L5Finish L5Finish = new L5Finish();

    // Start is called before the first frame update
    void Start()
    {
        currentquest = conectwires;
        Debug.Log(currentquest.questName);
        currentquest.StartQuest();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentquest == conectwires)
        {
            ConnectWire.SetActive(true);
            ConnectHeadphones.SetActive(false);
        }
        else if (currentquest == conectheadphones)
        {
            ConnectWire.SetActive(false);
            ConnectHeadphones.SetActive(true);
        }
        else
        {
            ConnectWire.SetActive(false);
            ConnectHeadphones.SetActive(false);
        }
        if (currentquest == conectwires)
        {
            JogWheelLeftBlock.SetActive(false);
            JogWheelRightBlock.SetActive(false);
            EqBlock.SetActive(false);
            FaderSliderBlock.SetActive(false);
            VolumeBlock.SetActive(false);
            TempoBlockLeft.SetActive(false);
            TempoBlockRight.SetActive(false);
        }
    }
}
