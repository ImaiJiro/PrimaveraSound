using UnityEngine;

public class L3Task4 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L3T4 Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L3Task4()
    {
        questName = "Level 3 :";
        questDescription = "Slide the fader slider to left";
    }
}

