using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCutdownFilter : MonoBehaviour
{
    public float TimeLeft;
    public bool timeOn = false;
    public Text TimerText;

    void Start()
    {
        timeOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeOn)
        {
            if(TimeLeft >0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTime(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                timeOn = false;
            }
        }
    }

    void UpdateTime(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float second = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00} : {1:00}", minutes, second);
    }
}
