using UnityEngine;

[RequireComponent(typeof(CameraMovement), typeof(CameraInput))]
public class Camera : MonoBehaviour
{
    private bool _isMovingLeft = false;
    private bool _isMovingRight = false;
    private ICameraMovement cameraMovement;
    private ICameraInput cameraInput;

    void Start()
    {
        cameraMovement = GetComponent<ICameraMovement>();
        cameraInput = GetComponent<ICameraInput>();
    }

    void LateUpdate()
    {
        if (_isMovingLeft)
        {
            cameraMovement.MoveLeft();
        }
        if (_isMovingRight)
        {
            cameraMovement.MoveRight();
        }
    }

    void FixedUpdate()
    {
        if (cameraInput.GetLeftInput())
        {
            _isMovingLeft = true;
            return;
        }
        else if (cameraInput.GetRightInput())
        {
            _isMovingRight = true;
            return;
        }
        else
        {
            _isMovingLeft = false;
            _isMovingRight = false;
        }
    }
}
