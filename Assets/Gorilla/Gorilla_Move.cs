using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorilla_Move : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, -1 * speed * Input.GetAxis("Vertical") * Time.deltaTime, 0f);
	}
}
