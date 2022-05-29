using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptacionesManager : MonoBehaviour
{

    private static bool avisar = true;
    private static bool atenuarSonidos = true;
    private static bool mostrarControles = true;
    private static bool pictogramas = true;
    private static bool vidasYcheckpoints = true;

    private static GameObject avisoEnemigos;

    public static bool Avisar
    {
        get { return avisar; }
        set
        {
            avisar = value;
            SwitchWarningZone();
        }
    }

    private static void SwitchWarningZone()
    {
        if (avisoEnemigos == null)
            avisoEnemigos = GameObject.FindGameObjectWithTag("AvisoEnemigosManager");
        if(avisoEnemigos != null)
            avisoEnemigos.SetActive(avisar);

    }

    private static AudioMixerManager audioMixerManager;

    public static bool AtenuarSonidos
    {
        get { return atenuarSonidos; }
        set
        {
            atenuarSonidos = value;
            SwitchAttenuateSounds();
        }
    }

    private static void SwitchAttenuateSounds()
    {
        if (GameObject.FindGameObjectWithTag("AudioMixerManager").TryGetComponent<AudioMixerManager>(out audioMixerManager))
            if (atenuarSonidos)
                audioMixerManager.SetAdaptedAudioMixer();
            else
                audioMixerManager.SetNormalAudioMixer();
    }

    private static GameObject controlesEnPantalla;
    private static GameObject controlesEnPantallaPictogramas;
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
            if (mostrarControles)
                SwitchShowControllers();
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

    private static void SwitchShowControllers()
    {
        if (controlesEnPantalla == null)
            controlesEnPantalla = GameObject.FindGameObjectWithTag("CanvasScreenControllers");
        if (controlesEnPantallaPictogramas == null)
            controlesEnPantallaPictogramas = GameObject.FindGameObjectWithTag("ControlesPantallaPictogramas");

        if (controlesEnPantalla != null && controlesEnPantallaPictogramas != null)
            if (mostrarControles)
                if (pictogramas)
                {
                    controlesEnPantallaPictogramas.SetActive(mostrarControles);
                    controlesEnPantalla.SetActive(!mostrarControles);
                }
                else
                {
                    controlesEnPantalla.SetActive(mostrarControles);
                    controlesEnPantallaPictogramas.SetActive(!mostrarControles);
                }

            else
            {
                controlesEnPantalla.SetActive(false);
                controlesEnPantallaPictogramas.SetActive(false);
            }
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
        AtenuarSonidos = atenuarSonidos;
        MostrarControles = mostrarControles;
        Pictogramas = pictogramas;
        VidasYcheckpoints = vidasYcheckpoints;
        Avisar = Avisar;
    }
}
