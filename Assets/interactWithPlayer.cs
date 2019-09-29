using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class interactWithPlayer : MonoBehaviour
{
    public GameObject hintE;
    public GameObject item;
    public GameObject itemBoost;
    public GameObject speedBoost;
    public GameObject jumpBoost;
    List<GameObject> grabbedItems;
    public int maxItems = 1;
    public int itemCount = 0;
    public int speedInvestment = 0;
    public int speedInvestNeededToLvl = 4;
    public int jumpInvestment = 0;
    public int jumpInvestNeededToLvl = 3;

    private void Start()
    {   
        hintE = GameObject.Find("PressE");
        speedBoost = GameObject.Find("speedBoost");
        jumpBoost = GameObject.Find("jumpBoost");
        itemBoost = GameObject.Find("numberOfItems");
        hintE.SetActive(false);
        grabbedItems = new List<GameObject>();
        Update();
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        item = collision.gameObject;
        string name = item.name;
        if (name.StartsWith("Item"))
        {
            hintE.GetComponent<Text>().text = "Press E to Pick Up";
            Debug.Log("can be picked");
            hintE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && itemCount < maxItems)
            {
                Debug.Log("Picked!");
                hintE.SetActive(false);
                //Destroy(item);
                itemCount += 1;
                Update();
                GameObject topOfHead = gameObject.transform.Find("TopOfHead").gameObject;
                item.name = "AcquiredItem";
                grabbedItems.Add(item);
                item.GetComponent<GravityTowardPoint>().SetOwnCenterOfGravity(topOfHead, 25);
            }
        }
        else if (name.StartsWith("Statue"))
        {
            hintE.GetComponent<Text>().text = "Press E to drop stuff";
            string statueType = name.Split('_')[1];
            Debug.Log(statueType);
            hintE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (itemCount > 0)
                {
                    itemCount--;
                    Update();
                    Destroy(grabbedItems[0]);
                    grabbedItems.RemoveAt(0);
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
                        case "Item":
                            maxItems++;
                            break;
                        case "Jump":
                            jumpInvestment++;
                            if (jumpInvestment >= jumpInvestNeededToLvl)
                            {
                                jumpInvestment = 0;
                                GameObject.Find("Player").GetComponent<Player_Movement>().ChangePlayerSettings(0, 0, 0.3f, 0);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            Update();
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
    private void Update()
    {
        itemBoost.GetComponent<Text>().text = "Item: " + itemCount.ToString() + "/" + maxItems.ToString();
        speedBoost.GetComponent<Text>().text = "Speed Bost: " + speedInvestment.ToString() + "/" + speedInvestNeededToLvl.ToString();
        jumpBoost.GetComponent<Text>().text = "Jump Bost: " + jumpInvestment.ToString() + "/" + jumpInvestNeededToLvl.ToString();

    }
}   
