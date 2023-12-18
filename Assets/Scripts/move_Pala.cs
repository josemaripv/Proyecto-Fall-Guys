using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Pala : MonoBehaviour
{
    // Velocidad de rotaci�n de la pala.
    public float velocidadRotacion = 15f;

    // M�todo Start se llama una vez al inicio del objeto.
    void Start()
    {
        // Inicia la rutina para cambiar la direcci�n de rotaci�n.
        StartCoroutine(CambiarDireccionRotacion());
    }

    // M�todo Update se llama una vez por frame.
    void Update()
    {
        // Rotar las palas en el eje Y (puedes ajustar el eje seg�n tu dise�o).
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }

    // Rutina que cambia la direcci�n de rotaci�n cada tres segundos.
    IEnumerator CambiarDireccionRotacion()
    {
        while (true)
        {
            // Espera tres segundos.
            yield return new WaitForSeconds(3f);

            // Cambia la direcci�n de rotaci�n invirtiendo la velocidad.
            velocidadRotacion *= -1;
        }
    }
}
