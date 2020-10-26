using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomAndando : MonoBehaviour
{
    private NewPlayer _player;
    private bool _change;
    private bool _valorAntigo;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponentInParent<NewPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        bool valor = _player.gameObject.GetComponentInChildren<Animator>().GetBool("Walk") && _player.Grounded;
        if (_change)
        {
            if (valor)
            {
                GetComponent<AudioSource>().Play();
            }
            else
            {
                GetComponent<AudioSource>().Stop();
            }

            _change = false;

        }

        if (_valorAntigo != valor)
        {
            _valorAntigo = valor;
            _change = true;
        }
        
    }
}
