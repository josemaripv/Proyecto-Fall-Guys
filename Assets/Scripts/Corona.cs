using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corona : MonoBehaviour
{
    public float amplitude = 1.0f; // Altura m�xima de la oscilaci�n
    public float speed = 2.0f;      // Velocidad de la oscilaci�n

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calcular la posici�n vertical basada en una funci�n seno
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;

        // Aplicar la posici�n vertical a la corona
        transform.position = initialPosition + new Vector3(0f, yOffset, 0f);
    }
}
