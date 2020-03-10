using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    public float timeStart;
    public GameObject timeText;

    bool timerActive = true;

    // Start is called before the first frame update
    void Start()
    {
        timeText.GetComponent<Text>().text = "TIME " + timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive){
        timeStart += Time.deltaTime;
        timeText.GetComponent<Text>().text = "TIME " + timeStart.ToString("F2");
        }
    }

    public void timerButton(){
        timerActive = !timerActive;
    }
}
