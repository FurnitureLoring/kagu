using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int hp;      //ålŒö‚ÌHP
    public bool Hit;    //Õ“Ë‚µ‚½‚©”»’è—p

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

    //áŠQ•¨‚É‚Ô‚Â‚©‚é‚ÆHP‚ªŒ¸­
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
