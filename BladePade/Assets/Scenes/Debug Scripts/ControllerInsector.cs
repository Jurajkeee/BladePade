using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInsector : MonoBehaviour {
    public PlayerControl playerControl;
    public JoysticksCtrl joystickCTRL;
	
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            joystickCTRL.RightArrow();
        } else playerControl.MoveRight = false;
        if (Input.GetKey(KeyCode.A))
        {
            joystickCTRL.LeftArrow();
        } else playerControl.MoveLeft = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerControl.Jump();
        }

    }
}
