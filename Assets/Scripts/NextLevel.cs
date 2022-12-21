using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    Scene _activeScene;
    private void Awake()
    {
        _activeScene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartLevel();
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(_activeScene.buildIndex + 1);
    }
}
