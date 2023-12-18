using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corona : MonoBehaviour
{
    public float amplitude = 1.0f; // Altura máxima de la oscilación
    public float speed = 2.0f;      // Velocidad de la oscilación

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calcular la posición vertical basada en una función seno
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;

        // Aplicar la posición vertical a la corona
        transform.position = initialPosition + new Vector3(0f, yOffset, 0f);
    }
}
