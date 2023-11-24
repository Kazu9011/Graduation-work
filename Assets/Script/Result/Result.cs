using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Result : MonoBehaviour
{
    GameObject timesystemobj;
    TimeSystem timesystem;
    TextMeshProUGUI ResultUI;
    public GameObject playerpointobj;
    public GameObject enemypointobj;
    PlayerPoint playerpoint;
    EnemyPoint enemypoint;
    // Start is called before the first frame update
    void Start()
    {
        timesystemobj = GameObject.Find("Time");
        timesystem = timesystemobj.GetComponent<TimeSystem>();
        ResultUI = GetComponent<TextMeshProUGUI>();
        playerpointobj = GameObject.Find("PlayerPoint");
        enemypointobj = GameObject.Find("EnemyPoint");
        playerpoint = playerpointobj.GetComponent<PlayerPoint>();
        enemypoint = enemypointobj.GetComponent<EnemyPoint>();
        ResultUI.enabled = false;
        playerpoint.enabled = false;
        enemypoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timesystem.ChangeEndFlag)
        {
            ResultUI.enabled = true;
        }
    }
}
