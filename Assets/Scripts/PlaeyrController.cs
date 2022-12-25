using UnityEngine;

public class PlaeyrController : MonoBehaviour
{
    private Vector3 _direction = default;
    private int _pressesCount = default;
    private float _speed = default;

    void Start()
    {
        _direction = Vector3.forward;
        _speed = 3f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
            _pressesCount++;
        }

        if(_pressesCount > 0)
        {
            MovePlayer();
        }
        if(gameObject.transform.position.y < 2.5f)
        {
            _speed = 0f;
        }
    }

    private void MovePlayer()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    private void ChangeDirection()
    {
        var fwd = Vector3.forward;
        var right = Vector3.right;
        if(_direction == fwd)
        {
            _direction = right;
        }
        else
        {
            _direction = fwd;
        }
    }
}
