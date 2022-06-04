using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuOpciones;
    public GameObject MenuPausa;
    [SerializeField]
    GameObject Preaviso;


    private void Update()
    {
        if (Preaviso == null || !Preaviso.activeSelf)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (MenuOpciones.activeSelf)
                    CerrarOpciones();
                else if (SceneManager.GetActiveScene().name != "MenuPrincipal")
                {
                    if (MenuPausa.activeSelf)
                        ResumeGame();
                    else
                        PauseGame();
                }
            }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        MenuPausa.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        MenuPausa.SetActive(true);
    }

    public void NuevaPartida()
    {
        ResumeGame();
        SceneManager.LoadSceneAsync("Tutorial");
    }

    public void IrAlMenu()
    {
        ResumeGame();
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
