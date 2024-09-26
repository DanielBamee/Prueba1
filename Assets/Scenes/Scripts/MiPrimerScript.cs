using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiPrimerScript : MonoBehaviour
{
    //tipo de dato >> nombre >> ;
    int numeroDeSaltos = 0;

    public int primeroLogroSaltos = 5;
    public int segundoLogroSaltos = 10;
    public int tercerLogroSaltos = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        numeroDeSaltos = numeroDeSaltos + 1;
        //Debug.Log(gameObject.name + " ha chocado " + miVariable + " veces con " + collision.gameObject.name);

        if (numeroDeSaltos == primeroLogroSaltos || numeroDeSaltos == segundoLogroSaltos || numeroDeSaltos == tercerLogroSaltos)
        {
            Debug.Log(gameObject.name + " Has chocado " + numeroDeSaltos + " con " + collision.gameObject.name);
        }
        if (numeroDeSaltos == 20)
        {
            Destroy(gameObject);
        }
    }
}