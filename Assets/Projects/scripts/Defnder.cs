using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Defnder : MonoBehaviour
{
    [SerializeField] Transform ponit;
    NavMeshAgent myNavMeshAgent;
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myNavMeshAgent.SetDestination(ponit.transform.position);
        }

    }
}
