using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EndGame : MonoBehaviour
{
    static public bool gameover;
    public GameObject player0;

    public GameObject player1;

    public GameObject arqueira;
    public GameObject bumerangue;
    
    public GameObject b1;
    public GameObject b2;

    public float maxAlpha;

    private bool animate;
    // Start is called before the first frame update
    void Start()
    {
        
        if (Controlador.playerOne == 1)
        {
            player0 = Instantiate(arqueira, new Vector3(-5, -0.5f, 0), quaternion.identity);
            player0.GetComponent<Arqueira>().player = 0;
            player0.GetComponent<Arqueira>().cor = Random.ColorHSV(0, 1f, 0, 1f, 0, 1f, 1f, 1f);

        }
        else
        {
            player0 = Instantiate(bumerangue, new Vector3(-5, -0.5f, 0), quaternion.identity);
            player0.GetComponent<Arqueira>().player = 0;
            player0.GetComponent<Arqueira>().cor = Random.ColorHSV(0, 1f, 0, 1f, 0, 1f, 1f, 1f);
        }
        if (Controlador.playerTwo == 1)
        {
            player1 = Instantiate(arqueira, new Vector3(5, -0.5f, 0), quaternion.identity);
            player1.GetComponent<Arqueira>().player = 1;
            player1.GetComponent<Arqueira>().cor = Random.ColorHSV(0, 1f, 0, 1f, 0, 1f, 1f, 1f);
        }
        else
        {
            player1 = Instantiate(bumerangue, new Vector3(5, -0.5f, 0), quaternion.identity);
            player1.GetComponent<Arqueira>().player = 1;
            player1.GetComponent<Arqueira>().cor = Random.ColorHSV(0, 1f, 0, 1f, 0, 1f, 1f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((player0.GetComponentInChildren<NewPlayer>().life == 0) || (player1.GetComponentInChildren<NewPlayer>().life == 0))
        {
            animate = true;
            gameover = true;
            if (player0.GetComponentInChildren<NewPlayer>().life == 0)
            {
                GetComponentInChildren<Text>().text = "Player 2 Venceu";
            }
            else
            {
                GetComponentInChildren<Text>().text = "Player 1 Venceu";
            }
            b1.SetActive(true);
            b2.SetActive(true);
            
        }

        

        if (animate)
        {
            var color1 = GetComponentInChildren<Image>().color;
            var color2 = GetComponentInChildren<Text>().color;
            if (color1.a < maxAlpha)
            {
                color1.a += 0.01f;
            }

            color2.a+= 0.01f;
            GetComponentInChildren<Text>().color = color2;
            GetComponentInChildren<Image>().color = color1;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameover = false;
        player0.GetComponentInChildren<NewPlayer>().life = 5;
        player1.GetComponentInChildren<NewPlayer>().life = 5;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
