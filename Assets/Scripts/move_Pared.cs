using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Pared : MonoBehaviour
{
    // Ancho total de movimiento de la pared.
    public float ancho;

    // Velocidad de oscilación de la pared.
    public float velocidad;

    // Posición central en el eje X.
    private float xCentro;

    // Método Start se llama una vez al inicio del objeto.
    void Start()
    {
        // Almacena la posición central en el eje X al inicio.
        xCentro = transform.position.x;
    }

    
    void Update()
    {
        // Calcula la nueva posición en el eje X usando la función PingPong para oscilar.
        float nuevaX = xCentro + Mathf.PingPong(Time.time * velocidad, ancho / 2f);

        // Actualiza la posición de la pared en el eje X.
        transform.position = new Vector3(nuevaX, transform.position.y, transform.position.z);
    }
}