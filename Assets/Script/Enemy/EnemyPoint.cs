using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyPoint : MonoBehaviour
{
    private int currentpoint;
    public int CurrentPoint
    {
        get
        {
            return currentpoint;
        }
        set
        {
            currentpoint = value;
        }
    }
    TextMeshProUGUI enemypoint;
    // Start is called before the first frame update
    void Start()
    {
        currentpoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemypoint = GetComponent<TextMeshProUGUI>();
        enemypoint.text = currentpoint.ToString("0");
    }
}
