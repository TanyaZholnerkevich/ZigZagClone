using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatformView : MonoBehaviour
{
    private Rigidbody _platformRigidbody = default;


    void Start()
    {
        _platformRigidbody = gameObject.GetComponent<Rigidbody>();
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MovePlatform());
        }
    }

    private IEnumerator MovePlatform()
    {
        yield return new WaitForSeconds(1f);
        _platformRigidbody.isKinematic = false;

        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
