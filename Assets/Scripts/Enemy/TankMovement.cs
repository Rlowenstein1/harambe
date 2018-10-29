using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankMovement : MonoBehaviour {

    

    Transform player;
    GorillaHealth playerHealth;
    TankHealth enemyHealth;
    NavMeshAgent nav;


    void Awake (){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<GorillaHealth>();
        enemyHealth = GetComponent<TankHealth>();
        nav = GetComponent<NavMeshAgent>();
    }

	
	// Update is called once per frame
	void Update () {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }

    }
}
