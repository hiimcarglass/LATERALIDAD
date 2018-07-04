using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using Firebase.Auth;


public class MenuControl : MonoBehaviour {

    public InputField Email;
    public InputField Password;
    public InputField EmailTake;
    public InputField PasswordTake;

    public GameObject pnl_welcome;
    public GameObject pnl_signup;
    public GameObject pnl_login;
    public GameObject pnl_anonymous;

    public Button regist;
    public Button login;
    public Button anonymous;
    public Button enter_login;
    public Button enter_signin;
    public Button enter_anonymous;

    public GameObject LoadingRadiusBar;
    public Transform LoadingBar;
    public Transform textNum;
    public Transform textLoading;

    [SerializeField]
    private float currentAmount;
    [SerializeField]
    private float speed;



    // Use this for initialization
    void Start ()
    {

    }

   

    // Update is called once per frame
    void Update()
    {
        Button btn_regist = regist.GetComponent<Button>();
        btn_regist.onClick.AddListener(enterSignUp);

        Button btn_login = login.GetComponent<Button>();
        btn_login.onClick.AddListener(enterLogIn);

        Button btn_anonymous = anonymous.GetComponent<Button>();
        btn_anonymous.onClick.AddListener(enterAnonymous);

        Button btn_entersignin = enter_signin.GetComponent<Button>();
        btn_entersignin.onClick.AddListener(CreateNewUserButtonPressed);

        Button btn_enterlogin = enter_login.GetComponent<Button>();
        btn_enterlogin.onClick.AddListener(LogInButtonPressed);

        //Button btn_enteranonymous = enter_anonymous.GetComponent<Button>();
        //enter_anonymous.onClick.AddListener(Anonym);
 
        
    }
   /* public override string ToString()
    {
        return "I'm a faggot";
    }*/

    public void LogInButtonPressed()
    {       
        SceneManager.LoadScene("NivellCiutat");
    }

    public void LogInAnonymousButtonPressed()
    {
        SceneManager.LoadScene("NivellCiutat");
    }

    public void CreateNewUserButtonPressed()
    {
        SceneManager.LoadScene("NivellCiutat");
    }

   

    public void enterLogIn()
    {

        pnl_login.SetActive(true);
        pnl_signup.SetActive(false);
        pnl_welcome.SetActive(false);
        pnl_anonymous.SetActive(false);
        
    }

    public void enterSignUp()
    {
        pnl_login.SetActive(false);
        pnl_signup.SetActive(true);
        pnl_welcome.SetActive(false);
        pnl_anonymous.SetActive(false);
    }

    public void enterAnonymous()
    {
        pnl_login.SetActive(false);
        pnl_signup.SetActive(false);
        pnl_welcome.SetActive(false);
        pnl_anonymous.SetActive(true);
    }


    public void Regist()
    {
        Debug.Log("Registra al usuario");

    }

    public void Login()
    {
        Debug.Log("Esto accedera con cada usuario");

    }


    public void Anonym()
    {
        
        SceneManager.LoadScene("NivellCiutat");
    }



   

       

       
    //-------------------------------------------------------------------------------FIREBASE---------------------------------------------------------------------------------------------------------------------

    public class User
    {

        public string username;
        public string email;

        public User()
        {
           
        }

        public User (string username, string email)
        {
            this.username = username;
            this.email = email;

        }
       
    }





    /*void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        Debug.Log("tenemos " + args.Snapshot.ChildrenCount);
        foreach (var childSnapshot in args.Snapshot.Children)
        {
            GameObject Texto = Instantiate(Resources.Load("Prefabs/Text"), Vector2.zero, new Quaternion(0, 0, 0, 0)) as GameObject;

            Texto.GetComponent<Text>().text = childSnapshot.Key.ToString() + " " + childSnapshot.Child("Puntos").Value.ToString();

            Texto.transform.SetParent(canva.transform);

            Texto.transform.localPosition = new Vector2(x2, y);

            y -= 15;

        }


    }*/
}
