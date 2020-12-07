using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public LevelLoader levelLoader;
    public void PlayButton()
    {
        levelLoader.LoadNextLevel();
    }
}
