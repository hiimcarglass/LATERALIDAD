using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {




    public static int numImages = 0;

    public AudioClip coinAudio;

    //Salto
    bool _isJump, _descent;


    // Imagenes
    public GameObject Canvas;


    bool _imgElection; // si se puede seleccionar la imagen a elegir

    ImagesLogic _imgLogic; // referencia a script
    Image _img; // referencia a imagen



    // ////////////////// FEEDBACK

    public Image FeedBack; // imagen de correcto/incorrecto

    FeedBackCruces _feedbackControl; // referencia a script

    // Puntuacion

    public GameObject Puntos;
    Text _pointsCount; // escriure els punts per pantalla

    public static int Coin; // Monedas



    // // coses per pintar/despitar VIOD i fer "animacio" de mal
    private SkinnedMeshRenderer[] arrayRenderViod;
    private bool pintant;
   
    // //////////////

    // Posicion del player en el camino
    enum Posicion { dreta, centre, esquerra };
    Posicion _lastPos;
    Posicion _proximPos;
    Posicion _pos;

    public GameObject MovControl; // Empty de movimiento

    
    GameObject Recorrido; // Proximo Prefab a instanciar
    
    // FeedBack de so /// FALTA IMPLEMENTAR i buscas nous sons 
    AudioSource sonido;
    AudioClip CorrectAnswer; // el so correcte es pasable
    AudioClip WrongAnswer; // el so incorrecte es horrible

    // Condicionales para girar

    public Vector3 PivotPerGirarDreta; // punts per girar
    public Vector3 PivotPerGirarEsquerra;

    public Vector3 ProximaInstanciaDreta; // punts per crear el següent recorregut
    public Vector3 ProximaInstanciaEsquerra;

    int _activaGiro = -1; // gir en cas de quedar-se al centre i les seves funcions partinents estan a sota


    public void setActivaGiro(int estado)
    {
        _activaGiro = estado;
    }
    public int getActivaGiro()
    {
        return _activaGiro;
    }
    //int _tempsDeGir =0;


    // LOGICA DE ACIERTOS

    bool posicioCorrecta = false; // si el player esta en la posicion correcta 
    int GirarMal=0; // girar mal a posta
    int _girsFets; // giros hechos por partida

    

    
    


    //Moviment

    public GameObject _target, _lastTarget; // objectius a anar

    public int _direccio; // Saber si se dirige a izquierda o derecha

    int _deDondeVengo = 0; // Saber de donde procedia antes de moverse

    public GameObject _centerPoint, _rightPoint, _leftPoint, _jumpPoint; // punts de referencia per moviment
    
    public bool _movEsq, _movDret, _meMuevo; // condicionals de moviment

    float _speed; // velocidad del player


    public AudioSource coinSound;

    bool SiDerecha; // control de tap en caso de querer implementarlo de nuevo
    bool SiIzquierda;

    //double halfScreenW;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistanceY;    //minimum distance for a swipe to be registered
    private float dragDistanceX;    // minimum distance for a swipe registered
    ////////

    float _anguloParaCruces; // angle per col·locar la següent recorregut
    // veocidad de control
   

   



   
    

    // Use this for initialization
    void Start () {

        _speed = 6f;

        _imgElection = true;

        _anguloParaCruces = 90;

        _imgLogic = Canvas.GetComponentInChildren<ImagesLogic>();

        _img = _imgLogic.ImagenCentral.GetComponent<Image>();

        _feedbackControl = FeedBack.GetComponent<FeedBackCruces>();

        _pointsCount = Puntos.GetComponent<Text>();

        VariablesSingleton._instance.SetPausaGame(true);
        CorrectAnswer = Resources.Load("Sounds/CorrectAnswer") as AudioClip;
        WrongAnswer = Resources.Load("Sounds/WrongAnswer") as AudioClip;
        _girsFets = 0;
        Coin = 0;
        

        sonido = GetComponent<AudioSource>();

        VariablesSingleton._instance.SetControlesActivos(false);
        VariablesSingleton._instance.SetEnablePausa(true);
       
        _pos = Posicion.centre;
        _lastPos = Posicion.centre;
        _proximPos = Posicion.centre;

        _direccio = 0;

        _target = _centerPoint;
        _lastTarget = _centerPoint;

        _meMuevo = false;
        _movEsq = false;
        _movDret = false;

        _isJump = false;
        _descent = false;

       

        //halfScreenW = Screen.width / 2.0;

        dragDistanceY = Screen.height * 10 / 100; //drag Distance is 10% height of the screen
        dragDistanceX = Screen.width * 5/ 100;   // drag distance is 5% width of the screen

        arrayRenderViod = this.GetComponentsInChildren<SkinnedMeshRenderer>();

        Resources.UnloadUnusedAssets(); // descarrega(no carrega) el que no necessiti en aquesta escena
        System.GC.Collect(); // treu la merda.

    }

    // Update is called once per frame
    void Update()
    {

        

        if (_isJump)
        {

            

            _target = _jumpPoint;

            _speed = 7.5f;

            this.GetComponent<Animator>().SetBool("Jump", false);

            if(this.transform.localPosition.y > _target.transform.localPosition.y - 0.5f)
            {
                transform.position = _target.transform.position;
                
                _descent = true;
                
                
            }

        }

        if (_descent)
        {
            Debug.Log("He Entrado a descent");
            _isJump = false;
            _target = _lastTarget;

            if (this.transform.localPosition.y < _target.transform.localPosition.y + 0.5f)
            {
                transform.position = _target.transform.position;
                
                _descent = false;
                _speed = 5f;
                VariablesSingleton._instance.SetControlesActivos(true);
            }
        }


        
        if(_target != _jumpPoint)
        {
            _lastTarget = _target;
        }

       

        if (VariablesSingleton._instance.GetControlesActivos())
        {

            if (Input.GetKeyDown(KeyCode.S)) // si ponemos espacio tendremos problemas porque unity interpreta que espacio tambien es click i vovleras a pulsar la imagen que has pulsado la ultima vez con el raton
            {
                //Debug.Log("LAST POS: " + _lastPos);
   
                //Debug.Log("PRIXIUMA POS: " + _proximPos);

                //Debug.Log(VariablesSingleton._instance.GetUnicaEleccio());

                //FeedBack.GetComponent<FeedBackCruces>().AmagaImages();
                //Debug.Log("Controles Activos: " + VariablesSingleton._instance.GetControlesActivos());
                //Debug.Log("Unica eleccio: " + VariablesSingleton._instance.GetUnicaEleccio());

                salta();
  
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                _movEsq = true;
                _movDret = false;

                
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                _movDret = true;
                _movEsq = false;
               
            }
        }
        if (_movDret)
        {
            if (_lastPos == Posicion.centre)
            {
                _direccio = 1;
            }
            if (_lastPos == Posicion.esquerra)
            {
                _direccio = 0;
            }
            if (_lastPos == Posicion.centre && _proximPos == Posicion.esquerra)
            {
                _direccio = 0;
            }
            if (_lastPos == Posicion.dreta && _proximPos == Posicion.centre)
            {

                _direccio = 1;
            }
            if (_lastPos == Posicion.esquerra && _proximPos == Posicion.centre)
            {
                _direccio = 2;
            }
            if (_lastPos == Posicion.dreta && _proximPos == Posicion.esquerra)
            {
                _direccio = 0;
            }

            switch (_direccio)
            {
                case 0:
                    _proximPos = Posicion.centre;
                    _target = _centerPoint;
                    

                    break;
                case 1:
                    _proximPos = Posicion.dreta;
                    _target = _rightPoint;
                    

                    break;

                case 2:
                    _proximPos = Posicion.dreta;
                    _target = _rightPoint;
                    

                    break;

                default:
                    break;
            }

            _movDret = false;
            _meMuevo = true;
          
        }

        if (_movEsq)
        {
            if (_lastPos == Posicion.centre)
            {
                _direccio = -1;
            }
            if (_lastPos == Posicion.dreta)
            {
                _direccio = 0;
            }
            if (_lastPos == Posicion.centre && _proximPos == Posicion.dreta)
            {
                _direccio = 0;
            }
            if (_lastPos == Posicion.esquerra && _proximPos == Posicion.centre)
            {
                _direccio = -1;
            }
            if (_lastPos == Posicion.dreta && _proximPos == Posicion.centre)
            {
                _direccio = 2;
            }
            if (_lastPos == Posicion.esquerra && _proximPos == Posicion.dreta)
            {
                _direccio = 0;
            }

            Debug.Log(_direccio);

            switch (_direccio)
            {
                case 0:
                    _proximPos = Posicion.centre;
                    _target = _centerPoint;
                    

                    break;
                case -1:
                    _proximPos = Posicion.esquerra;
                    _target = _leftPoint;
                    

                    break;
                case 2:
                    _proximPos = Posicion.esquerra;
                    _target = _leftPoint;
                    

                    break;
                default:
                    break;
            }

            _movEsq = false;
            _meMuevo = true;

            


        }



        transform.localPosition = Vector3.Lerp(transform.localPosition, _target.transform.localPosition, _speed * Time.deltaTime); // nos movemos!!!!!!!!!!!!!
        _jumpPoint.transform.localPosition = new Vector3(_target.transform.localPosition.x, _jumpPoint.transform.localPosition.y, _jumpPoint.transform.localPosition.z);
        

        if (_meMuevo)
        {



            switch (_proximPos)
            {
                case Posicion.centre:

                    if (_lastPos == Posicion.esquerra)
                    {

                        if (transform.localPosition.x < 0)
                        {
                            _deDondeVengo = -1; // esquerra
                        }
                        else if (transform.localPosition.x > 0)
                        {
                            _deDondeVengo = 1; // dreta
                        }
                        if (_deDondeVengo == 1)
                        {
                            if (transform.localPosition.x <= _target.transform.localPosition.x + 0.2f)
                            {
                                _proximPos = Posicion.centre;
                                transform.position = _target.transform.position;
                                
                                _movDret = false;
                                _movEsq = false;
                                _meMuevo = false;

                                _lastPos = _proximPos;
                                _pos = _lastPos;
                                _lastTarget = _target;

                            }

                        }
                        if (_deDondeVengo == -1)
                        {
                            if (transform.localPosition.x >= _target.transform.localPosition.x - 0.2f)
                            {
                                _proximPos = Posicion.centre;
                                transform.position = _target.transform.position;
                                
                                _movDret = false;
                                _movEsq = false;
                                _meMuevo = false;

                                _lastPos = _proximPos;
                                _pos = _lastPos;
                                _lastTarget = _target;


                            }
                        }
                    }
                    if (_lastPos == Posicion.centre)
                    {


                        if (transform.localPosition.x < 0)
                        {
                            _deDondeVengo = -1; // esquerra
                        }
                        else if (transform.localPosition.x > 0)
                        {
                            _deDondeVengo = 1; // dreta
                        }
                        if (_deDondeVengo == 1)
                        {
                            if (transform.localPosition.x <= _target.transform.localPosition.x + 0.2f)
                            {
                                _proximPos = Posicion.centre;
                                transform.position = _target.transform.position;
                                
                                _movDret = false;
                                _movEsq = false;
                                _meMuevo = false;

                                _lastPos = _proximPos;
                                _pos = _lastPos;
                                _lastTarget = _target;

                            }

                        }
                        if (_deDondeVengo == -1)
                        {
                            if (transform.localPosition.x >= _target.transform.localPosition.x - 0.2f)
                            {
                                _proximPos = Posicion.centre;
                                transform.position = _target.transform.position;
                                
                                _movDret = false;
                                _movEsq = false;
                                _meMuevo = false;

                                _lastPos = _proximPos;
                                _pos = _lastPos;
                                _lastTarget = _target;


                            }
                        }

                    }

                    if (_lastPos == Posicion.dreta)
                    {
                       

                        if (transform.localPosition.x < 0)
                        {
                            _deDondeVengo = -1; // esquerra
                        }
                        else if (transform.localPosition.x > 0)
                        {
                            _deDondeVengo = 1; // dreta
                        }
                        if (_deDondeVengo == 1)
                        {
                            if (transform.localPosition.x <= _target.transform.localPosition.x + 0.2f)
                            {
                                _proximPos = Posicion.centre;
                                transform.position = _target.transform.position;
                                
                                _movDret = false;
                                _movEsq = false;
                                _meMuevo = false;

                                _lastPos = _proximPos;
                                _pos = _lastPos;
                                

                            }

                        }
                        if (_deDondeVengo == -1)
                        {
                            if (transform.localPosition.x >= _target.transform.localPosition.x - 0.2f)
                            {
                                _proximPos = Posicion.centre;
                                transform.position = _target.transform.position;
                                
                                _movDret = false;
                                _movEsq = false;
                                _meMuevo = false;

                                _lastPos = _proximPos;
                                _pos = _lastPos;
                               


                            }
                        }
                    }
                    break;

                case Posicion.dreta:

                    

                    if (_lastPos == Posicion.dreta)
                    {

                        if (transform.localPosition.x >= _target.transform.localPosition.x - 0.2f)
                        {
                            _proximPos = Posicion.dreta;
                            transform.position = _target.transform.position;
                            
                            _meMuevo = false;
                            _movDret = false;
                            _movEsq = false;
                            _lastPos = _proximPos;
                            _pos = _lastPos;
                            
                        }
                    }
                    if (_lastPos == Posicion.centre)
                    {

                        if (this.transform.localPosition.x >= _target.transform.localPosition.x - 0.2f)
                        {
                            _proximPos = Posicion.dreta;
                            transform.position = _target.transform.position;
                            
                            _meMuevo = false;
                            _movDret = false;
                            _movEsq = false;
                            _lastPos = _proximPos;
                            _pos = _lastPos;
                            
                        }
                    }
                    if (_lastPos == Posicion.esquerra)
                    {

                        if (this.transform.localPosition.x >= _target.transform.localPosition.x - 0.2f)
                        {
                            _proximPos = Posicion.dreta;
                            transform.position = _target.transform.position;
                            
                            _meMuevo = false;
                            _movDret = false;

                             _movEsq = false;
                            _lastPos = _proximPos;
                            _pos = _lastPos;
                            
                        }
                    }

                    break;

                case Posicion.esquerra:
                    if (_lastPos == Posicion.esquerra)
                    {

                        if (transform.localPosition.x <= _target.transform.localPosition.x + 0.2f)
                        {
                            _proximPos = Posicion.esquerra;
                            transform.position = _target.transform.position;
                            
                            _meMuevo = false;
                            _movDret = false;
                            _movEsq = false;
                            _lastPos = _proximPos;
                            _pos = _lastPos;
                            
                        }
                    }
                    if (_lastPos == Posicion.centre)
                    {

                        if (transform.localPosition.x <= _target.transform.localPosition.x + 0.2f)
                        {
                            _proximPos = Posicion.esquerra;
                            transform.position = _target.transform.position;
                           
                            _meMuevo = false;
                            _movDret = false;
                            _movEsq = false;
                            _lastPos = _proximPos;
                            _pos = _lastPos;
                            
                        }
                    }
                    if (_lastPos == Posicion.dreta)
                    {

                        if (transform.localPosition.x <= _target.transform.localPosition.x + 0.2f)
                        {
                            _proximPos = Posicion.esquerra;
                            transform.position = _target.transform.position;
                            
                            _meMuevo = false;
                            _movDret = false;
                            _movEsq = false;
                            _lastPos = _proximPos;
                            _pos = _lastPos;
                            
                        }
                    }

                    break;
            }
        }






        /////////////////////////////////////////




        if (_girsFets >= VariablesSingleton._instance.getGirsAfer())
        {
            Invoke("SeAcabo", 3f);
        }


        _pointsCount.text = Coin.ToString();


        // Monedas
        if (Coin < 0)
        {
            Coin = 0;
        }
       
        if (VariablesSingleton._instance.GetControlesActivos())
        {

            for (int i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(0); // get the touch
                if (touch.phase == TouchPhase.Began) //check for the first touch
                {
                    fp = touch.position;
                    lp = touch.position;


                    //if (Input.GetTouch(i).position.x > halfScreenW)
                    //{
                    //    if (_pos != Posicion.dreta)
                    //    {
                    //        SiDerecha = true;

                    //    }

                    //}

                    //if (Input.GetTouch(i).position.x < halfScreenW)
                    //{
                    //    if (_pos != Posicion.esquerra)
                    //    {
                    //        SiIzquierda = true;


                    //    }

                    //}


                }
                else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
                {
                    lp = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
                {
                    lp = touch.position;  //last touch position. Ommitted if you use list

                    //Debug.Log(Mathf.Abs(lp.x - fp.x));
                    //Check if drag distance is greater than 20% of the screen height
                    // Debug.Log(Mathf.Abs(lp.y - fp.y));
                    if (Mathf.Abs(lp.y - fp.y) > dragDistanceY)
                    {//It's a drag
                     //check if the drag is vertical 
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            //Debug.Log("Up Swipe");
                           
                            salta();

                        }

                    }

                  else if (Mathf.Abs(lp.x - fp.x) > dragDistanceX)

                        if (lp.x > fp.x)
                        {
                            _movEsq = false;
                            _movDret = true;

                           


                        }
                        else if (lp.x < fp.x)
                        {
                            _movEsq = true;
                            _movDret = false;

                        }


   
                    //else
                    //{   //It's a tap as the drag distance is less than 15% of the screen height
                    //    if (SiDerecha) // miramos direccion que se quiere ir
                    //    {
                    //        _movEsq = false;
                    //        _movDret = true;

                    //        SiDerecha = false;

                    //        if (VariablesSingleton._instance.GetUnicaEleccio())
                    //        {
                    //            VariablesSingleton._instance.SetControlesActivos(false);
                    //        }

                    //    }
                    //    else if (SiIzquierda)
                    //    {
                    //        _movEsq = true;
                    //        _movDret = false;

                    //        SiIzquierda = false;

                    //        if (VariablesSingleton._instance.GetUnicaEleccio())
                    //        {
                    //            VariablesSingleton._instance.SetControlesActivos(false);
                    //        }

                    //    }
                    //    //Debug.Log("SINGLE TAP");
                    //}
                }
            }
        }

        //////UpdateEND

    }


    public void salta()
    {

        this.GetComponent<Animator>().SetBool("Jump", true);
        _isJump = true;
        
        VariablesSingleton._instance.SetControlesActivos(false);

    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "TreuControl")
        {
            VariablesSingleton._instance.SetControlesActivos(false);
            Recolocame();
        }

    }

    void OnTriggerEnter(Collider other) 

    {
        
        if (other.gameObject.tag == "Tuerca")
        {
            setCoin(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "TornilloDorado")
        {
            setCoin(10);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "EleccioFeta")
        {
            _imgElection = false;
            
        }

        if (other.gameObject.tag == "Valla")
        {
            Coin -=3;
            InvokeRepeating("ActivaDesactivaRender", 0f, 0.15f);
            Invoke("DesactivarInvokeRender", 0.8f);
        }

        if (other.gameObject.tag == "Giro")
        {

            GroundPoints _giroControl = other.gameObject.GetComponent<GroundPoints>();

      
            PivotPerGirarDreta = _giroControl.GiroDerecha.position;
            PivotPerGirarEsquerra = _giroControl.GiroIzquierda.position;
            ProximaInstanciaDreta = _giroControl.CrearDerecha.position;
            ProximaInstanciaEsquerra = _giroControl.CrearIzquierda.position;
            

            if (_imgLogic.GetposCorrecta().ToString() == "Dret" && _pos == Posicion.dreta)
            {

                Debug.Log(numImages);
                numImages ++;
                Debug.Log(numImages);
                posicioCorrecta = true;
                Debug.Log("Correcte");
                VariablesSingleton._instance.setImagesCorrectes(_img.sprite);

            }
            else if (_imgLogic.GetposCorrecta().ToString() == "Esq" && _pos == Posicion.esquerra)
            {

                Debug.Log(numImages);
                numImages++;
                Debug.Log(numImages);
                posicioCorrecta = true;
                Debug.Log("Correcte");
                VariablesSingleton._instance.setImagesCorrectes(_img.sprite);

            }
            else
            {

                posicioCorrecta = false;
                Debug.Log("Incorrecte");
                VariablesSingleton._instance.setImagesIncorrectes(_img.sprite);

                if (_imgLogic.GetposCorrecta().ToString() == "Dret")
                {

                    GirarMal = 0;// La posicio Correcta era Dreta

                }else
                {

                    GirarMal = 1;// La posicio Correcta era esquerra

                }

            }

            _giroControl.SetEliminame();
            
             VamosAgirar();

            _imgLogic.HideImgs();

        }

    }

    public void VamosAgirar()
    {
        
        switch (_pos)
        {
            case Posicion.centre:

                if (GirarMal ==1)
                {

                    _anguloParaCruces += 90;

                    Recorrido = Instantiate(Resources.Load("Prefabs/" + VariablesSingleton._instance.GetTematicaNivell() + "/Recorrido"), Vector3.zero, Quaternion.Euler(-90, 0, 0)) as GameObject;

                    Recorrido.transform.Rotate(0, 0, _anguloParaCruces);
                    Recorrido.transform.position = ProximaInstanciaDreta;
                    Recorrido.transform.Translate(-144.06f, 0.23f, 0);
                    _activaGiro = 0;

                    Invoke("Recolocame", 1f);
                    Invoke("DevuelveControl", 1.5f);
                    FeedBackRespuesta();
                    SumaGiro();

                }
                else
                {


                    _anguloParaCruces -= 90;

                    Recorrido = Instantiate(Resources.Load("Prefabs/" + VariablesSingleton._instance.GetTematicaNivell() + "/Recorrido"), Vector3.zero, Quaternion.Euler(-90, 0, 0)) as GameObject;
                    Recorrido.transform.Rotate(0, 0, _anguloParaCruces);
                    Recorrido.transform.position = ProximaInstanciaEsquerra;
                    Recorrido.transform.Translate(-144.06f, -0.23f, 0);
                    _activaGiro = 1;

                    Invoke("Recolocame", 1f);
                    Invoke("DevuelveControl", 1.5f);
                    FeedBackRespuesta();
                    SumaGiro();
                }

                break;

            case Posicion.dreta:


                _anguloParaCruces += 90;
                
                Recorrido = Instantiate(Resources.Load("Prefabs/" + VariablesSingleton._instance.GetTematicaNivell() + "/Recorrido"), Vector3.zero, Quaternion.Euler(-90, 0, 0)) as GameObject;
                
                Recorrido.transform.Rotate(0, 0, _anguloParaCruces);
                Recorrido.transform.position = ProximaInstanciaDreta;
                Recorrido.transform.Translate(-144.06f, 0.23f, 0);
                _activaGiro = 0;

                Invoke("Recolocame", 1f);
                Invoke("DevuelveControl", 1.5f);
                FeedBackRespuesta();
                SumaGiro();

                break;

            case Posicion.esquerra:

                _anguloParaCruces -= 90;

                Recorrido = Instantiate(Resources.Load("Prefabs/" + VariablesSingleton._instance.GetTematicaNivell() + "/Recorrido"), Vector3.zero, Quaternion.Euler(-90, 0, 0)) as GameObject;
                Recorrido.transform.Rotate(0, 0, _anguloParaCruces);
                Recorrido.transform.position = ProximaInstanciaEsquerra;
                Recorrido.transform.Translate(-144.06f, -0.23f, 0);
                _activaGiro = 1;

                Invoke("Recolocame", 1f);
                Invoke("DevuelveControl", 1.5f);
                FeedBackRespuesta();
                SumaGiro();

                break;

        }

    }

    public void Recolocame()
    {

        if (_pos == Posicion.dreta)
        {

            //_movEsq = true;
            _pos = Posicion.centre;
            _lastPos = Posicion.centre;
            _proximPos = Posicion.centre;

        }

        if (_pos == Posicion.esquerra)
        {

            //_movDret = true;
            _pos = Posicion.centre;
            _lastPos = Posicion.centre;
            _proximPos = Posicion.centre; 
              
        }

        _target = _centerPoint;
        _lastTarget = _centerPoint;

    }

    public void DevuelveControl()
    {
       
        VariablesSingleton._instance.SetControlesActivos(true);
        _imgElection = true;
        
    }


    public void FeedBackRespuesta()
    {

        if (posicioCorrecta)
        {

            // sonido.PlayOneShot(CorrectAnswer, 1f);
            _feedbackControl.setImage(true);

        }
        else
        {

            // sonido.PlayOneShot(WrongAnswer, 1f);
            _feedbackControl.setImage(false);
           

        }

    }


    public void setCoin(int value)
    {

        Coin += value;

    }

   

    void SumaGiro()
    {

        _girsFets++;

    }
    void SeAcabo()
    {

        SceneManager.LoadScene("ScoreScene");

    }






    //"ANIMACION" DE DAÑO
    void ActivaDesactivaRender()
    {
        if (pintant == false)
        {
            for (int i = 0; i < arrayRenderViod.Length; i++)
            {
                arrayRenderViod[i].enabled = false;
            }


            pintant = true;
        }
        else
        {
            for (int i = 0; i < arrayRenderViod.Length; i++)
            {
                arrayRenderViod[i].enabled = true;
            }
            pintant = false;
        }
    }

    // DESACTIVA ANIMACION
    void DesactivarInvokeRender()
    {
        pintant = true;
        for (int i = 0; i < arrayRenderViod.Length; i++)
        {
            arrayRenderViod[i].enabled = true;
        }
        CancelInvoke("ActivaDesactivaRender");
    }

    public void showImg()
    {
        _imgLogic.RandomImage();
    }     


    public void rightImg()
    {
        if (_imgElection)
        {
            _proximPos = Posicion.dreta;
            _target = _rightPoint;
            _meMuevo = true;
        }
    }


    public void leftImg()
    {       
        if (_imgElection)
        {
            _proximPos = Posicion.esquerra;
            _target = _leftPoint;
            _meMuevo = true;
        }
    }
}
