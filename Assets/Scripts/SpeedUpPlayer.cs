using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPlayer : MonoBehaviour
{
    public ObstacleMove move;
    public float addSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MiniGamePlayer")
        {
            collision.GetComponent<BattlePlayer>().speed += addSpeed;
            move.speed += addSpeed;
        }
    }
}
