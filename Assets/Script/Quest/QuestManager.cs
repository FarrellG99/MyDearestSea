using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    // public Quest quest;
    public List<QuestSO> questSOList = new List<QuestSO>();

    public GameObject player;
    public QuestGoal goal;
    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDesc;

    public GameObject panelQuestComplete;
    public TextMeshProUGUI completeText;
    public InventoryObject junkInventory;
    public InventoryObject toolInventory;
    public string namaItem;

    public GameObject invsWall1;
    public GameObject invsWall2;
    public GameObject invsWall3;

    int open1, open2;

    int index;
    float timer = 0;
    int timerIndex;

    bool questSelesai = false;

    void Start()
    {
        index = 0;
        namaItem = questSOList[index].ItemName;
        CetakQuest(index, namaItem);
        //Debug.Log(goal.currentAmount.ToString());
    }

    void Update(){
        Debug.Log(index.ToString());
        if (questSelesai)
        {
            if (questSOList[index].questCount == 1)
            {
                open1 = 1;
            }
            if (questSOList[index].questCount == 2)
            {
                open2 = 1;
            }
            Debug.Log(open1 + " " + open2);
            if (open1 == 1 && open2 == 1)
            {
                invsWall1.SetActive(false);
                invsWall2.SetActive(false);
            }
            timer = 3;
            timerIndex = index;
            index += 1;
            questSelesai = false;
        }

        //Tampilkan quest selesai
        if (timer > 0)
        {
            panelQuestComplete.SetActive(true);
            completeText.text = questSOList[timerIndex].title + " Telah selesai.";
            timer -= Time.deltaTime;
            Debug.Log(timer);
        } else {
            timerIndex = -1;
            panelQuestComplete.SetActive(false);
            completeText.text = "";
        }
        namaItem = questSOList[index].ItemName;
        CetakQuest(index, namaItem);
    }

    void CetakQuest(int index, string item)
    {
        if (questSOList[index].goalType == GoalType.Gathering && questSelesai == false)
        {
            if (questSOList[index].currentAmount >= questSOList[index].requiredAmount)
            {
                questSelesai = true;
            }
            questSOList[index].currentAmount = junkInventory.ContainsItemString(item);
            questTitle.text = questSOList[index].title;
            questDesc.text = questSOList[index].description + "(" + questSOList[index].currentAmount + "/" + questSOList[index].requiredAmount + ")";
        } else if (questSOList[index].goalType == GoalType.Crafting) {
            if (questSOList[index].currentAmount >= questSOList[index].requiredAmount)
            {
                questSelesai = true;
            }
            questSOList[index].currentAmount = toolInventory.ContainsItemString(item);
            questTitle.text = questSOList[index].title;
            questDesc.text = questSOList[index].description + "(" + questSOList[index].currentAmount + "/" + questSOList[index].requiredAmount + ")";
        }
    }

    private void OnApplicationQuit() {
        for (int i = 0; i < questSOList.Count; i++)
        {
            questSOList[i].currentAmount = 0;
            Debug.Log("OK");
        }
    }
}
