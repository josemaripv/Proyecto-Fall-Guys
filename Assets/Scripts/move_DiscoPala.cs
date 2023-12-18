using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDiscoPala : MonoBehaviour
{
    // Velocidad de rotaci�n del disco.
    public float velocidadRotacion = 40f;

  
    // M�todo Update se llama una vez por frame.
    void Update()
    {
        // Rota el objeto alrededor de su propio eje vertical en direcci�n opuesta.
        transform.Rotate(-Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}