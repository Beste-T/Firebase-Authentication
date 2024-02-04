using Firebase;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;


public class SignUpScript : MonoBehaviour
{
    [SerializeField] private InputField email;
    [SerializeField] private InputField password;
    [SerializeField] private Text errorMessage;
    [SerializeField] private Text signInText;

    private FirebaseAuth auth;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public async void SignUp()
    {
        try
        {
            Firebase.Auth.AuthResult result = await auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text);
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
