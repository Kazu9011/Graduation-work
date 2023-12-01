using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fadeinout : MonoBehaviour
{
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

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (is_fadeout == true)
        {
            StartCoroutine(Wait3SecondSAndFadeOut());
        }
    }
    private IEnumerator Wait3SecondSAndFadeOut()
    {
        yield return new WaitForSeconds(timeout);
        m_fade.FadeOut(fadeout);
        is_fadeout = false;
    }

}
