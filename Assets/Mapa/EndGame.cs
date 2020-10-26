using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    static public bool gameover;
    public GameObject player0;

    public GameObject player1;

    public GameObject b1;
    public GameObject b2;

    public float maxAlpha;

    private bool animate;
    // Start is called before the first frame update
    void Start()
    {
        
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
