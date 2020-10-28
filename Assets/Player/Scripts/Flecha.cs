using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float forceX;
    public float forceY;
    public int damage;
    private Rigidbody2D rigid;
    public float delayDestroy;

    private bool physiscsOff;
    //comentario aleatorioo
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        GameObject.Destroy(gameObject,delayDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        if (!physiscsOff)
        {
            transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.down, rigid.velocity));
        }
        
        
    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<AudioSource>().Stop();
        GetComponentInChildren<SomColl>().PlaySound();
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<NewPlayer>().life -= damage;
            other.gameObject.GetComponent<NewPlayer>().damaging = true;
            other.gameObject.GetComponent<NewPlayer>().Playdamage();
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX,forceY));
            GameObject.Destroy(gameObject);
        }else if (other.gameObject.CompareTag("Chao"))
        {
            physiscsOff = true;
            GameObject.Destroy(GetComponent<BoxCollider2D>());
            GameObject.Destroy(rigid);
            
            
        }
    }
}
