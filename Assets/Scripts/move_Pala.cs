using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Pala : MonoBehaviour
{
    // Velocidad de rotación de la pala.
    public float velocidadRotacion = 15f;

    // Método Start se llama una vez al inicio del objeto.
    void Start()
    {
        // Inicia la rutina para cambiar la dirección de rotación.
        StartCoroutine(CambiarDireccionRotacion());
    }

    // Método Update se llama una vez por frame.
    void Update()
    {
        // Rotar las palas en el eje Y (puedes ajustar el eje según tu diseño).
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }

    // Rutina que cambia la dirección de rotación cada tres segundos.
    IEnumerator CambiarDireccionRotacion()
    {
        while (true)
        {
            // Espera tres segundos.
            yield return new WaitForSeconds(3f);

            // Cambia la dirección de rotación invirtiendo la velocidad.
            velocidadRotacion *= -1;
        }
    }
}
