using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour
{
    public bool lockX, lockY, lockZ;
    private Vector3 startRotation;

    void Start() { startRotation = transform.rotation.eulerAngles; }
    void Update()
    {
        Vector3 newRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(
            lockX ? startRotation.x : newRotation.x,
            lockY ? startRotation.y : newRotation.y,
            lockZ ? startRotation.z : newRotation.z
        );
    }
}