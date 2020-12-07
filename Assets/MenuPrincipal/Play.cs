using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class Play : MonoBehaviour
{
    public LevelLoader levelLoader;
    public StudioEventEmitter som;
    public void PlayButton()
    {
        som.Play();
        levelLoader.LoadNextLevel();
    }
}
