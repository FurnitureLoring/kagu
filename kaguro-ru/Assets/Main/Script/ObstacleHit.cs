using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    GameObject Player;
    Player player_s;
    bool Hit;//è·äQï®ÇÃè’ìÀîªíËóp

    void Start()
    {
        Player = GameObject.Find("Player");
        player_s = Player.GetComponent<Player>();

        Hit = false;
        Debug.Log("a");
    }

    void FixedUpdate()
    {
        if(Hit==false)
        {
            player_s.enabled = true;
            Debug.Log("a");
        }
        if (Hit == true)
        {
            player_s.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("a");
            Hit = true;
            StartCoroutine(HitObstacle());   
        }
        if(other.gameObject.CompareTag("MoveObstacle"))
        {
            Hit = true;
            StartCoroutine(HitMoveObstacle());
        }
    }

    IEnumerator HitObstacle()
    {
        yield return new WaitForSeconds(2.0f);
        Hit = false;
    }

    IEnumerator HitMoveObstacle()
    {
        yield return new WaitForSeconds(3.0f);
        Hit = false;
    }
}
