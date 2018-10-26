using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Camera_Follow : MonoBehaviour
{
    public Rigidbody gorilla;
    public float smoothTime = 1f;		// a public variable to adjust smoothing of camera motion
    public float maxSpeed = 50f;        //max speed camera can move
    public Transform desiredPose;           // the desired pose for the camera, specified by a transform in the game

    protected Vector3 currentPositionCorrectionVelocity;
    protected Vector3 currentFacingCorrectionVelocity;


    void LateUpdate()
    {
        desiredPose = gorilla.transform.Find("CamPos");
        if (desiredPose != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, desiredPose.position, ref currentPositionCorrectionVelocity, smoothTime, maxSpeed, Time.deltaTime);
            transform.forward = Vector3.SmoothDamp(transform.forward, desiredPose.forward, ref currentFacingCorrectionVelocity, smoothTime, maxSpeed, Time.deltaTime);
        }
    }
}

