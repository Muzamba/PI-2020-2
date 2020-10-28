using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomColl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
