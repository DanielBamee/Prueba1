using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectorDeColisiones : MonoBehaviour
{
    [SerializeField]
    private Material materialRojo;
    
    [SerializeField]
    private Material materialBlanco;
    private bool paredRoja = false;
    private float tiempoEnRojo = 5f;

    private void Update()
    {
        if (paredRoja == true)
        {
            tiempoEnRojo = tiempoEnRojo - Time.deltaTime;
            if (tiempoEnRojo < 0.0f)
            {
                gameObject.GetComponent<MeshRenderer>().material = materialBlanco;
                paredRoja = false;
                tiempoEnRojo = 0;
            }
        }
            
    }

    private void OnCollisionEnter(Collision detectorColision)
    {
        if (detectorColision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material = materialRojo;
            paredRoja=true;

        }
    }

}
