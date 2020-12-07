using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    public float time = 1f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(LevelIndex);
    }
}
