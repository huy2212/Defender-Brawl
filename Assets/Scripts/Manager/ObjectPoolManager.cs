using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();
    private GameObject _emptyPooledHolder;
    private static GameObject _particleSystemHolder;
    private static GameObject _gameObjectHolder;
    public enum PoolType
    {
        ParticleSystem,
        GameObject,
        None
    }

    private void Awake()
    {
        ObjectPools.Clear();
        SetupHolder();
    }

    private void SetupHolder()
    {
        _emptyPooledHolder = new GameObject("Pooled Objects");

        _particleSystemHolder = new GameObject("Particle System");
        _particleSystemHolder.transform.SetParent(_emptyPooledHolder.transform);

        _gameObjectHolder = new GameObject("Game Objects");
        _gameObjectHolder.transform.SetParent(_emptyPooledHolder.transform);
    }

    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation, PoolType poolType = PoolType.None)
    {
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookUpString == objectToSpawn.name);

        if (pool == null)
        {
            // if pool has not been created
            pool = new PooledObjectInfo() { LookUpString = objectToSpawn.name };
            ObjectPools.Add(pool);
        }

        // check if there is any inactive object in the pool
        GameObject spawnableObject = pool.InactiveObject.FirstOrDefault();

        if (spawnableObject == null)
        {
            // if there is no inactive game object then create a new one
            spawnableObject = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
            GameObject parentObject = GetParentObject(poolType);
            spawnableObject.transform.SetParent(parentObject.transform);
        }
        else
        {
            // if there is then remove that from inactive list
            spawnableObject.transform.position = spawnPosition;
            spawnableObject.transform.rotation = spawnRotation;
            pool.InactiveObject.Remove(spawnableObject);
            spawnableObject.SetActive(true);
        }
        return spawnableObject;
    }

    public static void ReturnObjectToPool(GameObject obj)
    {
        string objName = "";
        if (obj.name.Length > 7)
        {
            objName = obj.name.Substring(0, obj.name.Length - 7); // remove (Clone) from the string
        }
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookUpString == objName);

        if (pool != null)
        {
            IPoolable iPoolable = obj.GetComponent<IPoolable>();
            if (iPoolable != null)
            {
                iPoolable.IsPooled = true;
            }
            pool.InactiveObject.Add(obj);
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(false);
        }
    }

    public static IEnumerator ReturnObjectToPool(GameObject obj, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        ReturnObjectToPool(obj);
    }

    public static GameObject GetParentObject(PoolType poolType)
    {
        switch (poolType)
        {
            case PoolType.GameObject:
                return _gameObjectHolder;
            case PoolType.ParticleSystem:
                return _particleSystemHolder;
            case PoolType.None:
                return null;
            default:
                return null;
        }
    }
}

public class PooledObjectInfo
{
    public string LookUpString;
    public List<GameObject> InactiveObject = new List<GameObject>();
}
