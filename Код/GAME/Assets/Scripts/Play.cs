using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public float move = 50f;
    public float jump = 200f;
    public float maxSpeed = 3;
    
    public bool grounded;

    private Rigidbody2D pp;

    void Start()
    {
        pp = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //jump
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            pp.AddForce(Vector2.up * jump);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");//+-1
        pp.AddForce(Vector2.right * move * h);//добавляет возможность передвижения вправо\влево
        //Ограничение скорости
        if (pp.velocity.x > maxSpeed)
        {
            pp.velocity = new Vector2(maxSpeed, pp.velocity.y);
        }

        if (pp.velocity.x < -maxSpeed)
        {
            pp.velocity = new Vector2(-maxSpeed, pp.velocity.y);
        }
    }
}
