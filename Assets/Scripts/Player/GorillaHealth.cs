using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaHealth : MonoBehaviour {

    public int startingHealth = 1000000;
    public int currentHealth;

    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool damaged;

    private void Awake()
    {
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        damaged = true;

        //enemyAudio.Play();

        currentHealth -= amount;

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        //playerShooting.DisableEffects();

        //anim.SetTrigger("Die");

        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
    }

}
