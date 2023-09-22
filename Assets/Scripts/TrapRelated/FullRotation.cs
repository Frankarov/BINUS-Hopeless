using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullRotation : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 0f, 50f);

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
        //rotationSpeed.z = 50f;
    }
}
