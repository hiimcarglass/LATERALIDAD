using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarImatges : MonoBehaviour {

   

    GameObject _controlMov;

    MovControl _controlSpeed;

    public GameObject LLum1; // per fer animacio bruta
    public GameObject LLum2;

    bool cambio;
	// Use this for initialization
	void Start () {

        _controlMov = GameObject.Find("MovControl");

        _controlSpeed = _controlMov.GetComponent<MovControl>();

        cambio = true;
        InvokeRepeating("EstadosLuces", 4f, 0.5f);
        LLum2.SetActive(false);
        LLum1.SetActive(false);
	}
	
	void Update () {

    }


    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Me han dado");

            other.GetComponent<PlayerController>().showImg();

            
            VariablesSingleton._instance.SetEnablePausa(false);

     

            _controlSpeed.setSpeed(7.5f);
            //_controlSpeed.setSpeed(15f);

        }
            
    }

    void EstadosLuces()
    {
        if (cambio)
        {
            LLum1.SetActive(true);
            LLum2.SetActive(false);
            cambio = false;
        }
        else
        {
            LLum1.SetActive(false);
            LLum2.SetActive(true);
            cambio = true;


        }
    }

}
