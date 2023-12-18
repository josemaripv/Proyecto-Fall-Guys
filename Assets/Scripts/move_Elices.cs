using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Elices : MonoBehaviour
{
    // Velocidad de rotaci�n de las h�lices.
    public float velocidadRotacion = 15f;

    // El GameObject vac�o alrededor del cual quieres rotar.
    public Transform centroDeRotacion;

    // M�todo Update se llama una vez por frame.
    void Update()
    {
        // Obt�n la posici�n del centro de rotaci�n.
        Vector3 centroPosition = centroDeRotacion.position;

        // Calcula el vector desde el centro de rotaci�n hasta la posici�n actual del objeto.
        Vector3 direccionDesdeCentro = transform.position - centroPosition;

        // Rota el objeto alrededor del centro de rotaci�n alrededor del eje Y.
        transform.RotateAround(centroPosition, Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}
