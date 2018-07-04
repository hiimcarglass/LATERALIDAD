using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPoints : MonoBehaviour {

    

    // AQUEST SCRIPT NOMES SERVEIX PER FER REFERENCIA ALS PUNTS DE LA CRUILLA PERQUE EL PLAYER SAPIGA PER ON ANAR I GIRAR

    public Transform GiroDerecha;
    public Transform GiroIzquierda;
    public Transform CrearDerecha;
    public Transform CrearIzquierda;

    
    // Use this for initialization
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {

        

    }

    public void SetEliminame()
    {
        Invoke("Destruirme", 10f);
    }


    public void Destruirme()
    {

        Destroy(this.gameObject);

    }

    
}
