using System;

public class Quest
{
    public string questName;
    public string questDescription;
    public bool isComplete;

    public event Action<Quest> OnQuestStarted;
    public event Action<Quest> OnQuestCompleted;

    public virtual void StartQuest()
    {
        isComplete = false;
        OnQuestStarted?.Invoke(this);
    }

    public virtual void CompleteQuest()
    {
        isComplete = true;
        OnQuestCompleted?.Invoke(this);
    }
}

