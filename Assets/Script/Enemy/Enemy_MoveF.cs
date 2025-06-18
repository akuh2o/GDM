using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_MoveF : MonoBehaviour
{
    [SerializeField] Transform _target;
    NavMeshAgent _agent;
    colider _vida;
    private bool _isRange = false;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _vida = GetComponent<colider>();
    }

    void Update()
    {
        if (_vida.vida > 0 && _isRange)
        {
            _agent.SetDestination(_target.position);
        }
        if (_vida.vida <= 0)
        {
            _agent.enabled = false;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isRange = true;
            _agent.speed = 2;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isRange = false;
            _agent.speed = 1.5f;
        }
    }
}
