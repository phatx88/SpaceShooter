using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float rotSpeed = 1f;

    //float shipBoundaryRadius = 0.5f;
    void Start()
    {
        
    }

    void Update()
    {
        #region ROTATE the Ship
        //Assign rotation quaternion
        Quaternion rot = transform.rotation;

        //Assign the Z euler angle
        float z = rot.eulerAngles.z;

        //Change the Z angle based on input
        z += -Input.GetAxis("Horizontal") * rotSpeed + Time.deltaTime;

        //Initiate z change in the quaternion
        rot = Quaternion.Euler(0,0,z);

        //transform rotation
        transform.rotation = rot;
        #endregion


        #region MOVE the Ship
        //Use Vertical as in Input manager to get value up and down from variety of device such as mobile and joystick
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime,0);

        pos += rot * velocity;

        //transform.position = pos;
        #endregion


        #region RESTRICT PLAYER BOUNDARY 

        ////Do Vertical boundary based on Main Camera(tagged with Main Camera) Orthographic(default is 5)
        //if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        //{
        //    pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        //}

        //if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        //{
        //    pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        //}


        ////Do Horizontal vertical based on aspect ration of screen size
        //float screenRatio = (float)Screen.width / (float)Screen.height;
        //float widtOrtho = Camera.main.orthographicSize * screenRatio;

        //if (pos.x + shipBoundaryRadius > widtOrtho)
        //{
        //    pos.x = widtOrtho - shipBoundaryRadius;
        //}

        //if (pos.x - shipBoundaryRadius < -widtOrtho)
        //{
        //    pos.x = -widtOrtho + shipBoundaryRadius;
        //}
        #endregion

        transform.position = pos;
    }
}
