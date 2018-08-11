using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api.Requests;

public class LeaderBoardManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void getLeaderBoard()
    {
        new LeaderboardDataRequest().SetLeaderboardShortCode("RANK").SetEntryCount(10).Send((leadResponse) => {

            if (leadResponse.HasErrors)
            {
                Debug.Log("Leaderboard data retrieval failed ...");
            }
            else
            {
                Debug.Log("Leaderboard data retrieval succeeded ..." + leadResponse);

                // Render the leaderboard entries on the screen

                foreach (var entry in leadResponse.Data)
                {
                    string myText = "Rank: " + entry.Rank.ToString() + "    UserName: " + entry.UserName + "    Score: " + entry.GetNumberValue("SCORE").ToString();
                    Debug.Log(myText);
                }

            }
        });
    }
}
