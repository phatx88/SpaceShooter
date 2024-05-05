using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Awake() //dung cho event như button, onclick
    {
        Debug.Log("Vo ham Awake");
    }

    private void OnEnable() //cung giong Sttart nhưng dùng cho On Object (set true)
    {
       Debug.Log("Vo ham OnEnable");
    }
    void Start() //Dung ham start cho Init Data 
    {
       Debug.Log("Vo ham Start");
    }

    // Update is called once per frame
    void Update() // chay lien tuc tren frame tren day
    {
        //Debug.Log("Vo ham Update");
    }
    private void FixedUpdate() //chay dung co dinh frame tren 1 giay
    {
        
    }

    void LateUpdate() // chay lien tuc tren frame tren day nhung sau update
    {
        //Debug.Log("Vo ham LateUpdate");
    }

    private void OnDisable() // nguoc lai voi enable
    {
        Debug.Log("Vo ham OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log("Vo ham OnDestroy");
    }
}
