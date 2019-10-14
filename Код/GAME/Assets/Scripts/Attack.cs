using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 25;
    public int attackPower = 200;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int side = 0;
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            AudioManagerScript.PlaySound("playerHit");
            collision.gameObject.GetComponent<Enemy>().DamageEnemy(attackDamage);
            if (FindObjectOfType<BearFollower>().isFacingRight == true) side = 1;
            else side = -1;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * attackPower + (transform.right * attackPower) * side);
        }
    }
}
