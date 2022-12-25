using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private PlatformView _platformPrefab = default;
    [SerializeField] private StartPlatformView _startPlatform = default;
    [SerializeField] private Transform _startPos = default;
    [SerializeField] private PlaeyrController _player = default;
    [SerializeField] private Transform _playerStartPos = default;

    private int _poolCount = 50;
    private PoolObject<PlatformView> _pool;
    private float _timeToSpawn = 1f;

    private float _posX = 0f;
    private float _posZ = 0f;

    private void Start()
    {
        _pool = new PoolObject<PlatformView>(_platformPrefab, _poolCount, transform);
        Instantiate(_startPlatform, _startPos);
        Instantiate(_player, _playerStartPos);
    }

    private void Update()
    {
        _timeToSpawn -= Time.deltaTime;
        if (_timeToSpawn < 0)
        {
            CreatePlatform();
            _timeToSpawn = 1f;
        }
    }

    private void CreatePlatform()
    {
        var countX = Random.Range(1, 5);
        for(int i = 0; i < countX; i++)
        {
            _posX++;
            var rx = _posX;
            var rz = _posZ;
            var ry = 0f;

            var pos = new Vector3(rx, ry, rz);
            var platform = _pool.GetElement();
            platform.StopPlatform();
            platform.transform.position = pos;
        }

        var countZ = Random.Range(0, 4);
        for (int i = 0; i < countZ; i++)
        {
            _posZ++;
            var rx = _posX;
            var rz = _posZ;
            var ry = 0f;

            var pos = new Vector3(rx, ry, rz);
            var platform = _pool.GetElement();
            platform.StopPlatform();
            platform.transform.position = pos;
        }

    }

    IEnumerator StartMoveDowm(PlatformView platform, Vector3 pos)
    {
        platform.MovePlatform();
        yield return new WaitForSeconds(1f);
        platform.StopPlatform();
        platform.transform.position = pos;
    }
}
