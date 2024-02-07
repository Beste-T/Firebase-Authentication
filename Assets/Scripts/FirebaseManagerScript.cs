using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;
using UnityEngine;

public class FirebaseManagerScript : MonoBehaviour
{
    private FirebaseAuth auth;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public async Task<Firebase.Auth.AuthResult> SignUpAsync(string email, string password)
    {
        try
        {
            Firebase.Auth.AuthResult result = await auth.CreateUserWithEmailAndPasswordAsync(email, password);
            Debug.LogFormat("Firebase user created successfully: {0} ({1})", result.User.DisplayName, result.User.UserId);
            return result;
        }
        catch (FirebaseException firebaseEx)
        {
            Debug.LogError("Firebase Exception: " + firebaseEx.ErrorCode + " - " + firebaseEx.Message);
            throw firebaseEx;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Non-Firebase Exception: " + ex.ToString());
            throw ex;
        }
    }

    public async Task<Firebase.Auth.AuthResult> LoginAsync(string email, string password)
    {
        try
        {
            Firebase.Auth.AuthResult result = await auth.SignInWithEmailAndPasswordAsync(email, password);
            Debug.LogFormat("Firebase user logged in successfully: {0} ({1})", result.User.DisplayName, result.User.UserId);
            return result;
        }
        catch (FirebaseException firebaseEx)
        {
            Debug.LogError("Firebase Exception: " + firebaseEx.ErrorCode + " - " + firebaseEx.Message);
            throw firebaseEx;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Non-Firebase Exception: " + ex.ToString());
            throw ex;
        }
    }
}
