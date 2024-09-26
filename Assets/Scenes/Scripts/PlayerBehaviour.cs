using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    public float fuerzaDeSalto = 10f;
    public float movimientoPj = 5f;
    public int contadorDeMonedas = 0;
    Rigidbody rbJugador;
    public bool enElSuelo = false;
    public TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        rbJugador = GetComponent<Rigidbody>();
        enElSuelo = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Salto
        if (Input.GetKeyDown(KeyCode.Space) && enElSuelo == true)
        { 
        rbJugador.AddForce(transform.up * fuerzaDeSalto, ForceMode.Impulse);
        }

        //Movimiento WASD
        Vector3 movement = new Vector3();
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        rbJugador.AddForce(movement * Time.deltaTime * movimientoPj, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
        }
            
        //moneda normal
        if (other.CompareTag("CoinItem"))
        {
            contadorDeMonedas = contadorDeMonedas + 1;
            Debug.Log("Ahora tienes " + contadorDeMonedas + " monedas");
            coinText.text = "Monedicas:" + contadorDeMonedas.ToString();
        }
        //moneda especial
        if (other.CompareTag("SpecialCoinItem"))
        {
            contadorDeMonedas = contadorDeMonedas + 5;
            Debug.Log("Ahora tienes " + contadorDeMonedas + " monedas");
            coinText.text = "Monedas: " + contadorDeMonedas.ToString();
        }

        other.gameObject.SetActive(false);
    }
}
