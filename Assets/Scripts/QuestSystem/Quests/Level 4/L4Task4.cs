using UnityEngine;

public class L4Task4 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L4F Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L4Task4()
    {
        questName = "Level 4 :";
        questDescription = "Use and Test Master EQ Filter";
    }
}

