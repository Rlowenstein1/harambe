using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaAttack : MonoBehaviour {

    public int attackDamage = 20;
    public float timeBetweenAttacks = 0.15f;

    bool enemyInRange;
    float timer;
    TankHealth enemyHealth;
    Animator anim;
    AudioSource attackAudio;
    GameObject enemy;


    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<TankHealth>();
        attackAudio = GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if ( Input.GetButtonDown("Fire1") && timer >= timeBetweenAttacks && Time.timeScale != 0) 
        {
            timer = 0f;
            print("fire Pressed");
            attackAudio.Play();

            if(enemyInRange){
                Attack();
            }

        }

        if (Input.anyKeyDown)
        {

            print(Input.inputString);

        }

    }



    void Attack()
    {
        if (enemyHealth.currentHealth >= 0)
        {
            enemyHealth.TakeDamage(attackDamage);
        }
    }


}
