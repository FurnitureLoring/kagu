using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{
    //�e�X�g�p
    public float pitfall_time = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //���Ƃ����ɑ؍݂��Ă��鎞�Ԃ������Ȃ�Ɨ�����
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pitfall_time += Time.deltaTime;
        }
    }

    //���Ƃ����͈̔͂̊O�ɏo��Ƒ؍ݎ��Ԃ����Z�b�g�����
    void OnTriggerExit(Collider ohter)
    {
        if (ohter.gameObject.CompareTag("Player"))
        {
            pitfall_time = 0;
        }
    }
}
