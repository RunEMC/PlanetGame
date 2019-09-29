using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Demo_RoundPlatformer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
