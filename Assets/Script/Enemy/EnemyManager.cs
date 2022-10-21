using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoint;
    public GameObject m_EnemyPrefab;
    public GameObject FilterOn;
    public GameObject PanelWinner;
    private float nextActionTime = 0.0f;
    public float period;

    public float TimeLeft;
    public bool timeOn = false;
    public Text TimerText;
    void Start()
    {
        timeOn = true;
    }
    private void Update()
    {
        if(Time.time > nextActionTime)
        {
            nextActionTime += period;
            SpawnNewEnemy();
        }

        if (timeOn)
        {
            if (TimeLeft > 0)
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


            if(TimeLeft == 0)
            {
                PanelWinner.SetActive(true);
                Time.timeScale = 0f;
            }
        }

    }
    private void OnEnable()
    {
        EnemyHealth.OnEnemyKilled += SpawnNewEnemy;
    }


    void SpawnNewEnemy()
    {
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, m_SpawnPoint.Length-   1));
        Instantiate(m_EnemyPrefab, m_SpawnPoint[randomNumber].transform.position, Quaternion.identity);
    }
    void UpdateTime(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float second = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00} : {1:00}", minutes, second);
    }
}
