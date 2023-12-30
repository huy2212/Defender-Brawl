using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDetonation : MonoBehaviour
{
    public void Detonate()
    {
        ObjectPoolManager.ReturnObjectToPool(this.gameObject);
    }
}
