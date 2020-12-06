using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = GetComponentsInParent<Arqueira>()[0].cor;
        if (GetComponentInParent<Arqueira>().player == 0)
        {
            //GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0,180,0);
            //GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
