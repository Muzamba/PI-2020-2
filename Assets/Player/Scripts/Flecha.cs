using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float forceX;
    public float forceY;
    public int damage;
    private Rigidbody2D rigid;
    public float delayDestroy;
    public StudioEventEmitter impacto;
    public StudioEventEmitter flechaVoando;

    private bool physiscsOff;
    //comentario aleatorioo
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Destroy(gameObject,delayDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        if (!physiscsOff)
        {
            transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.down, rigid.velocity));
        }
        
        
    }


    private bool first = true;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!first)
        {
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            flechaVoando.Stop();
            impacto.Play();
            //other.gameObject.GetComponent<NewPlayer>().life -= damage;
            //other.gameObject.GetComponent<NewPlayer>().damaging = true;
            other.gameObject.GetComponent<NewPlayer>().TakeDamage(damage, new Vector2(forceX,forceY));
            Destroy(gameObject);
            first = false;
        }else if (other.gameObject.CompareTag("Chao"))
        {
            flechaVoando.Stop();
            impacto.Play();
            physiscsOff = true;
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(rigid);
            first = false;
        }
    }
}
