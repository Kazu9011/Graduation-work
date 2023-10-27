using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeSystem : MonoBehaviour
{
    public float TimeLimit = 60.00f;
    private float currenttime;
    TextMeshProUGUI TimeUI;
    //private TextMeshProUGUI TimeUI;
    // Start is called before the first frame update
    void Start()
    {
        currenttime = TimeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        TimeUI = GetComponent<TextMeshProUGUI>();
        currenttime -= Time.deltaTime;
        TimeUI.text = currenttime.ToString("00.00");
        
        
    }
}
