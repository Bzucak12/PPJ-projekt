using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public GameObject questEntryPrefab;
    public Transform questsParent;

    private List<Quest> activeQuests = new();

    void Start()
    {
        // testovací úkoly
        AddQuest(new Quest { title = "Najdi ztracený klíč", description = "Klíč by měl být někde u starého mlýna.", isCompleted = false });
    }

    public void AddQuest(Quest quest)
    {
        activeQuests.Add(quest);
        GameObject entry = Instantiate(questEntryPrefab, questsParent);
        Text[] texts = entry.GetComponentsInChildren<Text>();
        texts[0].text = quest.title;
        texts[1].text = quest.description;
    }
}