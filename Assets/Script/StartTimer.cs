using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using KanKikuchi.AudioManager;
public class StartTimer : MonoBehaviour
{
    public float StartTime;
    public bool timeflag;
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
        timeflag = true;
        BGMManager.Instance.Play(BGMPath.NOESIS_2);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeflag)
        {
            TimeUI = GetComponent<TextMeshProUGUI>();
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
