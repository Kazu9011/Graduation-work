using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FadeOut : MonoBehaviour
{
    [SerializeField]
    private FadeSceneLoder m_fade = null;

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

    public void Fadeout()
    {
        m_fade.FadeOut(fadeout);
    }

}
