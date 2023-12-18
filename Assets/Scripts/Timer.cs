using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Referencia al componente de texto para mostrar el tiempo.
    [SerializeField] private TMP_Text textoTemporizador;

    // Tiempo inicial en segundos.
    [SerializeField, Tooltip("Tiempo en segundos")] private float tiempoTotal;

    // Variables para almacenar los minutos y segundos restantes.
    private int minutos, segundos;

    // Método Update se llama una vez por frame.
    private void Update()
    {
        // Resta el tiempo transcurrido en cada frame.
        tiempoTotal -= Time.deltaTime;

        // Asegura que el tiempo no sea negativo.
        if (tiempoTotal < 0)
            tiempoTotal = 0;

        // Calcula los minutos y segundos restantes.
        minutos = (int)(tiempoTotal / 60f);
        segundos = (int)(tiempoTotal - minutos * 60f);

        // Actualiza el texto del temporizador en el formato "MM:SS".
        textoTemporizador.text = string.Format("{0:00}:{1:00}", minutos, segundos);

        // Si el tiempo llega a cero, carga la escena de Derrota.
        if (tiempoTotal == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Derrota");
        }
    }
}