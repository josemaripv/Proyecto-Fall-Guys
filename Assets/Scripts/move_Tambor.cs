using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Tambor : MonoBehaviour
{
    public float velocidad = 2f; //Velocidad rotacion
    public float fuerzaEmpuje = 10f; // Fuerza de empuje al chocar con el personaje

    

    void Update()
    {
        // Rotar el tambor en el eje Y
        transform.Rotate(Vector3.up, velocidad * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto ha chocado con el personaje
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calcula la dirección del empuje
            Vector3 direccionEmpuje = collision.contacts[0].point - transform.position;
            direccionEmpuje = -direccionEmpuje.normalized; // Invierte la dirección

            // Agrega un componente lateral al empuje (usando el eje X, por ejemplo)
            direccionEmpuje += Vector3.right * 0.5f; // Ajusta la magnitud y dirección según sea necesario

            // Aplica el empuje al personaje
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
        }
    }
}
