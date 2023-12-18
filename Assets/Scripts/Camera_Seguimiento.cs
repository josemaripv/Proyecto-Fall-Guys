using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Seguimiento : MonoBehaviour
{
    // Referencia al objeto jugador que la cámara sigue.
    public GameObject jugador;

    // Referencia al script del personaje para obtener información.
    public move_Persona personaje;

    // Distancia inicial entre la cámara y el jugador.
    Vector3 distancia;

    // Altura inicial de la cámara.
    float alturaInicial;

    // Suavidad de movimiento de la cámara.
    public float suavidad = 10f;

    // Método Start se llama una vez al inicio del objeto.
    void Start()
    {
        // Calcula la distancia inicial entre la cámara y el jugador.
        distancia = transform.position - jugador.transform.position;

        // Almacena la altura inicial de la cámara.
        alturaInicial = transform.position.y;
    }

    // Método LateUpdate se llama después de que todos los Updates hayan ocurrido.
    void LateUpdate()
    {
        // Posición objetivo de la cámara.
        Vector3 targetPosition;

        // Verifica si el personaje está en el suelo.
        if (personaje.suelo())
        {
            // Si el personaje está en el suelo, la cámara sigue completamente al jugador.
            targetPosition = new Vector3(
                jugador.transform.position.x + distancia.x,
                jugador.transform.position.y + distancia.y,
                jugador.transform.position.z + distancia.z
            );

            // Actualiza la altura inicial de la cámara.
            alturaInicial = transform.position.y;
        }
        else
        {
            // Si el personaje no está en el suelo, la cámara mantiene su altura inicial.
            targetPosition = new Vector3(
                jugador.transform.position.x + distancia.x,
                alturaInicial, // Mantén la altura inicial de la cámara
                jugador.transform.position.z + distancia.z
            );
        }

        // Mueve suavemente la posición de la cámara hacia la posición objetivo.
        transform.position = Vector3.Lerp(transform.position, targetPosition, suavidad * Time.deltaTime);
    }
}
