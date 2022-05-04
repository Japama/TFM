using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayManage : MonoBehaviour
{
    [SerializeField]
    GameObject HowToPlayPanel;
    public void Open()
    {
        HowToPlayPanel.SetActive(true);
    }

    public void Close()
    {
        HowToPlayPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Close();
    }
}
