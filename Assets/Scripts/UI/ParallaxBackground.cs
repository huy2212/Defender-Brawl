using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float parallaxEffect;
    private float length;
    private float startpos;
    private float distance;
    private float temp;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void LateUpdate()
    {
        temp = (_cameraTransform.position.x * (1 - parallaxEffect));

        distance = (_cameraTransform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
