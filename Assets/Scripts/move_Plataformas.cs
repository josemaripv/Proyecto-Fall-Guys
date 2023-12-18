using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlataformas : MonoBehaviour
{
    // Velocidad de rotaci�n de la plataforma.
    public float velocidadRotacion = 5f;

    // Par�metro de suavizado para la rotaci�n hacia el jugador.
    public float suavizado = 5f;

    // Variable para indicar si hay un jugador encima de la plataforma.
    private bool jugadorEncima = false;

    // M�todo Update se llama una vez por frame.
    private void Update()
    {
        // Verifica si hay un jugador encima de la plataforma.
        if (jugadorEncima)
        {
            // Calcula la direcci�n hacia el jugador.
            Vector3 direccionAlJugador = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;

            // Calcula la rotaci�n objetivo hacia el jugador.
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionAlJugador, Vector3.up);

            // Suaviza el cambio de rotaci�n hacia la rotaci�n objetivo.
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, Time.deltaTime * suavizado);
        }
    }

    // Se ejecuta cuando la plataforma colisiona con otro objeto.
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisiona es el jugador.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Marca que el jugador est� encima de la plataforma.
            jugadorEncima = true;
        }
    }

    // Se ejecuta cuando la plataforma deja de colisionar con otro objeto.
    private void OnCollisionExit(Collision collision)
    {
        // Verifica si el objeto que deja de colisionar es el jugador.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Marca que el jugador ya no est� encima de la plataforma.
            jugadorEncima = false;
        }
    }
}