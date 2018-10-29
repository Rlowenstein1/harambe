using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankHealth : MonoBehaviour {

    public int startingHealth = 100;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public int currentHealth;

    Animator anim;
    BoxCollider boxCollider;
    bool isDead;
    bool isSinking;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        currentHealth = startingHealth;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // If the enemy should be sinking...
        if (isSinking)
        {
            // ... move the enemy down by the sinkSpeed per second.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }

    }

    public void TakeDamage (int amount){
        if(isDead){
            return;
        }

        //TODO: Add tank getting attacked audio 
        print("Tank is taking damage");
        currentHealth -= amount;

        if(currentHealth <= 0){

            Death();

        }
    }

    public void Death(){
        isDead = true;
        boxCollider.isTrigger = true;

        //Set trigger on tank animator to play the death animation
        anim.SetTrigger("Explode");

        //TODO: Add dead animation and audio here
    }

    public void StartSinking(){
        //.enabled means just turning this particular componet off
        //instead of the whole game object
        //use .SetActive to access the whole game object
        GetComponent<NavMeshAgent>().enabled = false;

        //Since we are moving a collider in a scene here we,
        //turn kinematic on so that unity will ignore this G.Obj 
        //when recalculating the static geometry
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;

        Destroy(gameObject, 2f);
    }

}
