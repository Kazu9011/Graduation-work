using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Threading.Tasks;
public class Circle : MonoBehaviour
{
    public Image progressRing;
    public float waitTime = 2.0f;
    public float finishDelay = 1.0f;

    private bool progress;

    public Action OnFinish;

    // Start is called before the first frame update
    void Start()
    {
        CancelTimer();
    }
    async Task Update()
    {
        if (progress)
        {
            progressRing.fillAmount += 1.0f / waitTime * Time.deltaTime;
            if (1 <= progressRing.fillAmount)
            {
                progress = false;
                await Task.Delay((int)(finishDelay * 1000));
                progressRing.fillAmount = 0;
                OnFinish.Invoke();
            }
        }
    }
    // Update is called once per frame
    //void Update()
    //{
    //    
    //}
    public void StartTimer()
    {
        progress = true;
    }

    public void CancelTimer()
    {
        progressRing.fillAmount = 0;
        progress = false;
    }
}
