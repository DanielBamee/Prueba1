using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;
public class DetectorMeta : MonoBehaviour
{
    public GameObject meta;

    [SerializeField]
    private TextMeshProFloatingText tiempoActual;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Has llegado a la meta!");
            meta.gameObject.SetActive(true);
            other.GetComponent<PlayerBehaviour>().enabled = false;
        }
    }
}
