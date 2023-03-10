using UnityEngine;

public class L3Task2 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L3T2 Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L3Task2()
    {
        questName = "Level 3 :";
        questDescription = "Use and Test Right Deck Volume Slider";
    }
}

