using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionDeLvls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    // cosas antiguas
    public GameObject imgCarregaFull;
    public Transform BarraEspera;
    public Transform TextProgreso;
    public Transform TextCargando;
    
    private float currentAmount;
    
    private float speed = 0;
    private AsyncOperation asynV;



    public void activaImatge()
    {
        imgCarregaFull.SetActive(true);
        StartCoroutine(LoadLevelMapa());
    }

    

        IEnumerator LoadLevelMapa()
    {
        

        switch (VariablesSingleton._instance.GetNivellActual())
        {
            //Escena Nivell 1
            case 1:

                VariablesSingleton._instance.SetDificultat("Facil");
                asynV = SceneManager.LoadSceneAsync("NivellCiutat");
                VariablesSingleton._instance.CalculDeGirs();

                while (!asynV.isDone)
                {
                    currentAmount = asynV.progress * speed;
                    TextProgreso.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
                    TextCargando.gameObject.SetActive(true);
                    yield return null;
                    BarraEspera.GetComponent<Image>().fillAmount = currentAmount / 100;
                    if (currentAmount >= 98)
                    {
                        TextProgreso.GetComponent<Text>().text = "100%";
                        TextCargando.GetComponent<Text>().text = "GO!";
                    }
                }

                imgCarregaFull.SetActive(false);
                Debug.Log("tocado lvl 1");

                break;

            //Escena Nivell 2
            case 2:

                VariablesSingleton._instance.SetDificultat("Mig");
                asynV = SceneManager.LoadSceneAsync("NivellCiutat");

                while (!asynV.isDone)
                {
                    currentAmount = asynV.progress * speed;
                    TextProgreso.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
                    TextCargando.gameObject.SetActive(true);
                    yield return null;
                    BarraEspera.GetComponent<Image>().fillAmount = currentAmount / 100;
                    if (currentAmount >= 98)
                    {
                        TextProgreso.GetComponent<Text>().text = "100%";
                        TextCargando.GetComponent<Text>().text = "GO!";
                    }
                }

                imgCarregaFull.SetActive(false);

                break;

            //Escena Nivell 3
            case 3:

                VariablesSingleton._instance.SetDificultat("Dificil");
                asynV = SceneManager.LoadSceneAsync("NivellCiutat");

                while (!asynV.isDone)
                {
                    currentAmount = asynV.progress * speed;
                    TextProgreso.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
                    TextCargando.gameObject.SetActive(true);
                    yield return null;
                    BarraEspera.GetComponent<Image>().fillAmount = currentAmount / 100;
                    if (currentAmount >= 98)
                    {
                        TextProgreso.GetComponent<Text>().text = "100%";
                        TextCargando.GetComponent<Text>().text = "GO!";
                    }
                }

                imgCarregaFull.SetActive(false);

                break;
        }
    }
}
