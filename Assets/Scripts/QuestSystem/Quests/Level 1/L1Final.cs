using UnityEngine;

public class L1Final : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("L1TF Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public L1Final()
    {
        questName = "Level 1 :";
        questDescription = "Play Deck 2 at the Outro Section of Deck 1";
    }
}

