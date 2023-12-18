using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Arreglo de referencias a los objetos de representaci�n visual de las vidas.
    public GameObject[] vidas;

    // M�todo para desactivar una vida espec�fica seg�n su �ndice.
    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }
}
