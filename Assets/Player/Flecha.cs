using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float delayDestroy;
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
        transform.rotation = Quaternion.Euler(0,0,Vector2.SignedAngle(Vector2.down,rigid.velocity));
    }
}
