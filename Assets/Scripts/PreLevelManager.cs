using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreLevelManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            gameObject.SetActive(false);
        }

    }

    private void OnLevelWasLoaded(int level)
    {
        if (AdaptacionesManager.Avisar)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
        } else
            gameObject.SetActive(false);
    }
}
