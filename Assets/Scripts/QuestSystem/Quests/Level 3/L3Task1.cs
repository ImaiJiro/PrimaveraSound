using UnityEngine;

public class L3Task1 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L3T1 Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L3Task1()
    {
        questName = "Level 3 :";
        questDescription = "Use and Test Left Deck Volume Slider";
    }
}

