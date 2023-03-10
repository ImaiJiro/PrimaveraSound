using UnityEngine;

public class L4Task3 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L4T3 Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L4Task3()
    {
        questName = "Level 4 :";
        questDescription = "Use and Test High EQ Filter";
    }
}

