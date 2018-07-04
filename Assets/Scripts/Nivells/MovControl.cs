using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovControl : MonoBehaviour {

    public GameObject _pj;

    PlayerController _pjControl;



    ////// Giro


    int TiempoGiro = 0;

    public float _speed;
    

    // Use this for initialization
    void Start()
    {
        _pjControl = _pj.GetComponent<PlayerController>();
        _speed = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(0, 0, _speed * Time.deltaTime); // movimiento


        if (TiempoGiro > 44f)
        {
            _pjControl.setActivaGiro(-1);
            TiempoGiro = 0;
            _speed = 20f;
        }

        if (_pjControl.getActivaGiro() == 0) // giros
        {
            _speed = 0;
            transform.RotateAround(_pjControl.PivotPerGirarDreta, new Vector3(0, 10f * Time.deltaTime, 0), 2f);
            TiempoGiro++;
        }
        if (_pjControl.getActivaGiro() == 1)
        {
            _speed = 0;
            transform.RotateAround(_pjControl.PivotPerGirarEsquerra, new Vector3(0, 10f * Time.deltaTime, 0), -2);
            TiempoGiro++;
        }

       
    }


    public void setPause() // pausar el juego
    {
        if (VariablesSingleton._instance.GetPausaGame())
        {
            _speed = 0f;
        }
        else
        {
            _speed = 20f;
           
        }
        
    }


    public void setSpeed(float speed) // modificador de velocidad
    {
        _speed = speed;
    }

   
}
