using UnityEngine;
public class CameraMovement : MonoBehaviour, ICameraMovement
{
    [SerializeField] private float _leftBound;
    [SerializeField] private float _rightBound;
    [SerializeField] private float _speed;

    public void MoveLeft()
    {
        if (transform.position.x < _leftBound)
        {
            return;
        }
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }

    public void MoveRight()
    {
        if (transform.position.x > _rightBound)
        {
            return;
        }
        transform.Translate(Vector2.right * _speed * Time.deltaTime, Space.World);
    }
}
