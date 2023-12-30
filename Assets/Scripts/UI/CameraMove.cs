using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private void Update()
    {
        transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime, Space.World);
    }
}
