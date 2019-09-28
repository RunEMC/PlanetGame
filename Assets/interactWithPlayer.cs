using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class interactWithPlayer : MonoBehaviour
{
    public GameObject hintE;
    public GameObject item;
    public int itemCount = 0;
    private void Start()
    {   
        hintE = GameObject.Find("PressE");
        hintE.SetActive(false);
     }

    private void OnTriggerStay2D(Collider2D collision)
    {
        item = collision.gameObject;
        string name = item.name;
        if (name.StartsWith("Item"))
        {
            Debug.Log("can be picked");
            hintE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Picked!");
                hintE.SetActive(false);
                Destroy(item);
                itemCount += 1;
                GameObject.Find("numberOfItems").GetComponent<Text>().text = "x " + itemCount.ToString();
              }
        }
        else
        {
            hintE.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hintE.SetActive(false);
    }
}   

