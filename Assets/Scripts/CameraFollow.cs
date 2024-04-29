using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (go != null)
        {
            Transform myTarget = go.transform;
            Vector3 targPos = myTarget.position;

            //Keep z position of camera at old position
            targPos.z = transform.position.z;

            // Use Vector3.Lerp to smoothly interpolate between the current position and the target position
            transform.position = Vector3.Lerp(transform.position, targPos, followSpeed * Time.deltaTime);
        }
    }
}
