using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumerangue : MonoBehaviour
{

    [SerializeField] public Transform _player;
    [SerializeField] private float _tempoVoo;
    [SerializeField] private float _veloAngVoo;
    [SerializeField] private float _veloVoo;
    private Rigidbody2D _rigi;
    public Vector2 dir;
    public Vector2 dirRetorno;
    public int dano;
    public float forceX;
    public float forceY;
    
    private float acumulador = 0;
    void Start()
    {
        //    _player = GetComponentInParent<Transform>();
        _rigi = GetComponent<Rigidbody2D>();
    }

    private bool _first = true;
    void Update()
    {
        acumulador += Time.deltaTime  ;
        _rigi.rotation += _veloAngVoo;
        //_rigi.velocity = dir.normalized * _veloVoo;
        if (acumulador < _tempoVoo/4)
        {
            _rigi.velocity = dir.normalized * _veloVoo * Time.deltaTime * Mathf.Cos(acumulador*2*Mathf.PI/_tempoVoo);
        }
        else
        {
            //_rigi.velocity = Vector2.zero;
            dirRetorno = _player.transform.position - transform .position;
            if (Vector2.Distance(_player.transform.position, transform.position) < 0.1f)
            {
               Destroy(gameObject);
               _player.GetComponent<NewPlayer>().Recarregar(false);
            }

            if (_first&&(acumulador > _tempoVoo))
            {
                _first = false;
            }

            if (_first)
            {
                _rigi.velocity = -dirRetorno.normalized * _veloVoo * Time.deltaTime * Mathf.Cos(acumulador*2*Mathf.PI/_tempoVoo);
            }
            else
            {
                _rigi.velocity = dirRetorno.normalized * _veloVoo * Time.deltaTime;
            }
            
        }
    }


    private bool _first2= true;
    private void OnCollisionEnter2D(Collision2D other)
    {
        _first = false;
        acumulador = _tempoVoo;
        if (!_first2)
        {
            return;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<NewPlayer>().life -= damage;
            //other.gameObject.GetComponent<NewPlayer>().damaging = true;
            other.gameObject.GetComponent<NewPlayer>().TakeDamage(dano, new Vector2(forceX, forceY));
            //Destroy(gameObject);
            _first2 = false;
        }
    }
}
