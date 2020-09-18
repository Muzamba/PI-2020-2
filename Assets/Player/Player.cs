using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    private Rigidbody2D rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.position += Vector2.left * (Time.deltaTime * velocidade);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.position += Vector2.up * (Time.deltaTime * velocidade * 2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.position += Vector2.right * (Time.deltaTime * velocidade);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.position += Vector2.down * (Time.deltaTime * velocidade);
        }
    }
}
