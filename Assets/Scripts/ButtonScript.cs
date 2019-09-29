using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("StartButton").GetComponentInChildren<Text>().text = "Start";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
