using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFurniture: MonoBehaviour
{
    private float RotateSpeed = 0.5f;  //回転速度

    void FixedUpdate()
    {
        //自身を回転させる
        this.transform.Rotate(0.0f, RotateSpeed, 0.0f);
    }
}
