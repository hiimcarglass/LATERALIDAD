using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Firebase
//using Firebase;
//using Firebase.Database;
//using Firebase.Unity.Editor;


public class Viod_Mov : MonoBehaviour
{
    int _proximaPosPlayer = 0;
    public int posPlayer = 0;//en el nivell on esta actualment
    
   
    private NavMeshAgent agent;
    public GameObject lvlPopUp;
    public GameObject lvl2PopUp;
    public GameObject lvl3PopUp;
    

    //Text de les màximes puntuacions de cada nivell
    public Text puntacioL1;
    public Text puntacioL2;
    public Text puntacioL3;

    //Botons del minicanvas de cada nivell-escenari
    public Button buttonNivell1;
    public Button buttonNivell2;
    public Button buttonNivell3;

    public bool[] arrayMiniCanvas; //Per saber cada minicanvas si està activat o no
    bool infoMaxim = false; // per escriure una sola vegada per consulta el valor de punts maxims aconseguits per nivell
    int control = 0; // Variable per fer les consultes de Firebase
    bool consulta = false; // controlar que les lectures-consultes es fa un cop

    //Raycast PC. Es podria fer tot en un, però per fer les proves ho vam separar
    

    //Raycast per la tablet
    Ray rayTab;
    RaycastHit hitTab;
    

    //FB
    //DatabaseReference reference;


