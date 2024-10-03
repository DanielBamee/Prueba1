using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;
public class DetectorMeta : MonoBehaviour
{
    public GameObject panelMeta;
    [SerializeField]
    public TextMeshProUGUI tuTiempo;
    public float tiempo = 0;
    [SerializeField]
    public TextMeshProUGUI tiempoLogrado;

    private void Update()
    {
        tiempo = tiempo + Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Has llegado a la meta!");
            panelMeta.gameObject.SetActive(true);
            other.GetComponent<PlayerBehaviour>().enabled = false;
            tuTiempo.text = "Este ha sido tu tiempo:";
            tiempoLogrado.text = tiempo.ToString();
        }
    }
}
