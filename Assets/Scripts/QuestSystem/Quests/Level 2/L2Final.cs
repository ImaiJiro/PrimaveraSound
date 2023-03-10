using UnityEngine;

public class L2Final : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L2F Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L2Final()
    {
        questName = "Level 2 :";
        questDescription = "Play Deck 1 at the Outro Section of Deck 2 with right BPM";
    }
}

