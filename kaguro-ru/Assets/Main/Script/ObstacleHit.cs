using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    GameObject Player;              //Player���̊i�[�ϐ�
    Player player_s;                //Player�X�N���v�g�̏��i�[�ϐ�
    Animation Playeranimation;      //�A�j���[�V�����X�N���v�g�̏��i�[�ϐ�
    bool Hit;                       //��Q���̏Փ˔���p

    void Start()
    {
        //Player�I�u�W�F�N�g�EPlayer�X�N���v�g�̏����擾
        Player = GameObject.Find("Player");
        player_s = Player.GetComponent<Player>();

        //Animation�X�N���v�g�̏����擾
        Playeranimation = GetComponent<Animation>();

        //�Փ˔����false�ŏ�����
        Hit = false;
    }

    void FixedUpdate()
    {
        //�Փ˔��肪false�Ȃ�v���C���[�̈ړ����\
        //true�Ȃ�v���C���[����~
        if(Hit==false)
        {
            player_s.enabled = true;
        }
        if (Hit == true)
        {
            player_s.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //��Q���ɓ�����ƏՓ˔��肪true��
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Hit = true;
            StartCoroutine(HitObstacle());   
        }
        if(other.gameObject.CompareTag("MoveObstacle"))
        {
            Hit = true;
            StartCoroutine(HitObstacle());
        }
    }

    //��Q���ɓ����������ɓ����R���[�`��
    IEnumerator HitObstacle()
    {
        Playeranimation.AnimDamage();
        yield return new WaitForSeconds(2.0f);
        Hit = false;
    }
}
