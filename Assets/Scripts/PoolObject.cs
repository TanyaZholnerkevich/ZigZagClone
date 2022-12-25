using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject<T> where T : MonoBehaviour
{
    private int _lastIndex = 0;
    private int _count;
    public T Prefab { get; }
    public Transform Container { get; }

    private List<T> _pool;

    public PoolObject(T prefab, int count)
    {
        Prefab = prefab;
        _count = count;
        Container = null;

        CreatePool(count);
    }

    public PoolObject(T prefab, int count, Transform container)
    {
        Prefab = prefab;
        _count = count;
        Container = container;

        CreatePool(count);
    }

    public void CreatePool(int count)
    {
        _pool = new List<T>();

        for(int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActive = true)
    {
        var createdObject = UnityEngine.Object.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isActive);

        _pool.Add(createdObject);
        return createdObject;
    }

    public T GetElement()
    {
        var pool = _pool[_lastIndex];
        _lastIndex++;
        if(_lastIndex >= _count)
        {
            _lastIndex = 0;
        }

        return pool;
    }
}
