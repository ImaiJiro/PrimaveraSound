using UnityEngine;

public class L2Task2 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("Jog Wheel Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L2Task2()
    {
        questName = "Level 2 :";
        questDescription = "Use and Test DJ Jog Wheel";
    }
}

