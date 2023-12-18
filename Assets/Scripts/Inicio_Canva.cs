using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio_Canva : MonoBehaviour
{
    // Este método se llama cuando se hace clic en el botón para comenzar el juego desde el menú principal.
    public void EscenaJuego()
    {
        // Carga la escena llamada "SampleScene".
        SceneManager.LoadScene("SampleScene");
    }

    // Este método se llama cuando se hace clic en el botón para salir del juego desde el menú principal.
    public void Salir()
    {
        // Sale de la aplicación.
        Application.Quit();
    }
}