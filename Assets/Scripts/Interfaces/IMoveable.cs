using UnityEngine;

public interface IMoveable
{
    public bool IsFacingRight { get; set; }
    public bool CanMove { get; set; }
    public float MoveSpeed { get; set; }
    public void MoveForward();
    public void MoveBackward();
    public void SetDefaultMoveSpeed();
}
