using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio_Canva : MonoBehaviour
{
    // Este m�todo se llama cuando se hace clic en el bot�n para comenzar el juego desde el men� principal.
    public void EscenaJuego()
    {
        // Carga la escena llamada "SampleScene".
        SceneManager.LoadScene("SampleScene");
    }

    // Este m�todo se llama cuando se hace clic en el bot�n para salir del juego desde el men� principal.
    public void Salir()
    {
        // Sale de la aplicaci�n.
        Application.Quit();
    }
}