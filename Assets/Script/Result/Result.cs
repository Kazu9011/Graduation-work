using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Result : MonoBehaviour
{
    GameObject timesystemobj;
    TimeSystem timesystem;
    //表示されている点数
    GameObject PlayerPointObj;
    GameObject EnemyPointObj;
    PlayerPoint playerpoint;
    EnemyPoint enemypoint;
    //表示する点数
    public GameObject EndPlayerPointObj;
    public GameObject EndEnemyPointObj;
    TextMeshProUGUI playerpointtmp;
    TextMeshProUGUI enemypointtmp;
    //表示するテクスチャ
    public GameObject MatchResultObj;
    public GameObject WinObj;
    public GameObject LoseObj;
    public GameObject DrawObj;
    public GameObject Window;
    public GameObject Gotitle;
    public GameObject Rematch;
    // Start is called before the first frame update
    public string CurretScene;
    public string Startscene;
    public float WaitTime = 2.0f;

    public GameObject A_CircleGaugeobj;
    public GameObject B_CircleGaugeobj;
    private Image a_circle;
    private Image b_circle;
    void Start()
    {
        timesystemobj = GameObject.Find("Time");
        timesystem = timesystemobj.GetComponent<TimeSystem>();
        PlayerPointObj = GameObject.Find("PlayerPoint");
        EnemyPointObj = GameObject.Find("EnemyPoint");
        playerpoint = PlayerPointObj.GetComponent<PlayerPoint>();
        enemypoint = EnemyPointObj.GetComponent<EnemyPoint>();
        timesystem = timesystemobj.GetComponent<TimeSystem>();
        playerpointtmp = EndPlayerPointObj.GetComponent<TextMeshProUGUI>();
        enemypointtmp = EndEnemyPointObj.GetComponent<TextMeshProUGUI>();
        A_CircleGaugeobj = GameObject.Find("A_CircleGauge");
        B_CircleGaugeobj = GameObject.Find("B_CircleGauge");
        a_circle = A_CircleGaugeobj.GetComponent<Image>();
        b_circle = B_CircleGaugeobj.GetComponent<Image>();
        playerpointtmp.enabled = false;
        enemypointtmp.enabled = false;
        MatchResultObj.SetActive(false);
        WinObj.SetActive(false);
        LoseObj.SetActive(false);
        DrawObj.SetActive(false);
        Window.SetActive(false);
        Gotitle.SetActive(false);
        Rematch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timesystem.ChangeEndFlag)
        {
            Window.SetActive(true);
            MatchResultObj.SetActive(true);
            Gotitle.SetActive(true);
            Rematch.SetActive(true);
            playerpointtmp.enabled = true;
            enemypointtmp.enabled = true;
            playerpointtmp.text = playerpoint.CurrentPoint.ToString("0");
            enemypointtmp.text = enemypoint.CurrentPoint.ToString("0");
            if (playerpoint.CurrentPoint > enemypoint.CurrentPoint)
            {
                WinObj.SetActive(true);
            }
            else if (playerpoint.CurrentPoint < enemypoint.CurrentPoint)
            {
                LoseObj.SetActive(true);
            }
            else 
            {
                DrawObj.SetActive(true);
            }
            if (Input.GetButton("A"))
            {
                a_circle.fillAmount += 1.0f / WaitTime * Time.unscaledDeltaTime;
                
                if (a_circle.fillAmount>=1.0f)
                {
                    SceneManager.LoadScene(CurretScene);
                }
            }
            else a_circle.fillAmount = 0;
            if (Input.GetButton("B"))
            {
                b_circle.fillAmount += 1.0f / WaitTime * Time.unscaledDeltaTime;
                if (b_circle.fillAmount >= 1.0f)
                {
                    SceneManager.LoadScene(Startscene);
                }
            }
            else b_circle.fillAmount = 0;
        }
    }
}
