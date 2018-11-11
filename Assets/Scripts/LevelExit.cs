using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private float LevelLoadDelay = 1.5f;
    [SerializeField] private float LevelExitSlowSpeed = 0.2f;
    [SerializeField] private float LevelNormalSpeed = 1f;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = LevelExitSlowSpeed;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = LevelNormalSpeed;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex +1);
    }
}
