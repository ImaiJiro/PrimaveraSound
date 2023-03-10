using UnityEngine;

public class ConnectWires : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("ConnectWires Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public ConnectWires()
    {
        questName = "Level 0 :";
        questDescription = "Connect the wires to start the DJ Controller";
    }
}
