using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody2D>().gravityScale = 0f;
	}

    // Update is called once per frame
    void Update () {
		
	}
}
