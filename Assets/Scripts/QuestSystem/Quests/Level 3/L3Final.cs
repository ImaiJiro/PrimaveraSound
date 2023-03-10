using UnityEngine;

public class L3Final : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L3F Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L3Final()
    {
        questName = "Level 3 :";
        questDescription = "Use Fader Slider for transition (Deck 1 -> Deck 2)";
    }
}

