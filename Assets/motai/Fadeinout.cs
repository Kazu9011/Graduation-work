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

    GameObject Canvas;
    FadeSceneLoder fadeSceneLoder;

    // Start is called before the first frame update
    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
        fadeSceneLoder = Canvas.GetComponent<FadeSceneLoder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        m_fade.FadeIn(fadein);
    }

    public void FadeOut()
    {
        m_fade.FadeOut(fadeout);
    }

}
