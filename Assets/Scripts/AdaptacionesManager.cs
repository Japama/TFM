using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptacionesManager : MonoBehaviour
{

    public static bool avisar = true;

    public static bool atenuarSonidos = true;


    private static bool vidasYcheckpoints = false;
    public static bool VidasYcheckpoints
    {
        get { return vidasYcheckpoints; }
        set
        {
            if (vidasYcheckpoints == value) return;
            vidasYcheckpoints = value;
            ShowLifesInScreen();
        }
    }

    private static GameObject lifesManager;
    private static void ShowLifesInScreen()
    {
        if (lifesManager == null)
            lifesManager = GameObject.FindGameObjectWithTag("LifesManager");
        if (lifesManager != null)
            lifesManager.SetActive(vidasYcheckpoints);
    }

    private static bool pictogramas = false;
    public static bool Pictogramas
    {
        get
        {
            return pictogramas;
        }
        set
        {
            if (pictogramas == value) return;
            pictogramas = value;
        }
    }

    #region Controles
    private static GameObject controlesEnPantalla;
    private static bool mostrarControles = true;
    public static bool MostrarControles
    {
        get
        {
            return mostrarControles;
        }
        set
        {
            if (mostrarControles == value) return;
            mostrarControles = value;
            MostrarOcultarControles();
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private static void MostrarOcultarControles()
    {
        if (controlesEnPantalla == null)
            controlesEnPantalla = GameObject.FindGameObjectWithTag("CanvasScreenControllers");
        if (controlesEnPantalla != null)
            controlesEnPantalla.SetActive(mostrarControles);
    }
    #endregion
}
