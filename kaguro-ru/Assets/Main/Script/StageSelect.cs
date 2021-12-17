using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    private float RotateSpeed;

    void Start()
    {
        RotateSpeed = 0.5f;
    }

    void FixedUpdate()
    {
        this.transform.Rotate(0.0f, RotateSpeed, 0.0f);
    }
}
