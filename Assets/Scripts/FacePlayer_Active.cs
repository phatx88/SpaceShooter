using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer_Active : MonoBehaviour
{
    public float rotSpeed = 90f;

    private Transform player;
    private bool isActive = true;

    void Update()
    {
        if (!isActive)
            return;

        if (player == null)
        {
            // Find the player's ship!
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            if (go != null)
            {
                player = go.transform;
            }
        }

        if (player == null)
            return; // Try again next frame!

        // Check if the object is within the camera's view
        if (IsWithinCameraView())
        {
            isActive = false; // Stop updating if within camera range
            return;
        }

        // Turn to face the player if not within camera range
        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }

    private bool IsWithinCameraView()
    {
        var cam = Camera.main;
        if (cam == null)
            return false;

        var viewportPosition = cam.WorldToViewportPoint(transform.position);
        // Check if the position is within the camera's viewport
        // The viewport coordinates go from (0,0) at the bottom left to (1,1) at the top right
        return viewportPosition.z > 0 && viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1;
    }
}
