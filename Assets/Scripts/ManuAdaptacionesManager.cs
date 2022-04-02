using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuAdaptacionesManager: MonoBehaviour
{
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
        AdaptacionesManager.pictogramas = !AdaptacionesManager.pictogramas;
        UpdatePictogramas();
    }

    private void UpdatePictogramas()
    {
        pictogramasSiOn.SetActive(AdaptacionesManager.pictogramas);
        pictogramasSiOff.SetActive(!AdaptacionesManager.pictogramas);
        pictogramasNoOn.SetActive(!AdaptacionesManager.pictogramas);
        pictogramasNoOff.SetActive(AdaptacionesManager.pictogramas);
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
        AdaptacionesManager.mostrarControles = !AdaptacionesManager.mostrarControles;
        UpdateMostrarControles();
    }

    private void UpdateMostrarControles()
    {
        MostrarControlesSiOn.SetActive(AdaptacionesManager.mostrarControles);
        MostrarControlesSiOff.SetActive(!AdaptacionesManager.mostrarControles);
        MostrarControlesNoOn.SetActive(!AdaptacionesManager.mostrarControles);
        MostrarControlesNoOff.SetActive(AdaptacionesManager.mostrarControles);
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
