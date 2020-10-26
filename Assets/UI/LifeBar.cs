using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    public GameObject player;

    public GameObject bar;

    public float offsetX;

    public float offsetY;

    public float space;

    private int _initialLife;
    private List<GameObject> _bars = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        _initialLife = player.GetComponent<NewPlayer>().life;
        GetComponent<SpriteRenderer>().color = GetComponentInParent<Arqueira>().cor;
        
        
        if (player.GetComponentInParent<Arqueira>().player == 0)
        {
            transform.position = new Vector2(-8,4);
        }
        else
        {
            space *= -1;
            offsetX *= -1;
            transform.position = new Vector2(8,4);
            GetComponent<SpriteRenderer>().flipX = true;
            
        }
        

        for (int i = 0; i < _initialLife; i++)
        {
            var aux = GameObject.Instantiate(bar, transform);
            aux.transform.localPosition= new Vector2(offsetX + (i * space),offsetY);
            _bars.Add(aux);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        int aux = player.GetComponent<NewPlayer>().life;
        if (aux < _initialLife)
        {
            for (int i = 0; i < _initialLife - aux; i++)
            {
                GameObject.Destroy(_bars.Last());
                _bars.Remove(_bars.Last());
            }

            _initialLife = aux;
        }
    }
}
