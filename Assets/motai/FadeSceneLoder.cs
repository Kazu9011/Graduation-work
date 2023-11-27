using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class FadeSceneLoder : MonoBehaviour
{
    public Image fadePanel;             // �t�F�[�h�p��UI�p�l��(Image)
    public float fadeDuration = 1.0f;   // �t�F�[�h�����ɂ����鎞��

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
        fadePanel.enabled = true;               // �p�l����L����
        float elapsedTime = 0.0f;               // �o�ߎ��Ԃ�������
        Color startColor = fadePanel.color;     // �t�F�[�h�p�l���̊J�n�F���擾
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // �t�F�[�h�p�l���̍ŏI�F���擾

        // �t�F�[�h�A�E�g�A�j���[�V���������s
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                          // �o�ߎ��Ԃ𑝂₷
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);    // �t�F�[�h�̐i�s�x���v�Z
            fadePanel.color = Color.Lerp(startColor, endColor, t);  // �p�l���̐F��ύX���ăt�F�[�h�A�E�g
            yield return null;                                      // 1�t���[���ҋ@
        }

        fadePanel.color = endColor;     // �t�F�[�h������������ŏI�F�ɐݒ�
        /*SceneManeger.LoadScene("");*/     // �V�[�������[�h(�����ɑJ�ڂ�����SceneName�����)
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
