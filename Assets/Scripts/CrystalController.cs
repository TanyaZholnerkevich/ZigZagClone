using System;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    [SerializeField] private bool isRotating = false;

    [SerializeField] private Vector3 rotationAngle;
    [SerializeField] private float rotationSpeed;

    public event Action OnCollectCrystal;

    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OnCollectCrystal?.Invoke();
        gameObject.SetActive(false);
    }
}
