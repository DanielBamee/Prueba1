using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Temporizador : MonoBehaviour
{
    public float tiempo = 0f;
    private bool enPartida = true;
    public GameObject jugador;
    public GameObject panelDerrota;


    // Update is called once per frame
    private void Update()
    {
        if (enPartida == true)
        {
            tiempo = tiempo + Time.deltaTime;
        }
       

        if (tiempo > 120f)
        {
            jugador.GetComponent<PlayerBehaviour>().enabled = false;
            panelDerrota.gameObject.SetActive(true);
            enPartida = false; 
        }
    }
}
