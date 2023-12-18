using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;


public class Blinker : MonoBehaviour
{
    //インスペクターから設定するか、初期化時にGetComponentして、TextMeshProUGUIへの参照を取得しておく。
    [SerializeField]
    TextMeshProUGUI tmp;

    [Header("1ループの長さ(秒単位)")]
    [SerializeField]
    [Range(0.1f, 10.0f)]
    float duration = 1.0f;

    [Header("(Aボタンを押してからの)1ループの長さ(秒単位)")]
    [SerializeField]
    [Range(0.1f, 10.0f)]
    float duration2 = 0.1f;

    //開始時の色。
    [Header("ループ開始時の色")]
    [SerializeField]
    Color32 startColor = new Color32(255, 255, 255, 255);

    //終了(折り返し)時の色。
    [Header("ループ終了時の色")]
    [SerializeField]
    Color32 endColor = new Color32(255, 255, 255, 64);

    [SerializeField]
    private FadeSceneLoder m_fade = null;

    [Header("フェードインの秒数")]
    [SerializeField]
    float fadein = 2.0f;

    [Header("フェードアウトの秒数")]
    [SerializeField]
    float fadeout = 1.0f;

    [Header("(Aボタンを押してから)フェードアウトするまでの秒数")]
    [SerializeField]
    float timeout = 1.5f;

    GameObject Canvas;
    FadeSceneLoder fadeSceneLoder;

    bool is_fadeout = false;

    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
        fadeSceneLoder = Canvas.GetComponent<FadeSceneLoder>();

        Action on_completed = () =>
        {
            is_fadeout = true;
        };
        m_fade.FadeIn(fadein, on_completed);
    }

    //インスペクターから設定した場合は、GetComponentする必要がなくなる為、Awakeを削除しても良い。
    void Awake()
    {
        if (tmp == null)
            tmp = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        tmp.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));

        if(is_fadeout == true && Input.GetButtonDown("A"))
        {
            StartCoroutine(Wait3SecondSAndFadeOut());
            duration = duration2;
        }
    }
    private IEnumerator Wait3SecondSAndFadeOut()
    {
        yield return new WaitForSeconds(timeout);
        m_fade.FadeOut(fadeout);
        is_fadeout = false;
    }
}
