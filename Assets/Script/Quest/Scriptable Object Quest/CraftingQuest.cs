using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest Object", menuName ="Quest System/Crafting")]
public class CraftingQuest : QuestSO
{
    void Awake() {
        goalType = GoalType.Crafting; 
        currentAmount = 0;
    }
}
