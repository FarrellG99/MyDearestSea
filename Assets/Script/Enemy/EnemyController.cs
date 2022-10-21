using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public string AttackToTag;

    protected NavMeshAgent enemyMesh;
    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        enemyMesh.SetDestination(GameObject.FindGameObjectWithTag(AttackToTag).transform.position);
    }
}
