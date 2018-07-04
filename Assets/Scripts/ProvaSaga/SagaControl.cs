using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SagaControl : MonoBehaviour {


    public bool _down, _up, mepuedoMOVER;

    float _acceleration;

    bool _softMove;

    enum Direccion { up,down};

    Direccion _direccion;

    public GameObject Saga,InicioSaga,InicioPantalla;
    Transform _sagaControl;

    bool _isFinish;

    float _speed;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position

    private Vector3 mp;   //Moved touch position


    private float dragDistance;  //minimum distance for a swipe to be registered

    // Use this for initialization
    void Start ()
    {

        mepuedoMOVER = true;
        _softMove = false;
        _up = true;
        _down = true;

        _speed = 150f;
        _sagaControl = Saga.GetComponent<RectTransform>();
        dragDistance = Screen.height * 10 / 100; //dragDistance is 15% height of the screen

    }
	
	// Update is called once per frame
	void Update ()
    {


        //if (_isFinish)
        //{

        //    Saga.transform.localPosition = Vector3.Lerp(Saga.transform.localPosition, new Vector3 (0, 0, Mathf.Abs(lp.y - fp.y) * Time.deltaTime);

        //}

       // Debug.Log(InicioPantalla.transform.localPosition.z);
        Debug.Log(InicioSaga.transform.position.z);


        if (InicioSaga.transform.position.z > 75.6f)
        {
            _down = false;
            

            _sagaControl.localPosition = new Vector3(_sagaControl.localPosition.x, -78.9f, 4.9f);
            _softMove = false;
        }
        else
        {
            _down = true;
        }

        if (Input.GetMouseButton(0))
        {
           
        }


        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;

                _acceleration = 0;

            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                //fp = touch.position;
                _acceleration = 0;
            }

            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {

                if (InicioSaga.transform.position.z > 75.6f)
                {
                    _down = false;


                    _sagaControl.localPosition = new Vector3(_sagaControl.localPosition.x, -78.9f, 4.9f);
                }
                mp = lp;

                lp = touch.position;

                if (mp.y < lp.y && _direccion == Direccion.up)
                {
                    Debug.Log("Entra yendo arriba");
                    _direccion = Direccion.down;
                    fp = mp;
                }
                else if (mp.y > lp.y && _direccion == Direccion.down)
                {
                    Debug.Log("Entra yendo abajo");
                    _direccion = Direccion.up;
                    fp = mp;
                }


                //Debug.Log(Mathf.Abs(lp.y - fp.y));

                if (lp.y > fp.y)  //if the movement was up
                {
                    //up swipe
                    //Debug.Log("up swipe");

                    _direccion = Direccion.down;

                    if (_down)
                    {
                        Saga.transform.Translate(0, 0, -_speed * Time.deltaTime);
                        mepuedoMOVER = true;
                    }
                    else
                    {
                        mepuedoMOVER = false;
                    }



                }
                if (lp.y < fp.y)  //if the movement was up
                {
                    //up swipe
                    //Debug.Log("down swipe");

                    _direccion = Direccion.up;

                    if (_up)
                    {
                        Saga.transform.Translate(0, 0, +_speed * Time.deltaTime);
                    }


                }


            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {

                if (mepuedoMOVER)
                {
                    lp = touch.position;

                    _acceleration = Mathf.Abs(lp.y - fp.y);

                    _softMove = true;
                }
            }
        }
        

        if (_softMove)
        {

           
            _acceleration -= 2.5f;

            if (_direccion == Direccion.up)
            {
                Saga.transform.Translate(0, 0, +_speed * Time.deltaTime);
            }
            else if (_direccion == Direccion.down)
            {
                Saga.transform.Translate(0, 0, -_speed * Time.deltaTime);
            }

            if (_acceleration <= 0)
            {
                _softMove = false;
            }



        }


    }
}
