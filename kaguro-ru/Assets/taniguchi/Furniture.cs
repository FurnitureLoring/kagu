using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    GameObject Player;
    GameObject Obstacle;
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
        Obstacle = GameObject.Find("obstacle");
        script = Player.GetComponent<Player>();
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //�v���C���[����ߊl�Q�[�W���擾
        Gauge = script.gauge_test;

        //�O���Ɉړ�
        this.rigidbody.velocity = new Vector3(0, 0, 1f);

        //�O���ɏ�Q��������Ɖ��ɔ�����i�������j
        ////Ray���΂��đO���ɕ��̂����邩���ׂ�
        ////Ray�̍쐬�@�@�@�@�@�@�@��Ray���΂����_�@�@�@��Ray���΂�����
        //Ray ray = new Ray(transform.position, new Vector3(0, -1, 10));

        //RaycastHit hit;
        ////Ray�̔�΂��鋗��
        //int distance = 20;

        ////Ray����
        //Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);

        ////����Ray�ɃI�u�W�F�N�g���Փ˂�����
        ////                  ��Ray  ��Ray�����������I�u�W�F�N�g ������
        //if (Physics.Raycast(ray,out hit, distance))
        //{
        //    if(hit.collider.tag == "Obstacle")
        //    {
        //        this.rigidbody.velocity = new Vector3(1.0f, 0, 0);
        //    }
        //}


        //�ߊl�Q�[�W���ݒ肳�ꂽ�l�𒴂���Ǝ��g���폜
        if (Gauge > Gauge_MAX)
        {
            Destroy(this.gameObject);
        }
    }
}
