using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class register_firebase : MonoBehaviour {

    public InputField EmailAdress, Password;

    public void LogInButtonPressed()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailAdress.text, Password.text).
            ContinueWith((obj) =>
            {
                SceneManager.LoadSceneAsync("LoggedInScene");
            });

    }

    public void LogInAnonymousButtonPressed()
    {
        FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync().
            ContinueWith((obj)=>
            {
                SceneManager.LoadSceneAsync("LoggedInAnonimousScene");
            });
    }

    public void CreateNewUserButtonPressed()
    {
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(EmailAdress.text, Password.text).
            ContinueWith((obj) =>
            {
                SceneManager.LoadSceneAsync("LoggedInScene");
            });
    }


	
}
