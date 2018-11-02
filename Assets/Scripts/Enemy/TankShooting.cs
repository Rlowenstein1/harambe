using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour {

    public int damagePerShot = 20;
    public float timeBetweenBullets = 2f;
    public float range = 100f;
    public int attackDamage = 10;

    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    GameObject player;
    GameObject tank;
    GorillaHealth playerHealth;
    TankHealth health;
    bool playerInRange;
    Vector3 playerP1;
    Vector3 playerP2;


    private void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        tank = GameObject.FindGameObjectWithTag("Enemy");
        health = tank.GetComponent<TankHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<GorillaHealth>();
        playerP1 = playerP2 = player.transform.position;

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        playerP1 = playerP2;
        playerP2 = player.transform.position;
        Vector3 delta = playerP2 - playerP1;

        if(playerInRange)
        {
            Debug.Log("Looking at Harambe");
            Vector3 aimVector = player.transform.position - transform.position;
            float step = .2f * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(tank.transform.forward, aimVector, step, 0.0f);
            tank.transform.rotation = Quaternion.LookRotation(newDir);
        }

        if (timer >= timeBetweenBullets && playerInRange && playerHealth.currentHealth > 0 && health.currentHealth > 0)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }

    }

    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
       

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            GorillaHealth gorillaHealth = shootHit.collider.GetComponentInParent<GorillaHealth>();
            //shootHit.collider.
            if (gorillaHealth != null)
            {
                gorillaHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }

}
