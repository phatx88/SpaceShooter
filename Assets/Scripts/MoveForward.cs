using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float maxSpeed = 8f;
    // Update is called once per frame
    void Update()
    {
        #region MOVE the bullet
        //Use Vertical as in Input manager to get value up and down from variety of device such as mobile and joystick
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;

        //transform.position = pos;
        #endregion
    }
}
