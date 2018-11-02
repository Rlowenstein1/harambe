using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    public GameObject prefabBuilding = null;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            var damagedBuilding = Instantiate(prefabBuilding, transform.position, Quaternion.identity);
            damagedBuilding.gameObject.tag = "Building";
            damagedBuilding.AddComponent<BuildingHealth>();
        }
    }

}
