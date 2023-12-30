using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Data")]
public class AttackData : ScriptableObject
{
    public float Damage;
    public float AttackDelayTime;
    public float Range;
    public LayerMask TargetLayer;
}
