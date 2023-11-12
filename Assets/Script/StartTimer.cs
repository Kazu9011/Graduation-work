using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using KanKikuchi.AudioManager;
public class StartTimer : MonoBehaviour
{
    private bool bufferflag;
    private float startbuffer;
    private float curretbuffer;
    //
    public float StartTime;
    public bool timeflag;
    private float currenttime;
    TextMeshProUGUI TimeUI;
    GameObject timeobj;
    TimeSystem timesystem;
    // Start is called before the first frame update
    void Start()
    {
        bufferflag = true;
        startbuffer = 15.0f;
        curretbuffer = 0.0f;
        currenttime = StartTime;
        timeobj = GameObject.Find("Time");
        timesystem = GetComponent<TimeSystem>();
        Time.timeScale = 0.0f;
        timeflag = true;
        
        BGMManager.Instance.Play(BGMPath.NOESIS_2);
        TimeUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeflag)
        {
            if (bufferflag)
            {
                 if (curretbuffer < startbuffer)
                 {
                     curretbuffer += Time.unscaledDeltaTime;
                     return;
                 }
                 bufferflag = false;
                 SEManager.Instance.Play(SEPath.COUNTDOWN);
            }
            currenttime -= Time.unscaledDeltaTime; ;
            TimeUI.text = currenttime.ToString("0");
            if (currenttime <= 0)
            {
                TimeUI.enabled = false;
                Time.timeScale = 1.0f;
                timeflag = false;
            }
            
        }
    }
}
