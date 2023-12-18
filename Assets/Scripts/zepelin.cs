using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class zepelin : MonoBehaviour
{
    // Prefab del zepelín que se va a instanciar.
    [SerializeField] private GameObject zepelinPrefab;

    // Método Start se llama una vez al inicio del objeto.
    void Start()
    {
        // Inicia la rutina para instanciar zepelines periódicamente.
        StartCoroutine(SpawnZepelin());
    }

    // Rutina que instancia zepelines cada cierto tiempo.
    IEnumerator SpawnZepelin()
    {
        while (true)
        {
            // Instancia un nuevo zepelín en la posición y rotación actual del objeto que tiene este script.
            Instantiate(zepelinPrefab, transform.position, Quaternion.Euler(0, -90, 90));

            // Espera 10 segundos antes de instanciar el próximo zepelín.
            yield return new WaitForSeconds(10);
        }
    }
}
