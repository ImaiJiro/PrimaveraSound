using UnityEngine;

public class L2Task1 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("TempoTest Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L2Task1()
    {
        questName = "Level 2 :";
        questDescription = "Play Deck 2 and Test Tempo/BPM Slider";
    }
}

