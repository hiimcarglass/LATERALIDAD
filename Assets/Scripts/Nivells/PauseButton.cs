using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour {

    public GameObject options;
    public Button pauseButton;
    public Button returnButton;
    public Button exitButton;
    public Button sagaButton;

    public bool isShowing = false;
    public bool isPaused = false;
    
    

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Button opt_btn = pauseButton.GetComponent<Button>();
        opt_btn.onClick.AddListener(activeOptions);

        Button ret_btn = returnButton.GetComponent<Button>();
        ret_btn.onClick.AddListener(backToGame);

        Button saga_btn = sagaButton.GetComponent<Button>();
        saga_btn.onClick.AddListener(backToSaga);

        Button exit_btn = exitButton.GetComponent<Button>();
        exit_btn.onClick.AddListener(backToMenu);
        
        

        if (!isShowing)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                options.SetActive(true);
                isShowing = true;


            }
        }

        else if (isShowing)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                options.SetActive(false);
                isShowing = false;
            }
        }
     
      
    }

    public void activeOptions()
    {
        if (!isShowing)
        {
            options.SetActive(true);
            isShowing = true;

            if(Time.timeScale == 1 && isPaused == false)
            {
                 Time.timeScale = 0;
                 isPaused = true;
            }

        } 
    }

    public void backToGame()
    {
        if (isShowing)
        {
            options.SetActive(false);
            isShowing = false;

            if(Time.timeScale == 0 && isPaused == true)
            {
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }

    public void backToSaga()
    {
        SceneManager.LoadScene("LvlsMap");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Login");
    }

}


