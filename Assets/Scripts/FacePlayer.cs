using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public float rotSpeed = 90f;
    
    Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            //Find the player's ship!
            GameObject go = GameObject.FindGameObjectWithTag("Player");

            if(go != null)
            {
                player = go.transform;
            }
        }

        //At this point, we've either found the player,
        //or he/she doesn't exist right now
        if(player == null)
        {
            return; //Try again next frame!

        }
        // IF player here, Turn to face it!

        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        //Give a rate for enemy ship to smotthly rotate:
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }
}
