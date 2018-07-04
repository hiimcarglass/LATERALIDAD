using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GestionMenu : MonoBehaviour
{


    public InputField UserNameSign, UserEmailSign, PasswordSign, UserEmailLogIn, PasswordLogIn;
    public Button SignupButton, LoginButton, AnonimButton;
    


    public Text MensajeError = null; // me lo miro luego como hacerlo bien

    // Use this for initialization
    void Start()
    {

        PasswordSign.contentType = InputField.ContentType.Password;
        PasswordLogIn.contentType = InputField.ContentType.Password;


        SignupButton.onClick.AddListener(() => Signup(UserEmailSign.text, PasswordSign.text));
        LoginButton.onClick.AddListener(() => Login(UserEmailLogIn.text, PasswordLogIn.text));
        AnonimButton.onClick.AddListener(() => accedirAnonimament());

    }


    public void Signup(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(UserNameSign.text))
        {
            //Error handling
            
            MensajeError.text ="Has d'emplenar tots els camps";

            Invoke("ClearErrorMessage", 1.5f); 

            return;
        }

        if (UserNameSign.text != "" && UserEmailSign.text != "")
        {
            /*
                auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.LogError("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
                        if (task.Exception.InnerExceptions.Count > 0)
                            UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
                        return;
                    }

                    FirebaseUser newUser = task.Result; // Firebase user has been created.

                    SingletonData.userName = UserNameInput.text;
                    SingletonData.email = email;
                    SingletonData.password = password;

                    Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                            newUser.DisplayName, newUser.UserId);

                    UpdateErrorMessage("Registre realitzat satisfactòriament");
                });


            //Actualitzar l'usuari per guardar el nom en el perfil --> ho fa per a l'usari connectat anteriorment
            //Firebase.Auth.FirebaseUser user = auth.CurrentUser;
            //    if (user != null)
            //    {
            //        Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
            //        {
            //            DisplayName = UserNameInput.text,

            //        };
            //        user.UpdateUserProfileAsync(profile).ContinueWith(task =>
            //        {
            //            if (task.IsCanceled)
            //            {
            //                Debug.LogError("UpdateUserProfileAsync was canceled.");
            //                return;
            //            }
            //            if (task.IsFaulted)
            //            {
            //                Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
            //                return;
            //            }

            //            Debug.Log("User profile updated successfully.");
            //        });


                //enviar email confirmacio del registre (és opcional) -------> hi ha algun error: envia el correu de confirmació a l'usuari anterior que s'havia connectat
                //user.SendEmailVerificationAsync().ContinueWith(task => {
                //        if (task.IsCanceled)
                //        {
                //            Debug.LogError("SendEmailVerificationAsync was canceled.");
                //            return;
                //        }
                //        if (task.IsFaulted)
                //        {
                //            Debug.LogError("SendEmailVerificationAsync encountered an error: " + task.Exception);
                //            return;
                //        }

                //        Debug.Log("Email sent successfully.");
                //    });
     

                //}   
                
    */
        }

        SceneManager.LoadScene("LvlsMap"); // Canviar quan tinguem el Firebase
    }


    public void Login(string email, string password)
    {

        /*

       auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
       {
           if (task.IsCanceled)
           {
               Debug.LogError("SignInWithEmailAndPasswordAsync canceled.");
               return;
           }
           if (task.IsFaulted)
           {
               Debug.LogError("SignInWithEmailAndPasswordAsync error: " + task.Exception);
               if (task.Exception.InnerExceptions.Count > 0)
                   UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
               return;
           }

           FirebaseUser user = task.Result;
           Debug.LogFormat("User signed in successfully: {0} ({1})",
               user.DisplayName, user.UserId);

           SingletonData.userID = user.UserId;

           SingletonData.email = email;
           SingletonData.password = password;

           SceneManager.LoadScene("SelectLvl");

       });

   */
        SceneManager.LoadScene("LvlsMap"); // Canviar quan tinguem el Firebase

    }
    public void accedirAnonimament()
    {
        SceneManager.LoadScene("LvlsMap");
    }


    void ClearErrorMessage()
    {
        MensajeError.text = "";
    }

}
