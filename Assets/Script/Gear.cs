using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GearPart
{
    Head,
    Body,
    Leg,
    Max
};


public class Gear : MonoBehaviour
{
    int _type;

    int _defense;

    public int Defense => _defense;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
