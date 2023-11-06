using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StartTimer : MonoBehaviour
{
    public float StartTime;
    private float currenttime;
    TextMeshProUGUI TimeUI;
    GameObject timeobj;
    TimeSystem timesystem;
    // Start is called before the first frame update
    void Start()
    {
        currenttime = StartTime;
        timeobj = GameObject.Find("Time");
        timesystem = GetComponent<TimeSystem>();
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        TimeUI = GetComponent<TextMeshProUGUI>();
        currenttime -= Time.unscaledDeltaTime; ;
        TimeUI.text = currenttime.ToString("0");
        if (currenttime <= 0)
        {
            TimeUI.enabled = false;
            Time.timeScale = 1.0f;
        }
    }
}
