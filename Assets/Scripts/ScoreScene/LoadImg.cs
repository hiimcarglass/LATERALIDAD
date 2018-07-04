using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadImg : MonoBehaviour {

    public AudioSource starSound;

    public List<Sprite> ImatgesCorrectes;
    public List<Sprite> ImatgesIncorrectes;

    public GameObject PanelCorrecto;
    public GameObject PanelIncorrecto;

    public GameObject starBronze;
    public GameObject starSilver;
    public GameObject starGold;

    public Button exitButton;

    public Text coinPunt;

    public float timer;



    // Use this for initialization
    void Start()
    {



        ImatgesCorrectes = new List<Sprite>();
        ImatgesIncorrectes = new List<Sprite>();


        ImatgesCorrectes = VariablesSingleton._instance.getImageCorrectes();
        ImatgesIncorrectes = VariablesSingleton._instance.getImagesIncorrectes();

        imageInstance();

        VariablesSingleton._instance.CleanList(VariablesSingleton._instance.getImageCorrectes());
        VariablesSingleton._instance.CleanList(VariablesSingleton._instance.getImagesIncorrectes());

        Button btn_exit = exitButton.GetComponent<Button>();
        btn_exit.onClick.AddListener(returnToSelectLvl);

        coinPunt.text = PlayerController.Coin.ToString();



        StartCoroutine(Time());

       
    }


   



    // Update is called once per frame
    void Update() { 

    }

    

    void imageInstance()
    {

        int x = 75;
        int y = 50;
        int _xPos = -3;
        
        

        for (int i = 0; i < ImatgesCorrectes.Count; i++)
        {
            GameObject Imagen = Instantiate(Resources.Load("Prefabs/ScoreScene/Image"), new Vector2(0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;

            Imagen.transform.SetParent(PanelCorrecto.transform, false);


            Imagen.transform.localPosition = new Vector2(x * _xPos, y);

         

            Imagen.GetComponent<Image>().sprite = ImatgesCorrectes[i];

            _xPos += 2;

            if (_xPos > 3)
            {
                _xPos = -3;
                y = -140;
            }
            
        }


        x = 75;
        y = 50;
        _xPos = -3;


        for (int i = 0; i < ImatgesIncorrectes.Count; i++)
        {
            GameObject Imagen = Instantiate(Resources.Load("Prefabs/ScoreScene/Image"), new Vector2(0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;

            Imagen.transform.SetParent(PanelIncorrecto.transform, false);


            Imagen.transform.localPosition = new Vector2(x * _xPos, y);

            Imagen.GetComponent<Image>().sprite = ImatgesIncorrectes[i];


            _xPos += 2;

            if (_xPos > 3)
            {
                _xPos = -3;
                y += -140;
            }

        }

    }


    IEnumerator Time()
    {
        if (PlayerController.numImages >= 4 && PlayerController.Coin >= 100)
        {
            yield return new WaitForSeconds(timer);
            starSound.Play();
            starBronze.SetActive(true);
            yield return new WaitForSeconds(timer);
            starSound.Play();
            starSilver.SetActive(true);
            yield return new WaitForSeconds(timer);
            starSound.Play();
            starGold.SetActive(true);
        }

        else if (PlayerController.numImages == 3 || PlayerController.numImages == 4)
        {
            yield return new WaitForSeconds(timer);
            starSound.Play();
            starBronze.SetActive(true);
            yield return new WaitForSeconds(timer);
            starSound.Play();
            starSilver.SetActive(true);
            starGold.SetActive(false);


        }

        else if (PlayerController.numImages == 2)
        {
            yield return new WaitForSeconds(timer);
            starSound.Play();
            starBronze.SetActive(true);
            starSilver.SetActive(false);
            starGold.SetActive(false);
        }

        else if (PlayerController.numImages <= 1)
        {

            starBronze.SetActive(false);
            starSilver.SetActive(false);
            starGold.SetActive(false);
        }
    }



    public void returnToSelectLvl()
    {
        SceneManager.LoadScene("LvlsMap");
    }
  
}

