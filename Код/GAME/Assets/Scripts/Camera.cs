using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector2 vector;

    public float timeY;
    public float timeX;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref vector.x, timeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref vector.y, timeY);

        transform.position = new Vector3( posX, posY+0.5f, transform.position.z); 
    }
}
