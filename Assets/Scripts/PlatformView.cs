using System.Collections;
using UnityEngine;

public class PlatformView : MonoBehaviour
{
    private Rigidbody _platformRigidbody = default;

    void Start()
    {
        _platformRigidbody = GetComponent<Rigidbody>();
    }

    public void MovePlatform()
    {
        _platformRigidbody.isKinematic = false;
    }

    public void StopPlatform()
    {
        _platformRigidbody.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MoveDownPlatform());
        }
    }

    private IEnumerator MoveDownPlatform()
    {
        yield return new WaitForSeconds(1.5f);
        MovePlatform();
    }
}
