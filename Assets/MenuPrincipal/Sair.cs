using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class Sair : MonoBehaviour
{
    public LevelLoader levelLoader;
    public StudioEventEmitter som;
    public void SairButton()
    {
        som .Play();
        StartCoroutine(quitLevel());
    }
    IEnumerator quitLevel()
    {
        levelLoader.animator.SetTrigger("Start");
        yield return new WaitForSeconds(levelLoader.time);
        Application.Quit();
    }
}
