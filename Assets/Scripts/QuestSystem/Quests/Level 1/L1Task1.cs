using UnityEngine;

public class L1Task1 : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("ClickBrowse Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L1Task1()
    {
        questName = "Level 1 :";
        questDescription = "Load Audio Clip into Deck 1";
    }
}

