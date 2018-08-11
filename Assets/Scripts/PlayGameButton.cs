using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;
using GameSparks.Api;

public class PlayGameButton : MonoBehaviour
{
    public void LoadGameScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void LogOut()
    {
        new EndSessionRequest().SetDurable(true).Send((response) => { }); // no response expected
        GameSparks.Core.GS.Reset();
        new EndSessionRequest()
        .Send((response) => {
            GSData scriptData = response.ScriptData;
            long? sessionDuration = response.SessionDuration;
        });
    }
}
