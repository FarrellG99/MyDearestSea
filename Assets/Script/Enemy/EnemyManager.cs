using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoint;
    public GameObject m_EnemyPrefab;

    private float nextActionTime = 0.0f;
    public float period;
    void Start()
    {
        
    }
    private void Update()
    {
        if(Time.time > nextActionTime)
        {
            nextActionTime += period;
            SpawnNewEnemy();
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
}
