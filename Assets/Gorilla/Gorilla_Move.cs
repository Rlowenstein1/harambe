using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gorilla_Move : MonoBehaviour {

    Quaternion targetRotation;
    public float speed, forward, turn, run;
    Rigidbody gorilla;
    public Animator anim;

    public Quaternion Rotation
    {
        get { return targetRotation; }
    }

	// Use this for initialization
	void Start () {
        speed = 10f;
        targetRotation = transform.rotation;
        gorilla = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        forward = 0;
        turn = 0;
        run = 0;
	}
	
	// Update is called once per frame
	void Update () {
        forward = Input.GetAxis("Vertical");
        turn = Input.GetAxis("Horizontal");
        run = Input.GetAxis("Run");
        if (run != 0 && speed <=20)
        {
            speed += 1;
        } else if (run == 0)
        {
            if (speed >= 10)
            {
                speed = speed - 1;
            }
        }
        if (Mathf.Abs(turn) > 0.1f)
        {
            targetRotation *= Quaternion.AngleAxis(100 * turn * Time.deltaTime, Vector3.forward);
        }
        transform.rotation = targetRotation;


        if (Input.anyKeyDown)
        {

            print(Input.inputString);

        }
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
        anim.SetFloat("velx", gorilla.velocity.magnitude / 20);
    }
}
