using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public GameObject player;
    public Canvas objectives;
    public GameObject escapeArea;
    public GameObject[] tankSpawners;
    public GameObject tank;
    public bool tankNumControl;
    public int numTanks;
    public bool escapeAllowed;
    public bool tanksAllowed;
    //private bool multipleObjs;

    private Text objText;
    private string[] objectiveList;
    private string obj1 = "Kill 1 tank";
    private string obj2 = "Escape the City";
    //private string obj3 = "Destroy 3 buildings";

    private GameObject[] aliveTanks;

    private Objective currObj;

     class Objective {

        public string objective;
        public int objIndex;

        public Objective(string s, int i) {
            objective = s;
            objIndex = i;

        }

    }

	// Use this for initialization
	void Start () {
        Objective objective0 = new Objective(obj1, 0);
        Objective objective1 = new Objective(obj2, 1);
        //Objective objective2 = new Objective(obj3, 2);

        Objective[] objs = new Objective[] {objective0, objective1};

        if (tanksAllowed && escapeAllowed)
        {
            currObj = objs[Random.Range(0, 1)]; 
        }
        else if (tanksAllowed && !escapeAllowed)
        {
            currObj = objs[0];
        }
        else if (!tanksAllowed && escapeAllowed)
        {
            currObj = objs[1];
        }
        else { }

        objText = objectives.GetComponentInChildren<Text>();

        if (currObj.objIndex == 0)
        {
            SpawnTanks();
        }
        else {
            objText.text = currObj.objective;
        }
       
    }
	
	// Update is called once per frame
	void Update () {
        int curr = currObj.objIndex;
        aliveTanks = GameObject.FindGameObjectsWithTag("Enemy");

        switch (curr)
        {
            case 0:
                int enemiesLeft = aliveTanks.Length;
                if (enemiesLeft == 1) {
                    objText.text = "Kill " + enemiesLeft + " tank";
                } else {
                    objText.text = "Kill " + enemiesLeft + " tanks";
                }

                if (enemiesLeft <= 0) {
                    objText.text = "You Win!";
                }
                break;
            case 1:
                if (player.transform.position.x >= escapeArea.transform.position.x && player.transform.position.z >= escapeArea.transform.position.z) {
                    objText.text = "You Win!";
                }
                break;
            case 2:
                break;

        }
        
	}

    void SpawnTanks() {

        if (!tankNumControl) {
            numTanks = Random.Range(0, tankSpawners.Length);
            Debug.Log("Num tanks: " + numTanks);
        }

        for (int i = 0; i < numTanks; i++) {
            Instantiate(tank, tankSpawners[Random.Range(0, tankSpawners.Length)].transform);
            Debug.Log("Tank Created");
        }

        aliveTanks = GameObject.FindGameObjectsWithTag("Enemy");
        objText.text = "Kill " + numTanks + " tanks";
    }
}
