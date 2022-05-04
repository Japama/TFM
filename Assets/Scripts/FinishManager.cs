using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            int sceneId = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadSceneAsync(++sceneId);
        }
    }
}
