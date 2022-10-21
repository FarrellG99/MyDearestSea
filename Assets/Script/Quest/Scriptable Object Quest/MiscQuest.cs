using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest Object", menuName ="Quest System/Misc")]
public class MiscQuest : QuestSO
{
    void Awake() {
        goalType = GoalType.Misc; 
        currentAmount = 0;
    }
}
