using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemToSpawn;
    public float radius;
    public int timeBetweenSpawn = 500;
    public int timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (itemToSpawn == null) itemToSpawn = GameObject.Find("Item");
        if (radius == 0)
        {
            radius = gameObject.transform.lossyScale.z + 15;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeElapsed >= timeBetweenSpawn)
        {
            Vector2 pointInside = Random.insideUnitCircle.normalized * radius;
            Vector3 randomPoint = new Vector3(pointInside.x, pointInside.y, 0) + gameObject.transform.position;
            //Debug.Log(randomPoint.x);
            //Debug.Log(randomPoint.z);
            itemToSpawn.GetComponent<GravityTowardPoint>().SetOwnCenterOfGravity(gameObject.transform.Find("CenterOfGravity").gameObject, 1);
            itemToSpawn.transform.SetParent(gameObject.transform);
            Instantiate(itemToSpawn, randomPoint, Quaternion.identity);
            timeElapsed = 0;
        }
        else
        {
            timeElapsed++;
        }
        
    }
}
