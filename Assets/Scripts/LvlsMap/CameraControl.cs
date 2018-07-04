using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour {


    public GameObject Pj;

	// Use this for initialization
	void Start () {

        Resources.UnloadUnusedAssets(); // descarrega el que no necessiti en aquesta escena
        System.GC.Collect(); // treu la merda.

    }
	
	// Update is called once per frame
	void Update ()
    {

        //CameraMov.transform.Translate(1, 0, 0);

        this.transform.LookAt(Pj.transform);

        if (Input.GetKey(KeyCode.S))
        {
            SceneManager.LoadScene("NivellCiutat");
        }
		
	}
}
