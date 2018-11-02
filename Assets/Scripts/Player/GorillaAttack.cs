using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaAttack : MonoBehaviour {

    public int attackDamage = 20;
    public int buildingAttackDamage = 35;
    public float timeBetweenAttacks = 0.15f;

    Collider currEnemy;
    bool enemyInRange;
    float timer;
    TankHealth enemyHealth;
    Animator anim;
    AudioSource attackAudio;
    GameObject[] enemies;


    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //enemyHealth = enemy.GetComponent<TankHealth>();
        attackAudio = GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyInRange = true;
            currEnemy = other;  
        }

    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyInRange = false;
            currEnemy = null;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Building" && Input.GetButtonDown("Fire1"))
        {
            BuildingHealth building = collision.gameObject.GetComponent<BuildingHealth>();

            if (building.currentHealth >= 0)
            {
                building.TakeDamage(buildingAttackDamage);
            }
            
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
                Attack(currEnemy);
            }

        }

        if (Input.anyKeyDown)
        {

            print(Input.inputString);

        }

    }



    void Attack(Collider other) { 

        TankHealth curr = other.gameObject.GetComponent<TankHealth>();

        Debug.Log("Tank Health: " + curr.currentHealth);
    
        if (curr.currentHealth >= 0)
        {
            curr.TakeDamage(attackDamage);
        }
    }

}
