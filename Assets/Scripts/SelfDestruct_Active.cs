using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct_Active : MonoBehaviour
{
    public float timer = 5f;
    public GameObject targetObject; // The target object that triggers destruction when it is destroyed

    void Update()
    {
        // Reduce the self-destruction timer
        timer -= Time.deltaTime;

        // Destroy this object if the timer reaches zero
        if (timer <= 0)
        {
            Destroy(gameObject);
        }

        // Check if the target object is destroyed
        if (targetObject == null)
        {
            // Destroy this object if the target object is destroyed
            Destroy(gameObject);
        }
    }
}
