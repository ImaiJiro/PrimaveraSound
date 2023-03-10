using UnityEngine;

public class L2Task0 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("LoadClip Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L2Task0()
    {
        questName = "Level 2 :";
        questDescription = "Browse to Load Clips into both Decks";
    }
}

