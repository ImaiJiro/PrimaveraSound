using UnityEngine;

public class L1Task2 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L1T2 Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L1Task2()
    {
        questName = "Level 1 :";
        questDescription = "Play Deck 1";
    }
}

