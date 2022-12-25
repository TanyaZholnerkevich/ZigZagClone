using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    [SerializeField] private CrystalController _crystalPrefab = default;

    private int _poolCount = 25;
    private PoolObject<CrystalController> _pool;

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        _pool = new PoolObject<CrystalController>(_crystalPrefab, _poolCount, transform);
    }
}
