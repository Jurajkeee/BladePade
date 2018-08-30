using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInsector : MonoBehaviour {
    [Space(4)] [TextArea] public string description;[Space(4)]
    public PlayerControl playerControl;
    public JoysticksCtrl joystickCTRL;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            joystickCTRL.RightArrowDown();
        } else if(Input.GetKeyUp(KeyCode.D)){
            joystickCTRL.RightArrowUP();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            joystickCTRL.LeftArrowDown();
        } else if (Input.GetKeyUp(KeyCode.A))
        {
            joystickCTRL.LeftArrowUp();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerControl.Jump();
        }

    }
}
