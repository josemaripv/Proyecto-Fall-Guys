using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class zepelin : MonoBehaviour
{
    // Prefab del zepel�n que se va a instanciar.
    [SerializeField] private GameObject zepelinPrefab;

    // M�todo Start se llama una vez al inicio del objeto.
    void Start()
    {
        // Inicia la rutina para instanciar zepelines peri�dicamente.
        StartCoroutine(SpawnZepelin());
    }

    // Rutina que instancia zepelines cada cierto tiempo.
    IEnumerator SpawnZepelin()
    {
        while (true)
        {
            // Instancia un nuevo zepel�n en la posici�n y rotaci�n actual del objeto que tiene este script.
            Instantiate(zepelinPrefab, transform.position, Quaternion.Euler(0, -90, 90));

            // Espera 10 segundos antes de instanciar el pr�ximo zepel�n.
            yield return new WaitForSeconds(10);
        }
    }
}
