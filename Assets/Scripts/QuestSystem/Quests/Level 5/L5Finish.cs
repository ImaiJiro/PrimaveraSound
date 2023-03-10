using UnityEngine;

public class L5Finish : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L5F Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L5Finish()
    {
        questName = "Level 5 :";
        questDescription = "Your Tutorial is done!! Go and Rock";
    }
}

