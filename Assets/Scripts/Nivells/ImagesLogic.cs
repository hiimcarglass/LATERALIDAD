using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagesLogic : MonoBehaviour {


    // QUEST FEEDBACK
    public GameObject FeedbackQuestPanel;
    Text _questText;
    Image _panelQuestImg;


    public GameObject ImagenCentral;
    public GameObject ImagenDerecha;
    public GameObject ImagenIzquierda;


    public Vector3 _centralImgInitPos;
    Quaternion _rightImgInitPos, _leftImgInitPos;


    Image _centralImg, _rightImg, _leftImg;
    Button _rightButton, _leftButton;

    RectTransform _centralRect, _rightRect, _leftRect;

    GameObject pj;
    ImageLoad _imgPjLoad;


    int _imagenAcargar;

    bool _girarImagenes = false;
    

    public enum ImagenCorrecta { Dret, Esq};
    ImagenCorrecta posCorrecta;

 


   


    // Use this for initialization
    void Start () {

       
        _rightButton = ImagenDerecha.GetComponent<Button>();
        _leftButton = ImagenIzquierda.GetComponent<Button>();

        _rightButton.interactable = false;
        _leftButton.interactable = false;

        _questText = FeedbackQuestPanel.GetComponentInChildren<Text>();
        _panelQuestImg = FeedbackQuestPanel.GetComponent<Image>();

        _centralImg = ImagenCentral.GetComponent<Image>();
        _rightImg = ImagenDerecha.GetComponent<Image>();
        _leftImg = ImagenIzquierda.GetComponent<Image>();

        _centralRect = ImagenCentral.GetComponent<RectTransform>();
        _rightRect = ImagenDerecha.GetComponent<RectTransform>();
        _leftRect = ImagenIzquierda.GetComponent<RectTransform>();

        _centralImg.canvasRenderer.SetAlpha(0.01f);
        _rightImg.canvasRenderer.SetAlpha(0.01f);
        _leftImg.canvasRenderer.SetAlpha(0.01f);

        _panelQuestImg.canvasRenderer.SetAlpha(0.01f);
        _questText.canvasRenderer.SetAlpha(0.01f);

        _imagenAcargar = 0;


        pj = GameObject.Find("Robot");
        _imgPjLoad = pj.GetComponent<ImageLoad>();


        _centralImgInitPos = _centralRect.localPosition;
        _rightImgInitPos = _rightRect.localRotation;
        _leftImgInitPos = _leftRect.localRotation;



    }
	
	// Update is called once per frame
	void Update () {

        


        if (_girarImagenes)
        {
            _centralRect.transform.localPosition = Vector2.Lerp(_centralRect.transform.localPosition, new Vector2(_centralRect.transform.localPosition.x, 12f), 1f * Time.deltaTime);
            _rightRect.transform.localRotation = Quaternion.Slerp(_rightRect.transform.localRotation, Quaternion.Euler(0,0,0), Time.deltaTime * 1f);
            _leftRect.transform.localRotation = Quaternion.Slerp(_leftRect.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 1f);


        }

      

    }

    public void RandomImage()
    {
        FadeImagenes();

        
        _girarImagenes = true;

        
        _imagenAcargar = Random.Range(0, _imgPjLoad._imgList.Count);

        VariablesSingleton._instance.SetControlesActivos(false);
       // pj.GetComponent<PlayerController>().Recolocame();
        ponImagen();
        //VariablesSingleton._instance.SetControlesActivos(true);

        
    }

    public void ponImagen()
    {
        if (_imagenAcargar % 2 == 0)
        {
            
            int randomCorrecta = 0;
            randomCorrecta = Random.Range(0, 2);
            if (randomCorrecta == 0)
            {
                _centralImg.sprite = (Sprite)_imgPjLoad._imgList[_imagenAcargar];
                _rightImg.GetComponent<Image>().sprite = (Sprite)_imgPjLoad._imgList[_imagenAcargar+1];
                _leftImg.GetComponent<Image>().sprite = (Sprite)_imgPjLoad._imgList[_imagenAcargar];

                _imgPjLoad._imgList.RemoveRange(_imagenAcargar, 2);
                posCorrecta = ImagenCorrecta.Esq;
            }
            else
            {
                _centralImg.sprite = (Sprite)_imgPjLoad._imgList[_imagenAcargar];
                _rightImg.sprite = (Sprite)_imgPjLoad._imgList[_imagenAcargar];
                _leftImg.sprite = (Sprite)_imgPjLoad._imgList[_imagenAcargar+1];

                _imgPjLoad._imgList.RemoveRange(_imagenAcargar, 2);
                posCorrecta = ImagenCorrecta.Dret;
            }
        }else
        {
            RandomImage();
        }

        

    }

   public ImagenCorrecta GetposCorrecta()
    {
        return posCorrecta;
    }


   


    public void FadeImagenes()
    {


        _rightButton.interactable = true;
        _leftButton.interactable = true;


        _centralImg.CrossFadeAlpha(1f, 2f, false);


        _rightImg.CrossFadeAlpha(1f, 2f, false);


        _leftImg.CrossFadeAlpha(1f, 2f, false);



        _panelQuestImg.CrossFadeAlpha(1f, 2f, false);
        _questText.CrossFadeAlpha(1f, 2.5f, false);
       
        
    }


    public void HideImgs()
    {
        _rightButton.interactable = false;
        _leftButton.interactable = false;

        _girarImagenes = false;

        _centralImg.CrossFadeAlpha(0.01f, 1f, false);


        _rightImg.CrossFadeAlpha(0.01f, 1f, false);


        _leftImg.CrossFadeAlpha(0.01f, 1f, false);

        _panelQuestImg.CrossFadeAlpha(0.01f, 1f, false);
        _questText.CrossFadeAlpha(0.01f, 0.5f, false);

        Invoke("reInitImgPos", 2f);

    }

   public void reInitImgPos()
    {
        _centralRect.transform.localPosition = _centralImgInitPos;
        _leftRect.transform.localRotation = _leftImgInitPos;
        _rightRect.transform.localRotation = _rightImgInitPos;
    }

}
