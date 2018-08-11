using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

public class GameSparksRegister : MonoBehaviour
{

    public Text connectionInfoField;
    public InputField userNameInput, passwordInput;

    public void register()
    {
        new RegistrationRequest()
                          .SetDisplayName(userNameInput.text)
                          .SetUserName(userNameInput.text)
                          .SetPassword(passwordInput.text)
                          .Send((reg_response) => {

                              if (!reg_response.HasErrors)
                              {
                                  connectionInfoField.text = "Registering succes...";
                                  // bu kullanici adi reg_response.DisplayName;
                              }
                              else
                              {
                                  connectionInfoField.text = "Registering error...";
                              }

                          });
    }
}
