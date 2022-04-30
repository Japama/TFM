using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuOpciones;

    public void NuevaPartida()
    {
        SceneManager.LoadSceneAsync("Tutorial");
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void IrAOpciones()
    {
        MenuOpciones.SetActive(true);
    }

    public void CerrarOpciones()
    {
        MenuOpciones.SetActive(false);
    }

    public void AbrirOpciones()
    {
        MenuOpciones.SetActive(true);
    }


    public void SalirJuego()
    {
    #if UNITY_EDITOR
            Debug.Log("Saliendo del juego...");
            EditorApplication.isPlaying = false;
    #else
                Application.Quit();
    #endif
    }
}