    // Use this for initialization
    void Start()
    {

        
       
        //Botons amagats i apagats
        buttonNivell1.enabled = false;
        buttonNivell2.enabled = false;
        buttonNivell3.enabled = false;
        buttonNivell1.gameObject.SetActive(false);
        buttonNivell2.gameObject.SetActive(false);
        buttonNivell3.gameObject.SetActive(false);


        //Firebase

        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://testdatalateral.firebaseio.com/");
        //reference = FirebaseDatabase.DefaultInstance.RootReference;

        //Per fer una única consulta 
        //FirebaseDatabase.DefaultInstance.GetReference("LlistaUsuaris").Child(SingletonDireccio.userID).GetValueAsync().ContinueWith(task => {
        //    if (task.IsFaulted)
        //    {
        //        // Handle the error...
        //    }
        //    else if (task.IsCompleted)
        //    {
        //        DataSnapshot snapshot = task.Result;
        //        // Do something with snapshot...

        //        Debug.Log("info snap: " + snapshot.ChildrenCount);

        //        if (snapshot.Exists) //Si la info de la consulta GetReference existeix
        //        {

        //            Debug.Log("lhem trobat!!");

        //            //Recuperem dades
        //            SingletonDireccio.nivellActual = int.Parse(snapshot.Child("NivellActual").Value.ToString());
        //            Debug.Log("nivell actual a la bbdd: " + SingletonDireccio.nivellActual);

        //            SingletonDireccio.nivellMaximAconseguit = int.Parse(snapshot.Child("NivellMaximAconseguit").Value.ToString());
        //            Debug.Log("nivell maxim permes a la bbdd: " + SingletonDireccio.nivellMaximAconseguit);

        //            SingletonDireccio.puntuacioMaxima = float.Parse(snapshot.Child("DadesNivells").Child(SingletonDireccio.nivellActual.ToString()).Child("PuntacioMaxima").Value.ToString());

        //            infoMaxim = true;

        //            Debug.Log("La puntuacioMaxima a la bbdd es: " + SingletonDireccio.puntuacioMaxima);
        //            Debug.Log("el nivellMaximAconseguit es: " + SingletonDireccio.nivellMaximAconseguit);

        //            //reference.Child("LlistaUsuaris").Child(SingletonDireccio.userID).Child("NivellActual").SetValueAsync(SingletonDireccio.nivellActual);
        //            reference.Child("LlistaUsuaris").Child(SingletonDireccio.userID).Child("NivellMaximAconseguit").SetValueAsync(SingletonDireccio.nivellMaximAconseguit);
        //            reference.Child("LlistaUsuaris").Child(SingletonDireccio.userID).Child("DadesNivells").Child(SingletonDireccio.nivellActual.ToString()).Child("PuntacioMaxima").SetValueAsync(SingletonDireccio.puntuacioMaxima);

        //            //IntentsText.text += SingletonData.intentsPartides;
        //            //IDText.text += SingletonData.userID;

        //        }
        //        else if (!snapshot.Exists) //Si la info de la consulta NO existeix, escriu nova info a la base de dades
        //        {

        //            Debug.Log("tenim nova info!!");

        //            //Informació de l'usuari
        //            reference.Child("LlistaUsuaris").Child(SingletonDireccio.userID).Child("Nom").SetValueAsync(SingletonDireccio.userName);
        //            reference.Child("LlistaUsuaris").Child(SingletonDireccio.userID).Child("Email").SetValueAsync(SingletonDireccio.email);
        //            reference.Child("LlistaUsuaris").Child(SingletonDireccio.userID).Child("Password").SetValueAsync(SingletonDireccio.password);

        //            reference.Child("LlistaUsuaris").Child(SingletonDireccio.userID).Child("NivellActual").SetValueAsync(SingletonDireccio.nivellActual);
        //            reference.Child("LlistaUsuaris").Child(SingletonDireccio.userID).Child("NivellMaximAconseguit").SetValueAsync(SingletonDireccio.nivellMaximAconseguit);
        //            reference.Child("LlistaUsuaris").Child(SingletonDireccio.userID).Child("DadesNivells").Child(SingletonDireccio.nivellActual.ToString()).Child("PuntacioMaxima").SetValueAsync(SingletonDireccio.puntuacioMaxima);
        //        }
        //    }
        //});




        /////////////////////////////////////////////////////////////////////////////////////

        agent = GetComponent<NavMeshAgent>();

        lvlPopUp.SetActive(false); 
        

        lvl2PopUp.SetActive(false);
        
        lvl3PopUp.SetActive(false);
        

        arrayMiniCanvas = new bool[6];

        for (int i = 0; i < arrayMiniCanvas.Length; i++)
        {
            arrayMiniCanvas[i] = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (posPlayer != 0)
        {
            if (arrayMiniCanvas[posPlayer - 1])
            {
                this.gameObject.GetComponent<Animator>().SetBool("Corre", false);
            }
        }
        //Per escriure el valor de la maxima puntuació del minicanvas el qual esta el viod
        if (infoMaxim)
        {
            puntacioL1.text = "Puntuació màxima: " + VariablesSingleton._instance.GetPuntutacioMax();
            puntacioL2.text = "Puntuació màxima: " + VariablesSingleton._instance.GetPuntutacioMax();
            puntacioL3.text = "Puntuació màxima: " + VariablesSingleton._instance.GetPuntutacioMax();
            infoMaxim = false;
        }

        if (!agent.hasPath)
        {

        }


        //si el viod té una destinació nova, amaguem els canvas
        if (agent.hasPath)
        {
            if (_proximaPosPlayer != 1 && arrayMiniCanvas[0])
            {
                
                lvlPopUp.GetComponent<RectTransform>().transform.localScale = new Vector3(0, 0, 0);
                arrayMiniCanvas[0] = false;
                this.gameObject.GetComponent<Animator>().SetBool("Corre", true);
            }

            if (_proximaPosPlayer != 2 && arrayMiniCanvas[1])
            {
                lvl2PopUp.GetComponent<RectTransform>().transform.localScale = new Vector3(0, 0, 0); 
                arrayMiniCanvas[1] = false;
                this.gameObject.GetComponent<Animator>().SetBool("Corre", true);
            }

            if (_proximaPosPlayer != 3 && arrayMiniCanvas[2])
            {
                lvl3PopUp.GetComponent<RectTransform>().transform.localScale = new Vector3(0, 0, 0); 
                arrayMiniCanvas[2] = false;
                this.gameObject.GetComponent<Animator>().SetBool("Corre", true);
            }
        }

       

        //#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        //Control del viod per la Tablet
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rayTab = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            Debug.DrawRay(rayTab.origin, rayTab.direction * 20, Color.red);

            if (Physics.Raycast(rayTab, out hitTab, Mathf.Infinity))
            {
                Debug.Log("Hit something");
                

                //Destroy(hit.transform.gameObject);
                if (hitTab.collider.tag == "lvl1")
                {
                    this.gameObject.GetComponent<Animator>().SetBool("Corre", true);
                    _proximaPosPlayer = 1;
                    VariablesSingleton._instance.SetNivellActual(1);
                    
                    // agent.destination = hitTab.point;
                    agent.destination = hitTab.collider.gameObject.transform.position;
                    //consulta = true;
                    agent.velocity = agent.destination * Time.deltaTime;  // hem de comprovar si funciona a la tablet
                }
                if (hitTab.collider.tag == "lvl2")
                {
                    this.gameObject.GetComponent<Animator>().SetBool("Corre", true);
                    _proximaPosPlayer = 2;
                    
                    //agent.destination = hitTab.point;
                    agent.destination = hitTab.collider.gameObject.transform.position;
                    //consulta = true;
                    agent.velocity = agent.destination * Time.deltaTime;  // hem de comprovar si funciona a la tablet
                }

                if (hitTab.collider.tag == "lvl3")
                {
                    this.gameObject.GetComponent<Animator>().SetBool("Corre", true);
                    _proximaPosPlayer = 3;
                    
                    //agent.destination = hitTab.point;
                    agent.destination = hitTab.collider.gameObject.transform.position;
                    //consulta = true;
                    agent.velocity = agent.destination * Time.deltaTime;  // hem de comprovar si funciona a la tablet
                }

            }

        }

        //#endif
    }


