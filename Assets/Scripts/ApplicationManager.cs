using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;
using GameSparks.Api;

public class ApplicationManager : MonoBehaviour {
	

	public void Quit () 
	{
#if UNITY_EDITOR

        new EndSessionRequest().SetDurable(true).Send((response) => { }); // no response expected
        GameSparks.Core.GS.Reset();
        new EndSessionRequest()
        .Send((response) => {
            GSData scriptData = response.ScriptData;
            long? sessionDuration = response.SessionDuration;
        });

        UnityEditor.EditorApplication.isPlaying = false;
#else
        new EndSessionRequest().SetDurable(true).Send((response) =>{}); // no response expected
        GameSparks.Core.GS.Reset();
        new EndSessionRequest()
        .Send((response) => {
        GSData scriptData = response.ScriptData; 
        long? sessionDuration = response.SessionDuration; 
        });

        Application.Quit();
#endif
    }
}
