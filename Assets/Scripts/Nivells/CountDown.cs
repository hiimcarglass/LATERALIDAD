using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    float medidaRect;
    public Sprite[] Images;
    int _numeroImagen = 3;
    GameObject Pj;
    GameObject MovControl;

    // Use this for initialization
    void Start ()
    {
        VariablesSingleton._instance.SetControlesActivos(false); // desactivem controls

        MovControl = GameObject.Find("MovControl"); //busquem el empty de moviment
        Pj = GameObject.Find("Robot"); // busquem el robot

        medidaRect = 0; // mesura de la imatge a mostrar

        Images = Resources.LoadAll<Sprite>("Imatges/ImatgesAprocesar/CountDown"); // carreguem totes les imatges de numeros
        //this.gameObject.GetComponent<Image>().canvasRenderer.SetAlpha(0);
        this.gameObject.GetComponent<RectTransform>().transform.localScale = new Vector3(0, 0, 0); // el posicionem.
        this.GetComponent<Image>().sprite = (Sprite)Images[_numeroImagen]; // li assignem la primera imatge
    }
	
	// Update is called once per frame
	void Update ()
    {

        this.gameObject.GetComponent<RectTransform>().transform.localScale = new Vector3(medidaRect, medidaRect, 0); // per fer efecte creciente

        medidaRect += 2.5f * Time.deltaTime; // velocitat de creixament

        if (medidaRect > 2f) // si la mesura arriba a la maxima canviem el numero i reduim mesura de nou
        {
            medidaRect = 0;
            this.gameObject.GetComponent<RectTransform>().transform.localScale = new Vector3(medidaRect, medidaRect, 0);
            
            _numeroImagen--;

            if (_numeroImagen < 0)
            {
                Destroyme();
            }
            else
            {
                this.GetComponent<Image>().sprite = (Sprite)Images[_numeroImagen];
            }
        }
        
    }


    void Destroyme()
    {
        VariablesSingleton._instance.SetPausaGame(false); // treiem la pausa
        Pj.GetComponent<Animator>().SetBool("Empieza", true);
        MovControl.GetComponent<MovControl>().setPause();
        VariablesSingleton._instance.SetControlesActivos(true);
        Destroy(this.gameObject);
    }

  
}
