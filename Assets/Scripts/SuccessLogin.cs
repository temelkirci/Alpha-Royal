using UnityEngine;
using UnityEngine.SceneManagement;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;
using GameSparks.Api;
using UnityEngine.UI;

public class SuccessLogin : MonoBehaviour
{
    public Text userName;

    public void Start()
    {
        getUserName();
    }

    public void getUserName()
        {
            new AccountDetailsRequest()
            .Send((response) => {

                userName.text = response.DisplayName;
                //GSData externalIds = response.ExternalIds;
                //var location = response.Location;          
                //string userId = response.UserId;
                //GSData virtualGoods = response.VirtualGoods;
            });

        }
    
}
