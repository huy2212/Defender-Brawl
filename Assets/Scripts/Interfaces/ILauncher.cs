using UnityEngine;

public interface ILauncher
{
    public GameObject Projectile { get; set; }
    public void Launch(Transform weapon);
}
