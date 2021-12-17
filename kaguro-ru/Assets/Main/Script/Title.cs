using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private float Speed = 3.5f;             //移動スピード

    void FixedUpdate()
    {
        //前に進む
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Goalに当たると初期位置に戻る
        if(other.gameObject.CompareTag("Goal"))
        {
            transform.position = new Vector3(0.0f, 0.0f, 14.0f);
        }
    }
}
