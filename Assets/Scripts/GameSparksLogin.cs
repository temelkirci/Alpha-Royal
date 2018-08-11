using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;
using UnityEngine.SceneManagement;

public class GameSparksLogin : MonoBehaviour
{
    public Text connectionInfoField;
    public InputField userNameInput, passwordInput;
   

    public void login()
    {
        new AuthenticationRequest()
            .SetUserName(userNameInput.text)//set the username for login
            .SetPassword(passwordInput.text)//set the password for login
            .Send((auth_response) => { //send the authentication request

            if (!auth_response.HasErrors)
            { 
                // for the next part, check to see if we have any errors i.e. Authentication failed
                connectionInfoField.text = "Loggining Succes...";
                // bu kullanici adi : auth_response.DisplayName;

                SceneManager.LoadScene("MenuScene");
                
            }
            else
            {
                Debug.LogWarning(auth_response.Errors.JSON); // if we have errors, print them out
                if (auth_response.Errors.GetString("DETAILS") == "UNRECOGNISED")
                { 
                    // if we get this error it means we are not registered, so let's register the user instead
                    connectionInfoField.text = "User Doesn't Exists...";
                }
            }
         });


    }

}
