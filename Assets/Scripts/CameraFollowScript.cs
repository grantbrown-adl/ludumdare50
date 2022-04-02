using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject followTarget;

    public float speedFactor = 250.0f;
    public float lerpingZ = 0.025f;
    public float minimumDistance;
    public float interpolationVelocity;
    public float followDistance;
    public Vector3 cameraOffset;

    private Vector3 cameraTarget;
    [SerializeField] private bool lockX, lockY, lockZ;

    private void Start()
    {
        cameraTarget = transform.position;
    }

    private void FixedUpdate()
    {
        if(followTarget)
        {
            Vector3 position2D = transform.position;
            position2D.z = followTarget.transform.position.z;

            Vector3 cameraTargetDirection = (followTarget.transform.position - position2D);
            interpolationVelocity = cameraTargetDirection.magnitude * speedFactor;

            cameraTarget = transform.position + (cameraTargetDirection.normalized * interpolationVelocity * Time.deltaTime);

            if(lockX)
                cameraTarget.x = transform.position.x;
            if(lockY)
                cameraTarget.y = transform.position.y;
            if(lockZ)
                cameraTarget.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, cameraTarget + cameraOffset, lerpingZ);
        }
    }
}
