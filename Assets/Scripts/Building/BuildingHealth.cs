using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    public GameObject prefabBuilding = null;

    public GameObject dustParticles = null;
    public GameObject dust = null;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    // Use this for initialization
    void Start()
    {
        dustParticles = GameObject.FindGameObjectWithTag("Dust");
        dust = Instantiate(dustParticles, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // When attacked, emit particles from the prefab for a duration
        ParticleSystem ps = dust.GetComponent<ParticleSystem>();
        ps.Emit(2000);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);

            if (prefabBuilding != null)
            {
                // Instantiate new damaged building model in place of the current
                var damagedBuilding = Instantiate(prefabBuilding, transform.position, Quaternion.identity);
                damagedBuilding.gameObject.tag = "Building";
                damagedBuilding.AddComponent<BuildingHealth>();
            }
        }
    }
}
