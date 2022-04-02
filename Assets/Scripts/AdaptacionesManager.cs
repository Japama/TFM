using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptacionesManager : MonoBehaviour
{

    public static bool pictogramas = true;
    public static bool avisar = true;
    public static bool mostrarControles = true;
    public static bool atenuarSonidos = true;
    public static bool vidasYcheckpoints = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
