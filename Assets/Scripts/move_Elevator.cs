using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Elevator : MonoBehaviour
{
    // Velocidad de movimiento de la plataforma.
    public float velocidad = 1f;

    // Altura a la que la plataforma se mueve hacia arriba.
    public float alturaObjetivo = 80f;

    // Indica si la plataforma está subiendo o bajando.
    private bool subiendo = true;

    // Almacena la posición inicial de la plataforma.
    private Vector3 posicionInicial;

    // Método Start se llama una vez al inicio del objeto.
    void Start()
    {
        // Almacena la posición inicial al inicio.
        posicionInicial = transform.position;
    }

    // Método Update se llama una vez por frame.
    void Update()
    {
        // Calcular el desplazamiento basado en la dirección y la velocidad.
        float desplazamiento = (subiendo ? 1 : -1) * velocidad * Time.deltaTime;

        // Mover la plataforma en la dirección vertical (y).
        transform.Translate(Vector3.up * desplazamiento);

        // Verificar y cambiar la dirección si alcanza la altura objetivo o baja por debajo de la posición inicial.
        if ((subiendo && transform.position.y >= alturaObjetivo) || (!subiendo && transform.position.y <= posicionInicial.y))
        {
            // Cambiar la dirección (subiendo a bajando o viceversa).
            subiendo = !subiendo;
        }
    }
}