using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class interactWithPlayer : MonoBehaviour
{
    public GameObject hintE;
    public GameObject item;
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
        hintE.SetActive(false);
        grabbedItems = new List<GameObject>();
        speedBoost.GetComponent<Text>().text = "Speed Bost: " + speedInvestment.ToString()+ "/" + speedInvestNeededToLvl.ToString();
        jumpBoost.GetComponent<Text>().text = "Jump Bost: " + jumpInvestment.ToString() + "/" + jumpInvestNeededToLvl.ToString();
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Picked!");
                hintE.SetActive(false);
                //Destroy(item);
                itemCount += 1;
                GameObject.Find("numberOfItems").GetComponent<Text>().text = "x " + itemCount.ToString();
                //item.transform.SetParent(gameObject.transform);
                //Vector3 topOfHead = gameObject.transform.position;
                //topOfHead.x += 2;
                //item.transform.position = topOfHead;
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
                    GameObject.Find("numberOfItems").GetComponent<Text>().text = "x " + itemCount.ToString();
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
                        default:
                            break;
                    }
                }
            }
            speedBoost.GetComponent<Text>().text = "Speed Bost: " + speedInvestment.ToString() + "/" + speedInvestNeededToLvl.ToString();
            jumpBoost.GetComponent<Text>().text = "Jump Bost: " + jumpInvestment.ToString() + "/" + jumpInvestNeededToLvl.ToString();
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

