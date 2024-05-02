using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{

    public float parralax = 4f;

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.materials[0]; //or mr.material

        Vector2 offset = mat.mainTextureOffset;  //or mat.getTextureOffset("_Main");


        //OFFSET by time, fixed direction
        //offset.x += Time.deltaTime / 10f; //move offset X of the material (move left) by time

        //OFFSET by player direction
        offset.x = transform.position.x / transform.localScale.x / parralax;  //Quad Scaled by 10 and reduced to add parralax effect
        offset.y = transform.position.y / transform.localScale.y / parralax;  

        mat.mainTextureOffset = offset;
    }
}
