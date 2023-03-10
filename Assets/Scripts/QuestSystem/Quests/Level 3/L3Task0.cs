using UnityEngine;

public class L3Task0 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L3T0 Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L3Task0()
    {
        questName = "Level 3 :";
        questDescription = "Browse to Load Audioclips into both Decks";
    }
}

