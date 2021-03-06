﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class GorillaHealth : MonoBehaviour {

    public int startingHealth = 100;
    public Slider healthSlider;
    public int currentHealth;
    public Animator anim;
    ParticleSystem hitParticles;
    //CapsuleCollider capsuleCollider;
    public bool isDead;
    bool damaged;

    private void Awake()
    {
        hitParticles = GetComponentInChildren<ParticleSystem>();
        //capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        healthSlider.value = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        damaged = true;

        //enemyAudio.Play();

        currentHealth -= amount;
        healthSlider.value = currentHealth;

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
        anim.SetTrigger("Die");
        StartCoroutine(RestartGame());
        //playerShooting.DisableEffects();

        //anim.SetTrigger("Die");

        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("gameMenu");
    }

}
