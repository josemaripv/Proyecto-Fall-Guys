using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Zepelin : MonoBehaviour
{
    public float velocidad = 15.0f;
    public float distanciaRecorridaMaxima = 10.0f; // Nueva variable para la distancia máxima recorrida
    private float distanciaRecorrida = 0.0f; // Variable para mantener un seguimiento de la distancia recorrida

    void Update()
    {
        // Mueve el objeto hacia adelante
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        // Actualiza la distancia recorrida
        distanciaRecorrida += velocidad * Time.deltaTime;

        // Comprueba si la distancia recorrida supera la distancia máxima
        if (distanciaRecorrida > distanciaRecorridaMaxima)
        {
            // Destruye el objeto
            Destroy(gameObject);
        }
    }
}
