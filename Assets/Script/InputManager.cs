using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Vector2 _leftStickVal;
    Vector2 _stickRightVal;

    public Vector2 LeftStickVal => _leftStickVal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _leftStickVal = new Vector2(Input.GetAxis("L_Stick_H"), Input.GetAxis("L_Stick_V"));
    }

    public bool LStickDawn(float val)
    {
        return _leftStickVal.y < -val;
    }

    public bool LStickUp(float val)
    {
        return _leftStickVal.y < val;
    }

    public bool LStickLeft(float val)
    {
        return _leftStickVal.x < -val;
    }

    public bool LStickRight(float val)
    {
        return _leftStickVal.x < val;
    }
}
