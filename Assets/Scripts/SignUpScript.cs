using System;
using UnityEngine;
using UnityEngine.UI;

public class SignUpScript : MonoBehaviour
{
    [SerializeField] private InputField email;
    [SerializeField] private InputField password;
    [SerializeField] private Text errorMessage;
    [SerializeField] private Text signInText;
    [SerializeField] private GameObject signInScreen;
    [SerializeField] private GameObject signUpScreen;

    private FirebaseManagerScript firebaseManager;

    void Start()
    {
        firebaseManager = GetComponent<FirebaseManagerScript>();
    }

    public async void SignUp()
    {
        try
        {
            await firebaseManager.SignUpAsync(email.text, password.text);
            // Additional UI logic or scene transitions can be added here
        }
        catch (Exception ex)
        {
            errorMessage.text = "" + ex.Message;
        }
    }

    public void OnSignInTextClick()
    {
        signInScreen.SetActive(true);
        signUpScreen.SetActive(false);
    }
}
