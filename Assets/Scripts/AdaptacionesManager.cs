using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptacionesManager: MonoBehaviour
{
    static public bool pictogramas;
    static public bool avisar;
    static public bool mostrarControles;
    static public bool atenuarSonidos;
    static public bool vidasYcheckpoints;

    [Header("Pictogramas")]
    public GameObject pictogramasSiOn;
    public GameObject pictogramasSiOff;
    public GameObject pictogramasNoOn;
    public GameObject pictogramasNoOff;
    [Space(3)]

    [Header("Avisar")]
    public GameObject AvisarSiOn;
    public GameObject AvisarSiOff;
    public GameObject AvisarNoOn;
    public GameObject AvisarNoOff;
    [Space(3)]

    [Header("Mostrar controles")]
    public GameObject MostrarControlesSiOn;
    public GameObject MostrarControlesSiOff;
    public GameObject MostrarControlesNoOn;
    public GameObject MostrarControlesNoOff;
    [Space(3)]

    [Header("Atenuar sonidos")]
    public GameObject AtenuarSonidosSiOn;
    public GameObject AtenuarSonidosSiOff;
    public GameObject AtenuarSonidosNoOn;
    public GameObject AtenuarSonidosNoOff;
    [Space(3)]

    [Header("Vidas y checkpoints")]
    public GameObject VidasYcheckpointsSiOn;
    public GameObject VidasYcheckpointsSiOff;
    public GameObject VidasYcheckpointsNoOn;
    public GameObject VidasYcheckpointsNoOff;


    public void SwitchPictogramas()
    {
        pictogramas = !pictogramas;
        pictogramasSiOn.SetActive(pictogramas);
        pictogramasSiOff.SetActive(!pictogramas);
        pictogramasNoOn.SetActive(!pictogramas);
        pictogramasNoOff.SetActive(pictogramas);
    }

    public void SwitchAvisoMonstruos()
    {
        avisar = !avisar;
        AvisarSiOn.SetActive(avisar);
        AvisarSiOff.SetActive(!avisar);
        AvisarNoOn.SetActive(!avisar);
        AvisarNoOff.SetActive(avisar);
    }

    public void SwitchMostrarControles()
    {
        mostrarControles = !mostrarControles;
        MostrarControlesSiOn.SetActive(mostrarControles);
        MostrarControlesSiOff.SetActive(!mostrarControles);
        MostrarControlesNoOn.SetActive(!mostrarControles);
        MostrarControlesNoOff.SetActive(mostrarControles);
    }

    public void SwitchAtenuarSonidos()
    {
        atenuarSonidos = !atenuarSonidos;
        AtenuarSonidosSiOn.SetActive(atenuarSonidos);
        AtenuarSonidosSiOff.SetActive(!atenuarSonidos);
        AtenuarSonidosNoOn.SetActive(!atenuarSonidos);
        AtenuarSonidosNoOff.SetActive(atenuarSonidos);
    }

    public void SwitchVidasYcheckpoints()
    {
        vidasYcheckpoints = !vidasYcheckpoints;
        VidasYcheckpointsSiOn.SetActive(vidasYcheckpoints);
        VidasYcheckpointsSiOff.SetActive(!vidasYcheckpoints);
        VidasYcheckpointsNoOn.SetActive(!vidasYcheckpoints);
        VidasYcheckpointsNoOff.SetActive(vidasYcheckpoints);
    }

    // Start is called before the first frame update
    void Start()
    {
        pictogramas = true;
        avisar = true;
        mostrarControles = true;
        atenuarSonidos = true;
        vidasYcheckpoints = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
