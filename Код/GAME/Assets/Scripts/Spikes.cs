using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Play player;
    private BearFollower bear;

    private void Start()
    {
        player = FindObjectOfType<Play>();
        bear = FindObjectOfType<BearFollower>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player.DamagePlayer(player.health);
        }
        if (collision.gameObject.tag.Equals("Companion"))
        {
            bear.DamagePlayer(bear.health);
        }
    }
}
