using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Arreglo de referencias a los objetos de representación visual de las vidas.
    public GameObject[] vidas;

    // Método para desactivar una vida específica según su índice.
    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }
}
