using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravField : MonoBehaviour
{
    GameObject gravObject;
    GameObject player;
    public string PlayerTag = "Player";
    // Start is called before the first frame update
    void Start()
    {  
        gravObject = gameObject.transform.Find("CenterOfGravity").gameObject;
        player = GameObject.FindGameObjectWithTag(PlayerTag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //var centerOfGrav = gameobject.transform.Find("CenterOfGravity");
        Debug.Log("Entered", gravObject);
        player.GetComponent<Player_Movement>().SetOwnCenterOfGravity(gravObject);
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
