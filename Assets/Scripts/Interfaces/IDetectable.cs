using UnityEngine;
public interface IDetectable
{
    public float Range { get; set; }
    public bool CanDetect { get; set; }
    public LayerMask TargetLayer { get; set; }
    public GameObject Target { get; }
    public void DetectTargets();
    public event System.Action OnTargetDetected;
    public event System.Action OnTargetLost;
}
