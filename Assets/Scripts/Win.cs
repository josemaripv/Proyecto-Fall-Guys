using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    // Este m�todo se llama cuando se hace clic en el bot�n de "Menu" en la pantalla de victoria.
    public void Menu()
    {
        // Carga la escena llamada "Inicio".
        SceneManager.LoadScene("Inicio");
    }

    // Este m�todo se llama cuando se hace clic en el bot�n de "Reset" en la pantalla de victoria.
    public void Reset()
    {
        // Carga la escena llamada "SampleScene" para reiniciar el juego.
        SceneManager.LoadScene("SampleScene");
    }
}