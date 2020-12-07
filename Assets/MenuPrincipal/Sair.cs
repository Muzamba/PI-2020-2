using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sair : MonoBehaviour
{
    public LevelLoader levelLoader;
    public void SairButton()
    {
        StartCoroutine(quitLevel());
    }
    IEnumerator quitLevel()
    {
        levelLoader.animator.SetTrigger("Start");
        yield return new WaitForSeconds(levelLoader.time);
        Application.Quit();
    }
}
