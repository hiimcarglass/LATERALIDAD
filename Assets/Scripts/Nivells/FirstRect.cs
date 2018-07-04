using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRect : MonoBehaviour {


   
    // ESTE SCRIPT SOLO SIRVE PARA ELIMINAR LA PRIMERA RECTA QUE PONEMOS PORQUE EL CRUCE ES DEMASIADO CORTO
    

	// Use this for initialization
	void Start ()
    {

        Invoke("Destroyme", 15f);

        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Destroyme()
    {
        if (this.GetComponentInParent<GroundPoints>())
        {
            this.GetComponentInParent<GroundPoints>().Destruirme();
        }
        Destroy(this.gameObject);
    }
}
