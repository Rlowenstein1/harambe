using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gorilla_Move : MonoBehaviour {

    Quaternion targetRotation;
    public float speed, forward, turn;
    Rigidbody gorilla;
    public Animator anim;

    public Quaternion Rotation
    {
        get { return targetRotation; }
    }

	// Use this for initialization
	void Start () {
        speed = 20f;
        targetRotation = transform.rotation;
        gorilla = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        forward = 0;
        turn = 0;
        anim.applyRootMotion = true;
    }
	
	// Update is called once per frame
	void Update () {
        forward = Input.GetAxis("Vertical");
        turn = Input.GetAxis("Horizontal");
       
        //anim.SetFloat("velx", turn);
        if (Mathf.Abs(turn) > 0.1f)
        {
            targetRotation *= Quaternion.AngleAxis(100 * turn * Time.deltaTime, Vector3.forward);
        }
        transform.rotation = targetRotation;
	}

    void FixedUpdate()
    {
        if (Mathf.Abs(forward) > 0.1f)
        {
            gorilla.velocity = -1 * transform.up * forward * speed;
        } else
        {
            gorilla.velocity = Vector3.zero;
        }
        anim.SetFloat("velx", gorilla.velocity.magnitude/20);
        Debug.Log(gorilla.velocity.magnitude/20);
    }
}
