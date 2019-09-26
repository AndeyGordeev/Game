using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 25;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().DamageEnemy(attackDamage);
            if (FindObjectOfType<BearFollower>().isFacingRight == true)
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 200 + (transform.right * 200));
            else
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 200 + (transform.right * 200) * -1);
        }
    }
}
