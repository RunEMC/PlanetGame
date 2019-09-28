using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
public class interactWithPlayer : MonoBehaviour
{
    public GameObject hintE;
    public GameObject item;
    public int itemCount = 0;
    public int speedInvestment = 0;
    public int speedInvestNeededToLvl = 3;

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
                item.transform.SetParent(gameObject.transform);
                Vector3 topOfHead = gameObject.transform.position;
                topOfHead.y += 5;
                item.transform.position = topOfHead;
                item.GetComponent<GravityTowardPoint>().SetCenterOfGrav(gameObject, 25);
                //item.transform.position. += 5; 
                //Destroy(item);
                itemCount += 1;
                //GameObject.Find("numberOfItems").GetComponent<Text>().text = "x " + itemCount.ToString();
            }
        }
        else if (name.StartsWith("Statue"))
        {
            string statueType = name.Split('_')[1];
            Debug.Log(statueType);
            hintE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (itemCount > 0)
                {
                    itemCount--;
                    //GameObject.Find("numberOfItems").GetComponent<Text>().text = "x " + itemCount.ToString();
                    hintE.SetActive(false);
                    //Debug.Log("Invest LESS");
                    switch (statueType)
                    {
                        case "Speed":
                            Debug.Log("Invest more");
                            speedInvestment++;
                            if (speedInvestment >= speedInvestNeededToLvl)
                            {
                                //Debug.Log("MoreSpd");
                                speedInvestment = 0;
                                GameObject.Find("Player").GetComponent<Player_Movement>().ChangePlayerSettings(1, 0, 0, 0);
                            }
                            break;
                        default:
                            break;
                    }
                }
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

