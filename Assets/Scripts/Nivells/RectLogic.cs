using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectLogic : MonoBehaviour {


    // CREADOR DE OBSTACLES i RECOLECTABLES

    public GameObject CrearCruilla;

    
   
    int RandomPref;

    int pos;

    public float rotz;

    // Use this for initialization
    void Start()
    {
        
        //INSTANCIA;

        pos = 15;

        RandomPref = Random.Range(0, 10);

        GameObject Obst1 = Instantiate(Resources.Load("Prefabs/" + VariablesSingleton._instance.GetTematicaNivell() + "/Obstacles/Obstacle" + RandomPref), new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;


        RandomPref = Random.Range(0, 10);
        
        GameObject Obst2 = Instantiate(Resources.Load("Prefabs/" + VariablesSingleton._instance.GetTematicaNivell() + "/Obstacles/Obstacle" + RandomPref), new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;


        RandomPref = Random.Range(0, 10);
        
        GameObject Obst3 = Instantiate(Resources.Load("Prefabs/" + VariablesSingleton._instance.GetTematicaNivell() + "/Obstacles/Obstacle" + RandomPref), new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;


        RandomPref = Random.Range(0, 10);
        
        GameObject Obst4 = Instantiate(Resources.Load("Prefabs/" + VariablesSingleton._instance.GetTematicaNivell() + "/Obstacles/Obstacle" + RandomPref), new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;


        RandomPref = Random.Range(0, 10);

        GameObject Obst5 = Instantiate(Resources.Load("Prefabs/" + VariablesSingleton._instance.GetTematicaNivell() + "/Obstacles/Obstacle" + RandomPref), new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;


        //POSICIONAMIENTO



        rotz = this.transform.eulerAngles.y -90; // ESTO DEVUELVE LA ROTACION EN LA QUE ESTA MIRANDO LA CARRETERA (FUMADA DE UNITY QUE LO TRATA CON ANGULOS RAROS)

        Obst1.transform.SetParent(this.transform); // lo hacemos hijo
        Obst1.transform.localPosition = new Vector3(0, 0, 0); // recolocamos 
        Obst1.transform.Rotate(0, rotz, 0);
        Obst1.transform.Translate(0, 0, -pos);
        pos += 30;


        Obst2.transform.SetParent(this.transform);
        Obst2.transform.localPosition = new Vector3(0, 0, 0);
        Obst2.transform.rotation = Quaternion.Euler(0, rotz, 0);
        Obst2.transform.Translate(0, 0, -pos);
        pos += 30;


        Obst3.transform.SetParent(this.transform);
        Obst3.transform.localPosition = new Vector3(0, 0, 0);
        Obst3.transform.rotation = Quaternion.Euler(0, rotz, 0);
        Obst3.transform.Translate(0, 0, -pos);
        pos += 30;


        Obst4.transform.SetParent(this.transform);
        Obst4.transform.localPosition = new Vector3(0, 0, 0);
        Obst4.transform.rotation = Quaternion.Euler(0, rotz, 0);
        Obst4.transform.Translate(0, 0, -pos);
        pos += 30;


        Obst5.transform.SetParent(this.transform);
        Obst5.transform.localPosition = new Vector3(0, 0, 0);
        Obst5.transform.rotation = Quaternion.Euler(0, rotz, 0);
        Obst5.transform.Translate(0, 0, -pos);




        //GameObject ProximaCruilla = Instantiate(Resources.Load("Prefabs/" + VariablesSingleton._instance.GetTematicaNivell() + "/Cruilles"), new Vector3(0, 0, 0), Quaternion.Euler(-90, 0, 0)) as GameObject;

        //ProximaCruilla.transform.position = CrearCruilla.transform.position;

        //ProximaCruilla.transform.Rotate(0, 0, 180);
        //this.transform.SetParent(ProximaCruilla.transform);



    }
	
	// Update is called once per frame
	void Update ()
    {

        

    }
}