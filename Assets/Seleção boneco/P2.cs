using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class P2 : MonoBehaviour
{
    public float distancia;
    public int local = 0;

    
    // Update is called once per frame
    void Update()
    {
        if (local == 0 && Input.GetKeyDown(KeyCode.L))
        {
            local = 1;
            transform.position += Vector3.right * distancia;
        } else if (local == 1 && Input.GetKeyDown(KeyCode.J))
        {
            local = 0;
            transform.position -= Vector3.right * distancia;
        }

        if (Input.GetKey(KeyCode.RightControl))
        {
            GetComponent<Image>().color = Color.blue;
        }
        else
        {
            GetComponent<Image>().color = Color.white;
        }
    }
}
