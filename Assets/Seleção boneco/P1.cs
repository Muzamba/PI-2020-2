using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1 : MonoBehaviour
{
    public float distancia;
    public int local = 0;
    // Update is called once per frame
    void Update()
    {
        if (local == 0 && Input.GetKeyDown(KeyCode.D))
        {
            local = 1;
            transform.position += Vector3.right * distancia;
        } else if (local == 1 && Input.GetKeyDown(KeyCode.A))
        {
            local = 0;
            transform.position -= Vector3.right * distancia;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            GetComponent<Image>().color = Color.white;
        }
    }
}
