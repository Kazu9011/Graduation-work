using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class FadeSceneLoder : MonoBehaviour
{
    public Image fadePanel;             // フェード用のUIパネル(Image)
    public float fadeDuration = 1.0f;   // フェード完了にかかる時間

    [SerializeField] private Image m_image = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallCoroutine()
    {
        StartCoroutine(FadeOutAndLoadScene());
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        fadePanel.enabled = true;               // パネルを有効化
        float elapsedTime = 0.0f;               // 経過時間を初期化
        Color startColor = fadePanel.color;     // フェードパネルの開始色を取得
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // フェードパネルの最終色を取得

        // フェードアウトアニメーションを実行
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                          // 経過時間を増やす
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);    // フェードの進行度を計算
            fadePanel.color = Color.Lerp(startColor, endColor, t);  // パネルの色を変更してフェードアウト
            yield return null;                                      // 1フレーム待機
        }

        fadePanel.color = endColor;     // フェードが完了したら最終色に設定
        /*SceneManeger.LoadScene("");*/     // シーンをロード(ここに遷移したいSceneNameを入力)
    }

    private void Reset()
    {
        m_image = GetComponent<Image>();
    }
    private IEnumerator ChangeAlphaValueFrom0To10verTime(float duration, Action on_completed,bool is_reversing = false)
    {
        if (!is_reversing) m_image.enabled = true;

        var elapsed_time = 0.0f;
        var color = m_image.color;

        while( elapsed_time < duration)
        {
            var elapsed_rate = Mathf.Min(elapsed_time / duration, 1.0f);
            color.a = is_reversing ? 1.0f - elapsed_rate : elapsed_rate;
            m_image.color = color;

            yield return null;
            elapsed_time += Time.deltaTime;
        }

        if (is_reversing) m_image.enabled = false;
        if (on_completed != null) on_completed();
    }
    public void FadeIn(float duration,Action on_completed = null)
    {
        StartCoroutine(ChangeAlphaValueFrom0To10verTime(duration, on_completed, true));
    }

    public void FadeOut(float duration,Action on_complete = null)
    {
        StartCoroutine(ChangeAlphaValueFrom0To10verTime(duration, on_complete));
    }
}
