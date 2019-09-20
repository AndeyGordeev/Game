using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{

    public float speed;
    public GameObject tar;
    public float findingDist;
    public float stopDist;

    private Transform target;

    // Start is called before the first frame update
    private void Start()
    {
        target = tar.GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        FindTarget();
        float dist = Vector2.Distance(transform.position, target.position);
        if (dist <= findingDist && dist > stopDist)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        else if (dist <= stopDist)
            transform.position = Vector2.MoveTowards(transform.position, target.position, 0);

    }
    private void FindTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
