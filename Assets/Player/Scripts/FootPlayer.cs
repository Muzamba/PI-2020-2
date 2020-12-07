using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class FootPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public StudioEventEmitter passos;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Chao"))
        {
            GetComponentInParent<NewPlayer>().Grounded = true;
        }
    }

    private bool first = true;
    private void OnCollisionStay2D(Collision2D other)
    {
        if (GetComponentInParent<NewPlayer>()._direction.x != 0 )
        {
            if (first)
            {
              passos.Play(); 
              first = false;  
            }
            
        }
        else
        {
            if (!first)
            {
                passos.Stop();
                first = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Chao"))
        {
            GetComponentInParent<NewPlayer>().Grounded = false;
            first = true;
            passos.Stop();
        }
    }
}
