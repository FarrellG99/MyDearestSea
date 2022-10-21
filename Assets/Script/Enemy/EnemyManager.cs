using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoint;
    public GameObject m_EnemyPrefab;
    public GameObject FilterOn;
    private float nextActionTime = 0.0f;
    public float period;

    public float TimeLeft;
    public bool timeOn = false;
    public Text TimerText;

    public GameObject disable;
    public GameObject WinConditional;

    void Start()
    {
        
    }
    private void Update()
    {
        

        if (timeOn)
        {
            StartCoroutine("delete");
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTime(TimeLeft);
            }
            else
            {
                Time.timeScale = 0;
                WinConditional.SetActive(true);
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                timeOn = false;
            }
        }

    }
    IEnumerator delete()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            SpawnNewEnemy();
        }
        yield return new WaitForSeconds(5f);
        disable.SetActive(false);
        EnemyHealth.OnEnemyKilled += SpawnNewEnemy;
    }
    private void OnEnable()
    {
        timeOn = true;
        
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
