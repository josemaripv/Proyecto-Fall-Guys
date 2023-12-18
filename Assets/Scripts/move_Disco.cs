using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDisco : MonoBehaviour
{
    // Almacena la rotación original del personaje cuando colisiona con el disco.
    private Quaternion rotacionOriginalPersonaje;

    // Velocidad de rotación del disco.
    public float velocidadRotacion = 40f;

    // Se ejecuta cuando el disco colisiona con otro objeto.
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisiona es el jugador.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Almacena la rotación actual del personaje.
            rotacionOriginalPersonaje = collision.transform.rotation;

            // Hace que el personaje sea hijo del disco.
            collision.transform.parent = transform;
        }
    }

    // Se ejecuta cuando el objeto deja de colisionar con otro objeto.
    private void OnCollisionExit(Collision collision)
    {
        // Verifica si el objeto que deja de colisionar es el jugador.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deja de hacer que el personaje sea hijo del disco.
            collision.transform.parent = null;

            // Restablece la rotación original del personaje.
            collision.transform.rotation = rotacionOriginalPersonaje;
        }
    }

    
    void Update()
    {
        // Gira la plataforma alrededor de su propio eje vertical local.
        transform.Rotate(Vector3.forward, velocidadRotacion * Time.deltaTime);
    }
}