using UnityEngine;

public class L1Task3 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L1T3 Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L1Task3()
    {
        questName = "Level 1 :";
        questDescription = "Load Audio Clip into Deck 2";
    }
}

