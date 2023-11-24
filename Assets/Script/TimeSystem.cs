using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using KanKikuchi.AudioManager;
public class TimeSystem : MonoBehaviour
{
    private bool flag;
    public bool ChangeFlag
    {
        get
        {
            return flag;
        }
        set
        {
            flag = value;
        }
    }
    private bool endflag;
    public bool ChangeEndFlag
    {
        get
        {
            return endflag;
        }
        set
        {
            endflag = value;
        }
    }
    public float TimeLimit = 60.00f;
    private float currenttime;
    TextMeshProUGUI TimeUI;
    //private TextMeshProUGUI TimeUI;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        ChangeEndFlag = false;
        currenttime = TimeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            TimeUI = GetComponent<TextMeshProUGUI>();
            currenttime -= Time.deltaTime;
            if (currenttime < 0.00f)
            {
                currenttime = 0.00f;
                SEManager.Instance.Play(SEPath.END_WHISTLE);
                Time.timeScale = 0.0f;
                ChangeEndFlag = true;
            }
            TimeUI.text = currenttime.ToString("00.00");
            //if (currenttime == 0.00f)
            //{
                
            //}
        }

    }
}
