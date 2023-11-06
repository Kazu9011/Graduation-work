using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    public float TimeLimit = 60.00f;
    private float currenttime;
    TextMeshProUGUI TimeUI;
    //private TextMeshProUGUI TimeUI;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
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
            }
            TimeUI.text = currenttime.ToString("00.00");
            if (currenttime == 0.00f)
            {
                Time.timeScale = 0.0f;
            }
        }

    }
}
