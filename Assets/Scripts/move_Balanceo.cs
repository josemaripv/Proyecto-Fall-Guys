using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Balanceo : MonoBehaviour
{
    // Amplitud del balanceo en grados.
    public float amplitud = 45f;

    // Velocidad de balanceo.
    public float velocidad = 2f;

    // Fuerza de empuje al chocar con el personaje.
    public float fuerzaEmpuje = 10f;

    // Rotación inicial del objeto.
    private Quaternion rotacionInicial;

    // Método Start se llama una vez al inicio del objeto.
    void Start()
    {
        // Almacena la rotación inicial del objeto.
        rotacionInicial = transform.rotation;
    }

    // Método Update se llama una vez por frame.
    void Update()
    {
        // Calcula la rotación sinusoidal.
        float angulo = amplitud * Mathf.Sin(Time.time * velocidad);

        // Aplica la rotación al objeto alrededor del eje global Y.
        transform.rotation = rotacionInicial * Quaternion.Euler(0f, angulo, 0f);
    }

    // Método OnCollisionEnter se llama cuando el objeto colisiona con otro objeto.
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto ha chocado con el personaje.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calcula la dirección del empuje desde el punto de contacto.
            Vector3 direccionEmpuje = collision.contacts[0].point - transform.position;
            direccionEmpuje = -direccionEmpuje.normalized; // Invierte la dirección.

            // Agrega un componente lateral al empuje (usando el eje X, por ejemplo).
            direccionEmpuje += Vector3.right * 0.5f; // Ajusta la magnitud y dirección según sea necesario.

            // Aplica el empuje al personaje mediante una fuerza de impulso.
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
        }
    }
}
