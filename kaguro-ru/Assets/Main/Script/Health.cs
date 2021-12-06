using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int hp;      //主人公のHP
    public bool Hit;    //衝突したか判定用

    void Start()
    {
        Hit = false;
        hp = 5;
    }

    void FixedUpdate()
    {
        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }    
    }

    //障害物にぶつかるとHPが減少
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle")&&Hit==false)
        {
            hp--;
            Hit = true;
            StartCoroutine(CoolTime());
        }
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(2.0f);
        Hit = false;
    }


}
