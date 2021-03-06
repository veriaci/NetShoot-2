﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreInsert : MonoBehaviour
{
    string URL = "http://localhost/netshoot/scoreInsert.php";
    public string InputId, InputName, InputTime, InputScore;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameHasEnded){
            AddScore(InputId, InputName, InputTime, InputScore);
        }
    }

    public void AddScore(string id, string name, string time, string score){
        WWWForm form = new WWWForm ();
        form.AddField("addId", id);
        form.AddField("addName", name);
        form.AddField("addTime", time);
        form.AddField("addScore", score);

        WWW www = new WWW (URL, form);
    }
}
