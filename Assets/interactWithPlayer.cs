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
    public GameObject enemy;
    List<GameObject> grabbedItems;
    public int maxItems = 1;
    public int itemCount = 0;
    public int speedInvestment = 0;
    public int speedInvestNeededToLvl = 4;
    public int jumpInvestment = 0;
    public int jumpInvestNeededToLvl = 3;
    public bool talking = false;
    public GameObject uwin;
    public GameObject talk1;
    public GameObject talk2;
    public GameObject talk3;
    public GameObject talk4;
    public GameObject talk5;
    private void Start()
    {   
        hintE = GameObject.Find("PressE");
        speedBoost = GameObject.Find("speedBoost");
        jumpBoost = GameObject.Find("jumpBoost");
        itemBoost = GameObject.Find("numberOfItems");
        uwin = GameObject.Find("uwin");
        uwin.SetActive(false);
        hintE.SetActive(false);
        grabbedItems = new List<GameObject>();
        Update();
        talk1 = GameObject.Find("talk1");
        talk1.SetActive(false);
        talk2 = GameObject.Find("talk2");
        talk2.SetActive(false);
        talk3 = GameObject.Find("talk3");
        talk3.SetActive(false);
        talk4 = GameObject.Find("talk4");
        talk4.SetActive(false);
        talk5 = GameObject.Find("talk5");
        talk5.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        talking = false;
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
        else if (name.StartsWith("egg"))
        {
            hintE.SetActive(true);
            hintE.GetComponent<Text>().text = "Press E to pick ur mother ;3 ";
            if (Input.GetKeyDown(KeyCode.E))
            {
                uwin.SetActive(true);
            }

        }
        else if (name.StartsWith("enemy"))
        {
            Debug.Log(talking);
            if (talking == false) { 
                hintE.SetActive(true);
                hintE.GetComponent<Text>().text = "Press E to Talk";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    talking = true;
                    hintE.GetComponent<Text>().text = "Are u my mom? ";
                    string str =name.Split('_')[1];
                  
                    if (int.Parse(str) == 1)
                    {
                        enemy = talk1;
                    }
                    else if(int.Parse(str) == 2)
                    {
                        enemy = talk2;
                    }else if (int.Parse(str) == 3)
                    {
                        enemy = talk3;
                    }else if (int.Parse(str) == 4)
                    {
                        enemy = talk4;
                    }else if (int.Parse(str) == 5)
                    {
                        enemy = talk5;
                    }
                    else{

                    }
                    enemy.SetActive(true);
                }
            }
            else
            {
                hintE.GetComponent<Text>().text = "Are u my mom? ";
            }
        }
        else
        {
       
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //enemy.SetActive(false);
        talking = false;
        hintE.SetActive(false);
    }
    private void Update()
    {
        itemBoost.GetComponent<Text>().text = "Items: " + itemCount.ToString() + "/" + maxItems.ToString();
        speedBoost.GetComponent<Text>().text = "Eggs Until Speed Boost: " + speedInvestment.ToString() + "/" + speedInvestNeededToLvl.ToString();
        jumpBoost.GetComponent<Text>().text = "Eggs Until Jump Boost: " + jumpInvestment.ToString() + "/" + jumpInvestNeededToLvl.ToString();

    }
}   
