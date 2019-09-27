using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public StatusIndicator statusIndicator;
    public int attackPower = 1000;
    public int healthMax = 100;
    private int _healthCur = 100;
    public int healthCur
    {
        get { return _healthCur; }
        set { _healthCur = Mathf.Clamp(value, 0, healthMax);  }
    }

    private Play player;
    private BearFollower bear;

    private void Start()
    {
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(healthCur, healthMax);
        }
        player = FindObjectOfType<Play>();
        bear = FindObjectOfType<BearFollower>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player.DamagePlayer(25f);
            Knockback(collision);
        }

        if (collision.gameObject.tag.Equals("Companion") && bear.isAttacking == false)
        {
            bear.DamagePlayer(25f);
            Knockback(collision);
        }
    }

    private void Knockback(Collision2D collision)
    {
        int side = 0;
        if ((transform.position.x - collision.gameObject.transform.position.x) <= 0) side = 1; //если персонаж правее(координата х противника - персонажа = отрицательное значение) то толкать вправо
        else side = -1;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * attackPower / 1.5f + (transform.right * attackPower) * side * 3);
    }

    public void DamageEnemy(int damage)
    {
        healthCur -= damage;
        if (healthCur <= 0)
        {
            GameMaster.KillEnemy(this);
        }

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(healthCur, healthMax);
        }
    }
}
