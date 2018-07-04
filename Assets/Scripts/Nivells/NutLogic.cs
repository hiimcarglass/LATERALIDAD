using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutLogic : MonoBehaviour
{
    ///////// Movimiento y rotacion de cada Tuerca (Coleccionable)

    public bool direccion;

    float angle;
    
    // Use this for initialization
    void Start()
    {

        direccion = false;
        angle = 5f;
         
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Euler(-45, angle , -45);
        angle += 25f * Time.deltaTime;
        if (this.transform.localPosition.y < 0.8f)
        {
            direccion = false;
        }
        if (this.transform.localPosition.y > 1.5f)
        {
            direccion = true;
        }

        if (direccion)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * 0.4f, transform.position.z);
        }

        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * 0.4f, transform.position.z);
        }


    }

   
}
