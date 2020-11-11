using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadGame : MonoBehaviour
{
    //Loads game scene
    
    void Start()
    {
        SceneManager.LoadScene("scene");
    }
}
