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

    public static bool Avisar
    {
        get { return avisar; }
        set {
            avisar = value;
            if (!avisar)
                DisableWarningZone();
        }
    }

    private static void DisableWarningZone()
    {
        throw new NotImplementedException();
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
        if (audioMixerManager == null)
            audioMixerManager = GameObject.FindGameObjectWithTag("AudioMixerManager").GetComponent<AudioMixerManager>();
        if (audioMixerManager != null)
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

        if (mostrarControles)
            if (pictogramas)
            {
                if (controlesEnPantallaPictogramas != null)
                    controlesEnPantallaPictogramas.SetActive(mostrarControles);
                if (controlesEnPantalla != null)
                    controlesEnPantalla.SetActive(!mostrarControles);
            }
            else
            {
                if (controlesEnPantalla != null)
                    controlesEnPantalla.SetActive(mostrarControles);
                if (controlesEnPantallaPictogramas != null)
                    controlesEnPantallaPictogramas.SetActive(!mostrarControles);
            }

        if (!mostrarControles)
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
    }
}
