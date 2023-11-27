using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Blinker : MonoBehaviour
{
    //�C���X�y�N�^�[����ݒ肷�邩�A����������GetComponent���āATextMeshProUGUI�ւ̎Q�Ƃ��擾���Ă����B
    [SerializeField]
    TextMeshProUGUI tmp;

    [Header("1���[�v�̒���(�b�P��)")]
    [SerializeField]
    [Range(0.1f, 10.0f)]
    float duration = 1.0f;

    //�J�n���̐F�B
    [Header("���[�v�J�n���̐F")]
    [SerializeField]
    Color32 startColor = new Color32(255, 255, 255, 255);

    //�I��(�܂�Ԃ�)���̐F�B
    [Header("���[�v�I�����̐F")]
    [SerializeField]
    Color32 endColor = new Color32(255, 255, 255, 64);

    GameObject Canvas;
    FadeSceneLoder fadeSceneLoder;

    [SerializeField]
    private FadeSceneLoder m_fade = null;
    bool is_fadeout = false;
    

    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
        fadeSceneLoder = Canvas.GetComponent<FadeSceneLoder>();

        Action on_completed = () =>
        {
            is_fadeout = true;
        };
        m_fade.FadeIn(2.0f, on_completed);
    }

    //�C���X�y�N�^�[����ݒ肵���ꍇ�́AGetComponent����K�v���Ȃ��Ȃ�ׁAAwake���폜���Ă��ǂ��B
    void Awake()
    {
        if (tmp == null)
            tmp = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        tmp.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));

        if(is_fadeout == true && Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(Wait3SecondSAndFadeOut());
        }
    }
    private IEnumerator Wait3SecondSAndFadeOut()
    {
        yield return new WaitForSeconds(0.5f);
        m_fade.FadeOut(1.0f);
        is_fadeout = false;
    }
}
