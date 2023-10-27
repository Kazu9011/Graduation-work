using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerPoint : MonoBehaviour
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
    TextMeshProUGUI playerpoint;
    // Start is called before the first frame update
    void Start()
    {
        currentpoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerpoint = GetComponent<TextMeshProUGUI>();
        playerpoint.text = currentpoint.ToString("0");
    }
}
