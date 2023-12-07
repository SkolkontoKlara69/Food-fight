using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 locationOffset;
    public Vector3 rotationOffset;   
    public bool lockY = true;
    private Vector3 offset;
    private Vector3 tempVect;
    public Camera camera;
    public float cameraYPosition;

    void Start()
    {
        cameraYPosition = transform.position.y;
    }

    void FixedUpdate()
    {
        //camera.transform.position = new Vector3(target.position.x * locationOffset.x * smoothSpeed, cameraYPosition, locationOffset.z);

        //if (target.position.y >= 5)
        //{
            Vector3 desiredPosition = target.position + target.rotation * locationOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
            Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
            transform.rotation = smoothedrotation;
        //}


    }
}
