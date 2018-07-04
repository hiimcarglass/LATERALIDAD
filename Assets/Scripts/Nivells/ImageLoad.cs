using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoad : MonoBehaviour {

    
    public Sprite[] Images;

    public List<Sprite> _imgList;

    
    
   
    

	// Use this for initialization
	void Start ()
    {
        _imgList = new List<Sprite>();

        Images = Resources.LoadAll<Sprite>("Imatges/ImatgesAprocesar/"+VariablesSingleton._instance.GetTematicaNivell()+"/"+VariablesSingleton._instance.GetDificultat());
        
        for (int i =0; i < Images.Length; i++)
        {
            _imgList.Add(Images[i]);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
