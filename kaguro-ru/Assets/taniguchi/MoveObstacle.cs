using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    private float time;
    private float vecX;
    private float vecZ;
    private bool isUp;

    void Start()
    {
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            if (!isUp)
            {
                isUp = true;
                StartCoroutine(Move());
            }
            //public‚Å“ü—Í‚µ‚½’l‚©‚çŽæ“¾‚·‚é”z—ñ‚Ì—v‘f‚ð•Ï‚¦‚é
            time = Random.Range(0.0f, 10.0f);
        }
    }

    IEnumerator Move()
    {
        for (int i = 0; i < 120; i++)
        {
            transform.Translate(0.1f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }

        for (int i = 0; i < 120; i++)
        {
            transform.Translate(-0.1f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }
        isUp = false;
    }
}
