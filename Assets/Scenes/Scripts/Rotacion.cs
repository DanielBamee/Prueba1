using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float rotacionY = 90f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotacionY * Time.deltaTime, 0f);
    }
}
