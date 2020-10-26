using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = GetComponentInParent<Arqueira>().cor;
        if (GetComponentInParent<Arqueira>().player == 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
