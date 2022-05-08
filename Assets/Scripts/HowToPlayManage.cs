using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayManage : MonoBehaviour
{
    [SerializeField]
    GameObject HowToPlayPanel;
    
    [SerializeField]
    GameObject HowToPlayPictograms;
    
    [SerializeField]
    GameObject Controllers;
    
    [SerializeField]
    GameObject ControllersPictogram;


    public void OpenHowToPlay()
    {
        if (AdaptacionesManager.Pictogramas)
            OpenHowToPlayPictograms();
        else
            OpenHowToPlayLetters();
    }

    public void OpenControllers()
    {
        if (AdaptacionesManager.Pictogramas)
            OpenControllersPictograms();
        else
            OpenControllersLetters();
    }

    public void OpenHowToPlayLetters()
    {
        HowToPlayPanel.SetActive(true);
    }

    public void OpenHowToPlayPictograms()
    {
        HowToPlayPictograms.SetActive(true);
    }

    public void OpenControllersLetters()
    {
        Controllers.SetActive(true);
    }

    public void OpenControllersPictograms()
    {
        ControllersPictogram.SetActive(true);
    }
    
    public void CloseAll()
    {
        HowToPlayPanel.SetActive(false);
        HowToPlayPictograms.SetActive(false);
        Controllers.SetActive(false);
        ControllersPictogram.SetActive(false);
    }

    public void CloseHowToPlay()
    {
        HowToPlayPanel.SetActive(false);
    }


    public void CloseControllers()
    {
        HowToPlayPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CloseAll();
    }
}
