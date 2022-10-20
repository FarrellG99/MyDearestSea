using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest Object", menuName ="Quest System/Gathering")]
public class GatheringQuest : QuestSO
{
    void Awake() {
        goalType = GoalType.Gathering; 
        currentAmount = 0;
    }
}
