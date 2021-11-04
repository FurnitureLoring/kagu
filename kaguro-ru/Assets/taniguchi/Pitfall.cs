using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{
    //テスト用
    public float pitfall_time = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //落とし穴に滞在している時間が長くなると落ちる
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pitfall_time += Time.deltaTime;
        }
    }

    //落とし穴の範囲の外に出ると滞在時間がリセットされる
    void OnTriggerExit(Collider ohter)
    {
        if (ohter.gameObject.CompareTag("Player"))
        {
            pitfall_time = 0;
        }
    }
}
