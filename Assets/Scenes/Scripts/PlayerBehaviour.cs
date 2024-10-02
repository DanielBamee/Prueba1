using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    public float fuerzaDeSalto = 10f;
    public float movimientoPj = 5f;
    public int contadorDeMonedas = 0;
    private Rigidbody rbJugador;
    public bool enElSuelo;
    public TextMeshProUGUI coinText;
    public AudioClip specialCoinSFX;
    public AudioClip coinSFX;

    // Start is called before the first frame update
    private void Start()
    {
        rbJugador = GetComponent<Rigidbody>();
        enElSuelo = false;
    }

    // Update is called once per frame
    private void Update()
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
           // Debug.Log("Esta en el suelo");
            enElSuelo = true;
        }
        else
            enElSuelo = false;

        //moneda normal
        if (other.CompareTag("CoinItem"))
        {
            contadorDeMonedas = contadorDeMonedas + 1;
            Debug.Log("Ahora tienes " + contadorDeMonedas + " monedas");
            AudioSource.PlayClipAtPoint(coinSFX, transform.position);
        }
        //moneda especial
        else if (other.CompareTag("SpecialCoinItem"))
        {
            contadorDeMonedas = contadorDeMonedas + 5;
            Debug.Log("Ahora tienes " + contadorDeMonedas + " monedas");
            AudioSource.PlayClipAtPoint(specialCoinSFX, transform.position);
        }
        if (other.tag.Contains("Coin"))
        {
            other.gameObject.SetActive(false);
            coinText.text = "Monedas: " + contadorDeMonedas.ToString();
        }
        
    }
}
