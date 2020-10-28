using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaGuia : MonoBehaviour
{
    private GameObject pai;

    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        pai = GetComponentInParent<NewPlayer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var aux = pai.GetComponent<NewPlayer>()._shotDir;
        transform.localPosition = new Vector2(Mathf.Sin(aux.eulerAngles.z * Mathf.Deg2Rad) * radius,-Mathf.Cos(aux.eulerAngles.z * Mathf.Deg2Rad) * radius);
        transform.rotation = aux;
    }
}
