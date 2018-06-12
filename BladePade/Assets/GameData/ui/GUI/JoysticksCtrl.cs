using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JoysticksCtrl : MonoBehaviour
{    
    [Space(4)] [TextArea] public string description;[Space(4)]
    private Vector3 fingerPos;

    [Header("Target Controls")][Space(10)]
    public GameObject targetJoystickControl;
    public GameObject target;
    public GameObject player;

    [Header("Player Control")]
    public PlayerControl playerControl;
    public Thrower thrower;

    public bool goingLeft;
    public bool goingRight;
    public bool jump; // change to method from player
    public bool hit; // change to method from player
    // Use this for initialization
    private void Start()
    {
        ActivateTrajectoryJoysticks();
    }

    private void ClickedPos()
    {      
        fingerPos = Input.mousePosition;
    }
    public void ActivateTrajectoryJoysticks()
    {
        target.SetActive(!target.activeSelf);
        targetJoystickControl.SetActive(!targetJoystickControl.activeSelf);
    }

    //Trajectory control
    public void Pressed_TargetControl()
    {
        ActivateTrajectoryJoysticks();
        ClickedPos();
        targetJoystickControl.transform.position = new Vector2(fingerPos.x, fingerPos.y);
        target.transform.position = new Vector2(Camera.main.WorldToScreenPoint(player.transform.position).x + (targetJoystickControl.transform.localPosition.x * -1),
                                               Camera.main.WorldToScreenPoint(player.transform.position).y + (targetJoystickControl.transform.localPosition.y * -1));
    }
    public void Dragging_TargetController()
    {
        ClickedPos();
        targetJoystickControl.transform.position = new Vector2(fingerPos.x,fingerPos.y);
        target.transform.position = new Vector2(Camera.main.WorldToScreenPoint(player.transform.position).x + (targetJoystickControl.transform.localPosition.x*-1), 
                                                Camera.main.WorldToScreenPoint(player.transform.position).y + (targetJoystickControl.transform.localPosition.y*-1));
    }
    public void Released_TargetController()
    {
        thrower.Throw(target.transform.position);
        ActivateTrajectoryJoysticks();

        targetJoystickControl.transform.localPosition = new Vector2(0,0);
        target.transform.position = Camera.main.WorldToScreenPoint(player.transform.position)*2;
    }
   
    //Movement control
    public void LeftArrow(){
        playerControl.MoveLeft = !playerControl.MoveLeft;
        playerControl.h = -1;
    }
    public void RightArrow(){
        playerControl.MoveRight = !playerControl.MoveRight;
        playerControl.h = 1;
    }

    //Jump control
    public void JumpButtonPressed()
    {
        playerControl.Jump();
    }
    //Hit controll
    public void HitButton(){
        hit = !hit;
    }

}
