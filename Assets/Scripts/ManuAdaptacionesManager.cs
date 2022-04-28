using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuAdaptacionesManager: MonoBehaviour
{
    [Header("Pictogramas")]
    public GameObject PictogramasSiOn;
    public GameObject PictogramasSiOff;
    public GameObject PictogramasNoOn;
    public GameObject PictogramasNoOff;
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
        AdaptacionesManager.Pictogramas = !AdaptacionesManager.Pictogramas;
        UpdatePictogramas();
    }

    private void UpdatePictogramas()
    {
        PictogramasSiOn.SetActive(AdaptacionesManager.Pictogramas);
        PictogramasSiOff.SetActive(!AdaptacionesManager.Pictogramas);
        PictogramasNoOn.SetActive(!AdaptacionesManager.Pictogramas);
        PictogramasNoOff.SetActive(AdaptacionesManager.Pictogramas);
    }

    public void SwitchAvisoMonstruos()
    {
        AdaptacionesManager.avisar = !AdaptacionesManager.avisar;
        UpdateAvisoMonstruos();
    }

    private void UpdateAvisoMonstruos()
    {
        AvisarSiOn.SetActive(AdaptacionesManager.avisar);
        AvisarSiOff.SetActive(!AdaptacionesManager.avisar);
        AvisarNoOn.SetActive(!AdaptacionesManager.avisar);
        AvisarNoOff.SetActive(AdaptacionesManager.avisar);
    }

    public void SwitchMostrarControles()
    {
        AdaptacionesManager.MostrarControles = !AdaptacionesManager.MostrarControles;
        UpdateMostrarControles();
    }

    private void UpdateMostrarControles()
    {
        MostrarControlesSiOn.SetActive(AdaptacionesManager.MostrarControles);
        MostrarControlesSiOff.SetActive(!AdaptacionesManager.MostrarControles);
        MostrarControlesNoOn.SetActive(!AdaptacionesManager.MostrarControles);
        MostrarControlesNoOff.SetActive(AdaptacionesManager.MostrarControles);
    }

    public void SwitchAtenuarSonidos()
    {
        AdaptacionesManager.atenuarSonidos = !AdaptacionesManager.atenuarSonidos;
        UpdateActenuarSonidos();
    }

    private void UpdateActenuarSonidos()
    {
        AtenuarSonidosSiOn.SetActive(AdaptacionesManager.atenuarSonidos);
        AtenuarSonidosSiOff.SetActive(!AdaptacionesManager.atenuarSonidos);
        AtenuarSonidosNoOn.SetActive(!AdaptacionesManager.atenuarSonidos);
        AtenuarSonidosNoOff.SetActive(AdaptacionesManager.atenuarSonidos);
    }

    public void SwitchVidasYcheckpoints()
    {
        AdaptacionesManager.vidasYcheckpoints = !AdaptacionesManager.vidasYcheckpoints;
        UpdateVidasYcheckpoints();
    }

    private void UpdateVidasYcheckpoints()
    {
        VidasYcheckpointsSiOn.SetActive(AdaptacionesManager.vidasYcheckpoints);
        VidasYcheckpointsSiOff.SetActive(!AdaptacionesManager.vidasYcheckpoints);
        VidasYcheckpointsNoOn.SetActive(!AdaptacionesManager.vidasYcheckpoints);
        VidasYcheckpointsNoOff.SetActive(AdaptacionesManager.vidasYcheckpoints);
    }

    private void Start()
    {
        UpdatePictogramas();
        UpdateAvisoMonstruos();
        UpdateActenuarSonidos();
        UpdateMostrarControles();
        UpdateVidasYcheckpoints();
    }
}
