using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public int pulosDisponiveis = 0;
    public float delta;
    public GameObject flecha;
    public float velocidade;
    public int totalPulos;
    public float pulo;
    public float flechaForca;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyUp(KeyCode.Space))
        {
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                var arrow = ArrowDirection();
                var go = Instantiate(flecha, transform.position + Vector3.right * delta, arrow);
                go.GetComponent<Rigidbody2D>().AddForce((arrow * Vector2.down) * flechaForca);
                Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                
            }
             
            
        }
        else
        {
            
            if (Input.GetKey(KeyCode.A))
            {
                rigidbody.position += Vector2.left * (velocidade * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.W) && pulosDisponiveis > 0)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
                rigidbody.AddForce(Vector2.up * pulo);
                pulosDisponiveis--;

            }

            if (Input.GetKey(KeyCode.D))
            {
                rigidbody.position += Vector2.right * (velocidade * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                //rigidbody.position += Vector2.down * (velocidade * Time.deltaTime);
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "chao")
        {
            pulosDisponiveis = totalPulos;
        }
        
    }

    private Quaternion ArrowDirection()
    {
        Quaternion resultado = Quaternion.Euler(0,0,90);
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.D))
            {
                resultado = Quaternion.Euler(0,0,135);
            } else if (Input.GetKey(KeyCode.A))
            {
                resultado = Quaternion.Euler(0, 0, 225);
            }
            else
            {
                resultado = Quaternion.Euler(0, 0, 180);
            }
        }else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.D))
            {
                resultado = Quaternion.Euler(0,0,45);
            } else if (Input.GetKey(KeyCode.A))
            {
                resultado = Quaternion.Euler(0, 0, 315);
            }
            else
            {
                resultado = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                resultado = Quaternion.Euler(0,0,90);
            } else if (Input.GetKey(KeyCode.A))
            {
                resultado = Quaternion.Euler(0, 0, 270);
            }
        }

        return resultado;
    }
    
}
