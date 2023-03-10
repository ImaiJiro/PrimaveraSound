using UnityEngine;

public class ConnectHeadphones : Quest
{

    public override void StartQuest()
    {
        base.StartQuest();
        Debug.Log("ConnectHeadphones Started");
    }

    public override void CompleteQuest()
    {
        base.CompleteQuest();
        Debug.Log("Mission Successful");
    }
    public ConnectHeadphones()
    {
        questName = "Level 0 :";
        questDescription = "Connect the headphones";
    }
}
