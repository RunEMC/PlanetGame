using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravField : MonoBehaviour
{
    GameObject gravObject;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        gravObject = GameObject.transform.Find("CenterOfGravity");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //var centerOfGrav = gameobject.transform.Find("CenterOfGravity");
        Debug.Log("Entered", gravObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Entered");
    }


    void OnTrigger(Collider other)
    {
        Debug.Log("Entered");
    }
}
