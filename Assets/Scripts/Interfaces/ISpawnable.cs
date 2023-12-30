using UnityEngine;
public interface ISpawnable
{
    bool IsSucceedSpawn { get; set; }
    float CoolDownTime { get; set; }
    GameObject SpawnedObject { get; set; }
    void Spawn();
}
