using UnityEngine;

public class L4Task1 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L4T1 Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L4Task1()
    {
        questName = "Level 4 :";
        questDescription = "Use and Test Low EQ Filter";
    }
}

