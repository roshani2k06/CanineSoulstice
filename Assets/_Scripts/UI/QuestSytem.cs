using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static QuestBar;

public class QuestSytem : MonoBehaviour
{
    public List<QuestBar> QuestBar;
    public List<Color> Colors = new List<Color>();

    private void Start()
    {
        QuestBar[0].State = QuestState.InProgress;
        InitializeQuests();
    }
    public void FinishQuest(int index)
    {
        QuestBar[index].CompleteQuest();

        if (index < QuestBar.Count - 1)
        {
            QuestBar[index + 1].State = QuestState.InProgress;
        }
        InitializeQuests();
    }
    public void InitializeQuests()
    {
        foreach (QuestBar quest in QuestBar)
        {
            if (quest.State == QuestState.NotStarted)
            {
                quest.IconHolder.color = Color.white;
                Color color = Colors[0];
                color.a = 0.10f;
                quest.QuestBarBG.color = color;
            }
            else if (quest.State == QuestState.InProgress)
            {
                Color color = Colors[1];
                quest.IconHolder.color = color;
                color.a = 0.10f;
                quest.QuestBarBG.color = color;
            }
            else if (quest.State == QuestState.Completed)
            {
                Color color = Colors[2];
                quest.IconHolder.color = color;
                color.a = 0.10f;
                quest.QuestBarBG.color = color;
            }
        }
    }
}

[Serializable]
public class Quest
{
    public string context;
}

