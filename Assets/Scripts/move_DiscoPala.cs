using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDiscoPala : MonoBehaviour
{
    // Velocidad de rotación del disco.
    public float velocidadRotacion = 40f;

  
    // Método Update se llama una vez por frame.
    void Update()
    {
        // Rota el objeto alrededor de su propio eje vertical en dirección opuesta.
        transform.Rotate(-Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}