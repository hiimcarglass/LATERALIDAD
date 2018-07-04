
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedBackCruces : MonoBehaviour {


    // ESTE SCRIPT SOLO SIRVE PARA LA CARGA DE IMAGENES DESTINADA A CADA NIVEL

    public Sprite[] Images;

    Sprite Tick;
    Sprite Cross;

    Image _img;


    public bool _activaImg;

    // Use this for initialization
    void Start ()
    {
        
        Images = Resources.LoadAll<Sprite>("Imatges/ImatgesAprocesar/FeedBack");

        _img = this.GetComponent<Image>();

        _img.canvasRenderer.SetAlpha(0.01f);

        Tick = Images[1];
        Cross = Images[0];
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(this.GetComponent<Image>().canvasRenderer.GetAlpha());
        
        
		
	}


    public void setImage(bool correcte)
    {
        if (correcte)
        {
            this.GetComponent<Image>().sprite = Tick; // posem la imatge del tick
            _activaImg = true;
            FadeImagenes();
           
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = Cross; // posem la imatge de la creu
            _activaImg = true;
            FadeImagenes();
           
        }
        
    }


    public void FadeImagenes() // mostrem la imatge progresivament
    {
        if (_activaImg)
        {
            //this.GetComponent<Image>().canvasRenderer.SetAlpha(0.01f);
            _img.CrossFadeAlpha(1.0f, 1f, false);
            //this.GetComponent<Image>().canvasRenderer.SetAlpha(255);
            Invoke("AmagaImages", 2f);
        }
    }

    public void AmagaImages() // amaguem la imatge progresivament
    {
        //Debug.Log("HE ENTRADO");
        //this.GetComponent<Image>().canvasRenderer.SetAlpha(255f);
        
       _img.CrossFadeAlpha(0.01f, 0.3f, false);
        //this.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
    }
}
