using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase;

public class LoginScript : MonoBehaviour
{
    [SerializeField] private InputField email;
    [SerializeField] private InputField password;
    [SerializeField] private Text errorMessage;


    private FirebaseAuth auth;


    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

   

    public async void Login()
    {
        try
        {
            Firebase.Auth.AuthResult result = await auth.SignInWithEmailAndPasswordAsync(email.text, password.text);
            Debug.LogFormat("Firebase user created successfully: {0} ({1})", result.User.DisplayName, result.User.UserId);
        }
        catch (FirebaseException firebaseEx)
        {
            errorMessage.text = "" + firebaseEx.Message;
            Debug.LogError("Firebase Exception: " + firebaseEx.ErrorCode + " - " + firebaseEx.Message);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Non-Firebase Exception: " + ex.ToString());
        }
    }
}
