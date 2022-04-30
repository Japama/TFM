using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptacionesManager : MonoBehaviour
{

    public static bool avisar = true;
    public static bool atenuarSonidos = true;

    private static bool mostrarControles = true;
    private static bool pictogramas = true;
    private static bool vidasYcheckpoints = true;

    private static GameObject controlesEnPantalla;
    private static GameObject lifesManager;

    public static bool MostrarControles
    {
        get
        {
            return mostrarControles;
        }
        set
        {
            mostrarControles = value;
            SwitchShowControllers();
        }
    }

    public static bool Pictogramas
    {
        get
        {
            return pictogramas;
        }
        set
        {
            pictogramas = value;
        }
    }

    public static bool VidasYcheckpoints
    {
        get { return vidasYcheckpoints; }
        set
        {
            vidasYcheckpoints = value;
            SwitchLifesInScreen();
        }
    }


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }

    private static void SwitchShowControllers()
    {
        if (controlesEnPantalla == null)
            controlesEnPantalla = GameObject.FindGameObjectWithTag("CanvasScreenControllers");
        if (controlesEnPantalla != null)
            controlesEnPantalla.SetActive(mostrarControles);
    }

    private static void SwitchLifesInScreen()
    {
        if (lifesManager == null)
            lifesManager = GameObject.FindGameObjectWithTag("LifesManager");
        if (lifesManager != null)
            lifesManager.SetActive(vidasYcheckpoints);
    }

    private void OnLevelWasLoaded(int level)
    {
        MostrarControles = mostrarControles;
        Pictogramas = pictogramas;
        VidasYcheckpoints = vidasYcheckpoints;
    }
}
