using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    GameObject Player;
    Rigidbody rigidbody;
    Player script;
    private float Gauge;

    //�e�X�g�p
    public float Speed = 2.0f;//�ړ��X�s�[�h
    private float Gauge_MAX = 1;//�ߊl�Q�[�W

    void Start()
    {
        //�v���C���[�̏���T���Ď擾
        Player = GameObject.Find("Player");
        script = Player.GetComponent<Player>();
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //�v���C���[����ߊl�Q�[�W���擾
        Gauge = script.gauge_test;

        //�O���Ɉړ�
        this.rigidbody.velocity = new Vector3(0, 0, 1f);

        //�ߊl�Q�[�W���ݒ肳�ꂽ�l�𒴂���Ǝ��g���폜
        if (Gauge > Gauge_MAX)
        {
            Destroy(this.gameObject);
        }
    }
}
