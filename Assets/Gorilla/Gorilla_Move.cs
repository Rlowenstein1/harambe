﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Gorilla_Move : MonoBehaviour {

    Quaternion targetRotation;
    public float speed, forward, turn, run, attack;
    public Rigidbody gorilla;
    public Animator anim;

    public Quaternion Rotation
    {
        get { return targetRotation; }
    }

	// Use this for initialization
	void Awake () {
        speed = 5f;
        targetRotation = transform.rotation;
        gorilla = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        forward = 0;
        turn = 0;
        run = 0;
        attack = 0;
        anim.applyRootMotion = true;
     }
	
	// Update is called once per frame
	void FixedUpdate () {
        forward = Input.GetAxis("Vertical");
        turn = Input.GetAxis("Horizontal");
        run = Input.GetAxis("Run");
        attack = Input.GetAxis("Fire1");
        if (attack != 0)
        {
            anim.SetTrigger("Attack");
        } 
        if (run != 0 && speed <=8)
        {
            speed += 1;
        } else if (run == 0)
        {
        if (speed >= 5)
        {
           speed = speed - 1;
        }
        }
    
        
        if (Mathf.Abs(turn) > 0.1f)
        {
            targetRotation *= Quaternion.AngleAxis(100 * turn * Time.deltaTime, Vector3.forward);
        }
        transform.rotation = targetRotation;

        print(forward * Time.deltaTime * speed);
        anim.SetFloat("velx", forward * Time.deltaTime * speed);

        if (Input.anyKeyDown)
        {

            print(Input.inputString);

        }
    }

    void OnAnimatorMove()
    {      
        this.transform.position = anim.rootPosition;
        print(anim.rootPosition);
    }
}
