using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MobileInput : MonoBehaviour
{
    public JoyStick MovementJoyStick;
    public JoyStick LookedJoystick;

    void Update()
    {
        var fps = GetComponent<CharacterControl>();
        fps.RunAxis = MovementJoyStick.InputDirection;
        fps.LookAxis = LookedJoystick.InputDirection;

    }
}
