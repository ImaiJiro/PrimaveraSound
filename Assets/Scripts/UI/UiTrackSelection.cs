using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiTrackSelection : MonoBehaviour
{
    public GameObject TrackSelectorRight;
    public GameObject TrackSelectorLeft;
    public TMP_Text NameofQuest;
    public TMP_Text DescriptionofQuest;
    public QuestManager QuestManager;
    private void Start()
    {
        TrackSelectorLeft.SetActive(false);
        TrackSelectorRight.SetActive(false);
    }
    private void Update()
    {
       DescriptionofQuest.text = QuestManager.currentquest.questDescription;
        NameofQuest.text = QuestManager.currentquest.questName;
    }
    public void BrowseLeft()
    {
        TrackSelectorLeft.SetActive(true);
        TrackSelectorRight.SetActive(false);
    }
    public void BrowseRight()
    {
        TrackSelectorRight.SetActive(true);
        TrackSelectorLeft.SetActive(false);
    }
    public void HideBothSelector() {
        TrackSelectorLeft.SetActive(false);
        TrackSelectorRight.SetActive(false);
    }
}
