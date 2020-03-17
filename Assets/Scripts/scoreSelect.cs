using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreSelect : MonoBehaviour
{
    string URL = "http://localhost/netshoot/scoreSelect.php";
    public string [] scoreData;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW score = new WWW (URL);
        yield return score;
        string scoreDataString = score.text;
        scoreData = scoreDataString.Split (';');

        print (GetValueData(scoreData[0],"score:"));
    }

    string GetValueData(string data, string index){
        string value = data.Substring (data.IndexOf(index)+index.Length);
        if(value.Contains("|")){
            value = value.Remove (value.IndexOf("|"));
        }
        return value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
