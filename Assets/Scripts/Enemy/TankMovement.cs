﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TankMovement : MonoBehaviour {

    

    Transform player;
    GorillaHealth playerHealth;
    TankHealth enemyHealth;
    NavMeshAgent navMeshAgent;


    void Awake (){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<GorillaHealth>();
        enemyHealth = GetComponent<TankHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.Log("NavMeshAgent Componet Missing!");
        }
    }

	
	// Update is called once per frame
	void Update () {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 )
        {
            float step = .2f * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(navMeshAgent.transform.forward, player.position, step, 0.0f);
            navMeshAgent.transform.rotation = Quaternion.LookRotation(newDir);
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            navMeshAgent.enabled = false;
        }

    }
}
