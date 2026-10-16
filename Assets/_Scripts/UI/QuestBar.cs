using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestBar : MonoBehaviour
{
    public TMP_Text ContextText;
    public Image IconHolder, QuestBarBG;
    public List<Sprite> Sprites;

    public Quest Quest;
    public QuestState State = QuestState.NotStarted;

    private void Start()
    {
        IconHolder.sprite = Sprites[0];
        SetQuest(this.Quest);
    }
    public void SetQuest(Quest quest)
    {
        this.Quest = quest;
        IconHolder.sprite = Sprites[0];
        ContextText.text = quest.context;
    }
    public void CompleteQuest()
    {
        IconHolder.sprite = Sprites[1];
        State = QuestState.Completed;
    }
    public enum QuestState
    {
        NotStarted,
        InProgress,
        Completed
    }
}