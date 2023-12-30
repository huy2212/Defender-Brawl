using UnityEngine;

public class CameraInput : MonoBehaviour, ICameraInput
{
    public bool GetLeftInput()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    public bool GetRightInput()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }
}
