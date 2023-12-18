using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Elevator : MonoBehaviour
{
    // Velocidad de movimiento de la plataforma.
    public float velocidad = 1f;

    // Altura a la que la plataforma se mueve hacia arriba.
    public float alturaObjetivo = 80f;

    // Indica si la plataforma est� subiendo o bajando.
    private bool subiendo = true;

    // Almacena la posici�n inicial de la plataforma.
    private Vector3 posicionInicial;

    // M�todo Start se llama una vez al inicio del objeto.
    void Start()
    {
        // Almacena la posici�n inicial al inicio.
        posicionInicial = transform.position;
    }

    // M�todo Update se llama una vez por frame.
    void Update()
    {
        // Calcular el desplazamiento basado en la direcci�n y la velocidad.
        float desplazamiento = (subiendo ? 1 : -1) * velocidad * Time.deltaTime;

        // Mover la plataforma en la direcci�n vertical (y).
        transform.Translate(Vector3.up * desplazamiento);

        // Verificar y cambiar la direcci�n si alcanza la altura objetivo o baja por debajo de la posici�n inicial.
        if ((subiendo && transform.position.y >= alturaObjetivo) || (!subiendo && transform.position.y <= posicionInicial.y))
        {
            // Cambiar la direcci�n (subiendo a bajando o viceversa).
            subiendo = !subiendo;
        }
    }
}