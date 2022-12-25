using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _target = default;
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _target.transform.position;
    }

    void Update()
    {
        transform.position = _target.transform.position + _offset;
        transform.LookAt(_target.transform);
    }
}