    //COL·LISIONS
    void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.tag == "lvl1")
        {
            Debug.Log("Collisio 1");
            if (_proximaPosPlayer == 1)
            {
                consulta = true;

                arrayMiniCanvas[0] = true;


                posPlayer = 1;
                lvlPopUp.SetActive(true);
                buttonNivell1.enabled = false;
                lvlPopUp.GetComponent<RectTransform>().transform.localScale = new Vector3(1.5f, 1.5f, 0);
            }

            if (VariablesSingleton._instance.getNivellMaximAconseguit() >= 1)
            {

                buttonNivell1.enabled = true;
                buttonNivell1.gameObject.SetActive(true);
                

                VariablesSingleton._instance.SetNivellActual(1);

                if (consulta)
                {

                    //reference.Child("LlistaUsuaris").Child(SingletonDireccio.userID).Child("NivellActual").SetValueAsync(SingletonDireccio.nivellActual);
                    control = 1;
                    //rebaseDatabase.DefaultInstance.GetReference("LlistaUsuaris").Child(SingletonDireccio.userID).Child("DadesNivells").Child(SingletonDireccio.nivellActual.ToString()).Child("PuntacioMaxima").ValueChanged += HandleValueChanged;

                }

            }
        }

        if (other.gameObject.tag == "lvl2")
        {
            if (_proximaPosPlayer == 2)
            {
                consulta = true;
                Debug.Log("Collisio 2");

                arrayMiniCanvas[1] = true;

                posPlayer = 2;
                lvl2PopUp.SetActive(true);
                buttonNivell2.enabled = false;
                lvl2PopUp.GetComponent<RectTransform>().transform.localScale = new Vector3(1.5f, 1.5f, 0);
            }

            if (VariablesSingleton._instance.getNivellMaximAconseguit() >= 2)
            {
                Debug.Log("canvas " + posPlayer);
                buttonNivell2.enabled = true;
                buttonNivell2.gameObject.SetActive(true);

                VariablesSingleton._instance.SetNivellActual(2);

                if (consulta)
                {

                    //reference.Child("LlistaUsuaris").Child(SingletonDireccio.userID).Child("NivellActual").SetValueAsync(SingletonDireccio.nivellActual);
                    control = 2;
                    //FirebaseDatabase.DefaultInstance.GetReference("LlistaUsuaris").Child(SingletonDireccio.userID).Child("DadesNivells").Child(SingletonDireccio.nivellActual.ToString()).Child("PuntacioMaxima").ValueChanged += HandleValueChanged;

                }
            }
        }


        if (other.gameObject.tag == "lvl3")
        {
            if (_proximaPosPlayer == 3)
            {
                consulta = true;
                Debug.Log("Collisio 3");

                arrayMiniCanvas[2] = true;

                posPlayer = 3;
                lvl3PopUp.SetActive(true);
                buttonNivell3.enabled = false;
                lvl3PopUp.GetComponent<RectTransform>().transform.localScale = new Vector3(1.5f, 1.5f, 0);

            }
            if (VariablesSingleton._instance.getNivellMaximAconseguit() >= 3)
            {
                Debug.Log("canvas " + posPlayer);
                buttonNivell3.enabled = true;
                buttonNivell3.gameObject.SetActive(true);

                VariablesSingleton._instance.SetNivellActual(3);

                if (consulta)
                {

                    //reference.Child("LlistaUsuaris").Child(SingletonDireccio.userID).Child("NivellActual").SetValueAsync(SingletonDireccio.nivellActual);
                    control = 3;
                   //FirebaseDatabase.DefaultInstance.GetReference("LlistaUsuaris").Child(SingletonDireccio.userID).Child("DadesNivells").Child(SingletonDireccio.nivellActual.ToString()).Child("PuntacioMaxima").ValueChanged += HandleValueChanged;

                }
            }
        }


    }





    //Per fer múltiples consultes durant el joc. Cridaríem el mètode de sota amb la següent línia de codi en el lloc/moment que ens interessi: FirebaseDatabase.DefaultInstance.GetReference ("users").Child("PepitoDeLosPalotes").Child("Points").ValueChanged += HandleValueChanged;
    //void HandleValueChanged(object sender, ValueChangedEventArgs args)
    //{

    //    if (args.DatabaseError != null)
    //    {
    //        Debug.LogError(args.DatabaseError.Message);
    //        return;
    //    }
    //    //    la variable control es un enter que li assignem un valor en la crida del mètode de la consulta.Aquí en funció del seu valor, llegeix i / o escriu dades a la bbdd
    //    if (control == 1)
    //    {
    //        //        els snapshots contenen la informació de la consulta. Contenen una Key(els nodes) i un Value(només alguns hi tenen informació, segons com hem fet la bbdd).
    //        //       La consulta s'ha fet cridant el mètode handlevalue posant-li l'adreça de la info que es volia consultar ("users").Child("PepitoDeLosPalotes").Child("Points").
    //        //        Un cop aquí, amb els Snapshots també es pot acabar d'anar a buscar dades a nivells inferiors (Child().Child()...) 
    //        if (args.Snapshot != null)
    //        {
    //            Debug.Log("");
    //        }


    //        //Si no ho troba a la bbdd
    //        else if (args.Snapshot == null)
    //        {


    //        }
    //        //Si existeix o no a la base de dades  --->  if (args.Snapshot.Exists) {
    //        if (args.Snapshot.Exists)
    //        {
    //            Debug.Log("nivell existeix: " + control);
    //            SingletonDireccio.puntuacioMaxima = float.Parse(args.Snapshot.Value.ToString());
    //            Debug.Log("puntuacio maxima consulta: " + SingletonDireccio.puntuacioMaxima);
    //            infoMaxim = true;
    //        }

    //        if (!args.Snapshot.Exists)
    //        {
    //            Debug.Log("nivell NO existeix: " + control);
    //            SingletonDireccio.puntuacioMaxima = 0;
    //            infoMaxim = true;
    //        }
    //        consulta = false;
    //    }

    //    else if (control == 2)
    //    {

    //        if (args.Snapshot.Exists)
    //        {
    //            Debug.Log("nivell existeix: " + control);
    //            SingletonDireccio.puntuacioMaxima = float.Parse(args.Snapshot.Value.ToString());
    //            Debug.Log("puntuacio maxima consulta: " + SingletonDireccio.puntuacioMaxima);
    //            infoMaxim = true;
    //        }

    //        if (!args.Snapshot.Exists)
    //        {
    //            Debug.Log("nivell NO existeix: " + control);
    //            SingletonDireccio.puntuacioMaxima = 0;
    //            infoMaxim = true;
    //        }

    //        consulta = false;
    //    }
    //    else if (control == 3)
    //    {

    //        if (args.Snapshot.Exists)
    //        {
    //            Debug.Log("nivell existeix: " + control);
    //            SingletonDireccio.puntuacioMaxima = float.Parse(args.Snapshot.Value.ToString());
    //            Debug.Log("puntuacio maxima consulta: " + SingletonDireccio.puntuacioMaxima);
    //            infoMaxim = true;
    //        }

    //        if (!args.Snapshot.Exists)
    //        {
    //            Debug.Log("nivell NO existeix: " + control);
    //            SingletonDireccio.puntuacioMaxima = 0;
    //            infoMaxim = true;
    //        }

    //        consulta = false;

    //    }
    //}


}
