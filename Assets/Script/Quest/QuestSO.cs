using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoalType{
        Gathering,
        Crafting,
    }
public class QuestSO : ScriptableObject
{
    public bool isActive;

    public string title;
    public string description;
    public int questCount;

    public QuestGoal goal;
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmount = 0;
    public string ItemName;
    public bool isReached(){
        return (currentAmount >= requiredAmount);
    }
    
}
