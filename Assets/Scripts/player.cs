using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float playerSpeed = 1.15f;
    Rigidbody2D playerRigidBody;
    Transform playerTransform;
    public Transform playerPivot;
    Vector3 inputMovement;
    Vector3 circleCenter;
    float radius = 1.787921f;
    public Transform circleCenterObject;

    // Use this for initialization
    void Start () {
        this.GetComponent<Rigidbody2D>().gravityScale = 0f;
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        playerTransform = this.transform;
    }

    // Update is called once per frame
    void Update ()
    {
        playerPivot.position = new Vector3(playerPivot.position.x, playerTransform.position.y, playerPivot.position.z);
        playerPivot.LookAt(playerTransform, Vector3.up); //make the pivot look at the player

        Quaternion pivotRotation = playerPivot.localRotation; //get the rotation of the pivot, so that we can adjust the inputs below to be relative to that

        inputMovement = Vector3.zero; //resetting the inputMovement vector which will hold all our input information

        if (Input.GetKey(KeyCode.A))
        {
            inputMovement += pivotRotation * Vector3.left;
            //Vector3 position = this.transform.position;
            //Debug.Log("Left");
            //position.x += this.playerSpeed;
            //this.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputMovement += pivotRotation * Vector3.right;
            //Vector3 position = this.transform.position;
            //Debug.Log("Right");
            //position.x -= this.playerSpeed;
            //this.transform.position = position;
        }

        inputMovement = inputMovement.normalized * playerSpeed; //normalising the inputMovement vector so it's not too large and then we can cleanly multiply it by whatever walk speed we desire
        circleCenter = circleCenterObject.position;

        Vector3 offset = transform.position - circleCenter;
        offset = offset.normalized * radius;
        transform.position = offset;

        playerRigidBody.velocity = new Vector3(inputMovement.x, playerRigidBody.velocity.y, inputMovement.z); //apply the inputMovement vector to the players velocity, but not on the y axis otherwise it will overwrite gravity.
        playerTransform.localRotation = pivotRotation; //keep the player rotated the same as the pivot so it doesn't start walking backwards
    }
}
