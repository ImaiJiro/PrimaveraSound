using UnityEngine;

public class L3Task5 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L3T5 Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L3Task5()
    {
        questName = "Level 3 :";
        questDescription = "Play Audio in Deck 2";
    }
}

