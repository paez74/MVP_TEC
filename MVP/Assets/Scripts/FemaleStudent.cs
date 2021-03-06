﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FemaleStudent : MonoBehaviour
{
    public float radius;
    public float timer;

    private Transform target;

    private bool idle;
    public float idleTimer;
    private float currentIdleTimer;
    private NavMeshAgent agent;
    private float currentTimer;

    private Animation anim;

    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animation>();

        currentTimer = timer;
        currentIdleTimer = idleTimer;

    }

    void Update()
    {
        currentTimer += Time.deltaTime;
        currentIdleTimer += Time.deltaTime;

        if (currentIdleTimer >= idleTimer)
        {
            StartCoroutine("switchIdle");

        }

        if (currentTimer >= timer && !idle)
        {
            // se selecciona una nueva ruta despues de cierto tiempo para que el NPC siempre este caminando
            Vector3 newPosition = RandomNavSphere(transform.position, radius, -1);
            agent.SetDestination(newPosition);
            currentTimer = 0;
        }
        if (idle)
        {
            anim.CrossFade("GolfIdle");
        }
        else
        {
            anim.CrossFade("jog 2h");
        }

    }

    IEnumerator switchIdle()
    {
        idle = true;
        yield return new WaitForSeconds(3);
        currentIdleTimer = 0;
        idle = false;
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layerMask)
    {

        // crea una ubicacion random a la cual mandar al NPC
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layerMask);

        return navHit.position;
    }

}
