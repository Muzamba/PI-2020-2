using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    
    public static int playerOne = 0;
    public static int playerTwo = 0;

    public GameObject p1;
    public GameObject p2;
    public LevelLoader levelLoader;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.RightControl))
        {
            playerOne = p1.GetComponent<P1>().local;
            playerTwo = p2.GetComponent<P2>().local;
            levelLoader.LoadNextLevel();
            
        }
    }
}
