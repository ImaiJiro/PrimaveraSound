using UnityEngine;

public class L4Task2 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L4T2 Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L4Task2()
    {
        questName = "Level 4 :";
        questDescription = "Use and Test Mid EQ Filter";
    }
}

