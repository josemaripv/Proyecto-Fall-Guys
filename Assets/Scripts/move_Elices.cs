using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Elices : MonoBehaviour
{
    // Velocidad de rotación de las hélices.
    public float velocidadRotacion = 15f;

    // El GameObject vacío alrededor del cual quieres rotar.
    public Transform centroDeRotacion;

    // Método Update se llama una vez por frame.
    void Update()
    {
        // Obtén la posición del centro de rotación.
        Vector3 centroPosition = centroDeRotacion.position;

        // Calcula el vector desde el centro de rotación hasta la posición actual del objeto.
        Vector3 direccionDesdeCentro = transform.position - centroPosition;

        // Rota el objeto alrededor del centro de rotación alrededor del eje Y.
        transform.RotateAround(centroPosition, Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}
