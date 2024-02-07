using System;
using UnityEngine;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    [SerializeField] private InputField email;
    [SerializeField] private InputField password;
    [SerializeField] private Text errorMessage;

    private FirebaseManagerScript firebaseManager;

    void Start()
    {
        firebaseManager = GetComponent<FirebaseManagerScript>();
    }

    public async void Login()
    {
        try
        {
            await firebaseManager.LoginAsync(email.text, password.text);
            // Additional UI logic or scene transitions can be added here
        }
        catch (Exception ex)
        {
            errorMessage.text = "" + ex.Message;
        }
    }
}
