using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptacionesManager : MonoBehaviour
{

    public static bool avisar = true;

    public static bool atenuarSonidos = true;
    public static bool vidasYcheckpoints = true;

    private static GameObject controlesEnPantalla;

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
        if(controlesEnPantalla != null)
            controlesEnPantalla.SetActive(mostrarControles);
        Debug.Log("Mostrar pictogramas: " + mostrarControles.ToString());
    }

}
