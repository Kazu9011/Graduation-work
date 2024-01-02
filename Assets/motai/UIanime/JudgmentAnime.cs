using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgmentAnime : MonoBehaviour
{

    [SerializeField] Image img;

    [Header("1ループの長さ(秒単位)")]
    [SerializeField]
    [Range(0.1f, 10.0f)]
    float duration = 1.0f;

    [Header("点滅ループを止める時間")]
    [SerializeField]
    float timestop = 4.0f;

    Color32 startColor = new Color32(255, 255, 255, 0);

    Color32 endColor = new Color32(255, 255, 255, 255);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIColor();
    }


    void UIColor()
    {
        img.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));
        if (Time.time >= timestop)
        {
            img.color = Color.Lerp(startColor, endColor, 1);
        }
    }

}
