using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MobileInput : MonoBehaviour
{
    public JoyStick MovejoyStick;
    public JoyStick LookjoyStick;

    private void Update()
    {
        var fps = GetComponent<CharacterControl>();
        fps.RunAxis = MovejoyStick.InputDirection;
        fps.LookAxis = LookjoyStick.InputDirection;

    }
}
