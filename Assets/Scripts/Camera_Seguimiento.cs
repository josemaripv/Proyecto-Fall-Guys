using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Seguimiento : MonoBehaviour
{
    // Referencia al objeto jugador que la c�mara sigue.
    public GameObject jugador;

    // Referencia al script del personaje para obtener informaci�n.
    public move_Persona personaje;

    // Distancia inicial entre la c�mara y el jugador.
    Vector3 distancia;

    // Altura inicial de la c�mara.
    float alturaInicial;

    // Suavidad de movimiento de la c�mara.
    public float suavidad = 10f;

    // M�todo Start se llama una vez al inicio del objeto.
    void Start()
    {
        // Calcula la distancia inicial entre la c�mara y el jugador.
        distancia = transform.position - jugador.transform.position;

        // Almacena la altura inicial de la c�mara.
        alturaInicial = transform.position.y;
    }

    // M�todo LateUpdate se llama despu�s de que todos los Updates hayan ocurrido.
    void LateUpdate()
    {
        // Posici�n objetivo de la c�mara.
        Vector3 targetPosition;

        // Verifica si el personaje est� en el suelo.
        if (personaje.suelo())
        {
            // Si el personaje est� en el suelo, la c�mara sigue completamente al jugador.
            targetPosition = new Vector3(
                jugador.transform.position.x + distancia.x,
                jugador.transform.position.y + distancia.y,
                jugador.transform.position.z + distancia.z
            );

            // Actualiza la altura inicial de la c�mara.
            alturaInicial = transform.position.y;
        }
        else
        {
            // Si el personaje no est� en el suelo, la c�mara mantiene su altura inicial.
            targetPosition = new Vector3(
                jugador.transform.position.x + distancia.x,
                alturaInicial, // Mant�n la altura inicial de la c�mara
                jugador.transform.position.z + distancia.z
            );
        }

        // Mueve suavemente la posici�n de la c�mara hacia la posici�n objetivo.
        transform.position = Vector3.Lerp(transform.position, targetPosition, suavidad * Time.deltaTime);
    }
}
