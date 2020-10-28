using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponentInParent<Arqueira>().player == 0)
        {
            transform.localPosition = new Vector2(0.08f,-0.37f);
        }
        else
        {
            transform.localPosition = new Vector2(-0.08f,-0.37f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
