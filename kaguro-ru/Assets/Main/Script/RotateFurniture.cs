using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFurniture: MonoBehaviour
{
    private float RotateSpeed = 0.5f;  //��]���x

    void FixedUpdate()
    {
        //���g����]������
        this.transform.Rotate(0.0f, RotateSpeed, 0.0f);
    }
}
