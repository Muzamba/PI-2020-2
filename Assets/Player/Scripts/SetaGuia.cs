using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetaGuia : MonoBehaviour
{
    private GameObject pai;

    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        pai = GetComponentInParent<NewPlayer>().gameObject;
        GetComponent<SpriteRenderer>().color = GetComponentsInParent<Arqueira>()[0].cor;
    }

    // Update is called once per frame
    void Update()
    {
        var aux = pai.GetComponent<NewPlayer>()._shotDir;
        transform.localPosition = new Vector2(Mathf.Sin(aux.eulerAngles.z * Mathf.Deg2Rad) * radius,-Mathf.Cos(aux.eulerAngles.z * Mathf.Deg2Rad) * radius);
        transform.rotation = aux;
    }
}
