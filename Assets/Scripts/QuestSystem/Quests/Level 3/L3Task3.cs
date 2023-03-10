using UnityEngine;

public class L3Task3 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L3T3 Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L3Task3()
    {
        questName = "Level 3 :";
        questDescription = "Play Audioclip at Deck 1";
    }
}

