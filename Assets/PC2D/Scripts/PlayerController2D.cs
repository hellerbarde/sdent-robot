
using UnityEngine;

/// <summary>
/// This class is a simple example of how to build a controller that interacts with PlatformerMotor2D.
/// </summary>
[RequireComponent(typeof(PlatformerMotor2D))]
public class PlayerController2D : MonoBehaviour
{
    private PlatformerMotor2D _motor;

    // Use this for initialization
    void Start()
    {
        _motor = GetComponent<PlatformerMotor2D>();
    }

    // Update is called once per frame
    void Update()
    {

//        _motor.normalizedXMovement = Input.GetAxis(PC2D.Input.HORIZONTAL) > 0 ?
//           1 :
//           Input.GetAxis(PC2D.Input.HORIZONTAL) < 0 ? -1 : 0;
//
//        if (Input.GetKey(KeyCode.RightArrow)){
//            _motor.normalizedXMovement = 1;
//        }
//        else if (Input.GetKey(KeyCode.LeftArrow)) {
//            _motor.normalizedXMovement = -1;
//        }
//        else {
//            _motor.normalizedXMovement = 0;
//        }

        if (Mathf.Abs(Input.GetAxis(PC2D.Input.HORIZONTAL)) > PC2D.Globals.INPUT_THRESHOLD)
        {
            _motor.normalizedXMovement = Input.GetAxis(PC2D.Input.HORIZONTAL);
        }
        else
        {
            _motor.normalizedXMovement = 0;
        }

        // Jump?
        if (Input.GetButtonDown(PC2D.Input.JUMP))
        {
            _motor.Jump();
        }

        _motor.jumpingHeld = Input.GetButton(PC2D.Input.JUMP);

        if (Input.GetAxis(PC2D.Input.VERTICAL) < -PC2D.Globals.FAST_FALL_THRESHOLD)
        {
            _motor.fallFast = true;
        }
        else
        {
            _motor.fallFast = false;
        }

        if (Input.GetButtonDown(PC2D.Input.DASH))
        {
            _motor.Dash();
        }
    }
}
