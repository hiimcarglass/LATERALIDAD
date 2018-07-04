using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class modelSettings : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {

    public GameObject viodModel;
    private bool isPressed = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
       
       if(isPressed)
        {
            if(EventSystem.current.currentSelectedGameObject.name == "rotateRight")
            {
                Debug.Log("dreta");
                viodModel.transform.Rotate(-Vector3.up * 3);
            }
            else if(EventSystem.current.currentSelectedGameObject.name == "rotateLeft")
            {
                Debug.Log("esketi");
                viodModel.transform.Rotate(Vector3.up * 3);
            }
        }


	}

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

   
    
       
}
