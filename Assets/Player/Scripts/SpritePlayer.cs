using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePlayer : MonoBehaviour
{
    [SerializeField] private Material _material;
    void Start()
    {
        GetComponent<SpriteRenderer>().material = Instantiate(_material);
        GetComponent<SpriteRenderer>().material.color = GetComponentsInParent<Arqueira>()[0].cor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
