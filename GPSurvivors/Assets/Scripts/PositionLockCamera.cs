using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLockCamera : MonoBehaviour
{
    public GameObject Target;
    private Camera managedCamera;

    private void Awake()
    {
        managedCamera = gameObject.GetComponent<Camera>();
    }

    private void Start()
    {
        // Focus at the target.
        managedCamera.transform.position = new Vector3(this.Target.transform.position.x, this.Target.transform.position.y, managedCamera.transform.position.z);
    }

    // Use the LateUpdate message to avoid setting the camera's position
    // GameObject locations are finalized.
    void LateUpdate()
    {   
        if (this.Target == null)
        {
            return;
        }
        var targetPosition = this.Target.transform.position;
        var cameraPosition = managedCamera.transform.position;

        // Focus at the target.
        if (targetPosition.y != cameraPosition.y)
        {
            cameraPosition.y = targetPosition.y;
        }

        if (targetPosition.x != cameraPosition.x)
        {
            cameraPosition.x = targetPosition.x;
        }
        // Update the camera.
        managedCamera.transform.position = cameraPosition;

    }
}

