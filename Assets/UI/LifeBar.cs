using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

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
        RectTransform c = transform.parent.GetComponent<RectTransform>();
        _initialLife = player.GetComponent<NewPlayer>().life;
        GetComponent<Image>().color = GetComponentInParent<Arqueira>().cor;
        
        
        if (player.GetComponentInParent<Arqueira>().player == 0)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector3(-540,240,0);//transform.position = c.position + new Vector3(-c.sizeDelta.x/2 + 100, c.sizeDelta.y / 2 - 70, 0); //new Vector2(-546,-70);
        }
        else
        {
            //space *= -1;
            //offsetX *= -1;
            GetComponent<RectTransform>().anchoredPosition = new Vector3(540,240,0);
            GetComponent<Image>().transform.rotation = Quaternion.Euler(0,180,0);
            
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
