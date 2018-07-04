using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shopOptions : MonoBehaviour {

    public GameObject headPanel;
    public GameObject chestPanel;
    public GameObject armsPanel;
    public GameObject legsPanel;
    public GameObject feetPanel;
    public GameObject viodModel;
    public GameObject welcomePanel;

    public Button headButton;
    public Button chestButton;
    public Button armsButton;
    public Button legsButton;
    public Button feetButton;

    public Button exitShop;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        Button btn_head = headButton.GetComponent<Button>();
        btn_head.onClick.AddListener(headMenu);

        Button btn_chest = chestButton.GetComponent<Button>();
        btn_chest.onClick.AddListener(chestMenu);

        Button btn_arms = armsButton.GetComponent<Button>();
        btn_arms.onClick.AddListener(armsMenu);

        Button btn_legs = legsButton.GetComponent<Button>();
        btn_legs.onClick.AddListener(legsMenu);

        Button btn_feet = feetButton.GetComponent<Button>();
        btn_feet.onClick.AddListener(feetMenu);

        Button btn_exit = exitShop.GetComponent<Button>();
        btn_exit.onClick.AddListener(backtoSaga);
        
    }

    public void welcomeShop()
    {

    }

    public void headMenu()
    {
        headPanel.SetActive(true);
        chestPanel.SetActive(false);
        armsPanel.SetActive(false);
        legsPanel.SetActive(false);
        feetPanel.SetActive(false);
        welcomePanel.SetActive(false);
    }

    public void chestMenu()
    {
        headPanel.SetActive(false);
        chestPanel.SetActive(true);
        armsPanel.SetActive(false);
        legsPanel.SetActive(false);
        feetPanel.SetActive(false);
        welcomePanel.SetActive(false);
    }

    public void armsMenu()
    {
        headPanel.SetActive(false);
        chestPanel.SetActive(false);
        armsPanel.SetActive(true);
        legsPanel.SetActive(false);
        feetPanel.SetActive(false);
        welcomePanel.SetActive(false);
    }

    public void legsMenu()
    {
        headPanel.SetActive(false);
        chestPanel.SetActive(false);
        armsPanel.SetActive(false);
        legsPanel.SetActive(true);
        feetPanel.SetActive(false);
        welcomePanel.SetActive(false);
    }

    public void feetMenu()
    {
        headPanel.SetActive(false);
        chestPanel.SetActive(false);
        armsPanel.SetActive(false);
        legsPanel.SetActive(false);
        feetPanel.SetActive(true);
        welcomePanel.SetActive(false);
    }

    public void backtoSaga()
    {
        SceneManager.LoadScene("LvlsMap");
    }
       
}
