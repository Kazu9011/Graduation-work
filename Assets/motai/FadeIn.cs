using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [SerializeField]
    private FadeSceneLoder m_fade = null;

    [Header("フェードインの秒数")]
    [SerializeField]
    float fadein = 2.0f;

    GameObject Canvas;
    FadeSceneLoder fadeSceneLoder;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        fadeSceneLoder = Canvas.GetComponent<FadeSceneLoder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fadein()
    {
        m_fade.FadeIn(fadein);
    }
}
