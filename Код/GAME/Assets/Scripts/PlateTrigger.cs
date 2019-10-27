using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateTrigger : MonoBehaviour
{

    public GameObject plateOff;
    public GameObject plateOn;
    public GameObject tree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("Companion"))
        {
            if (tree.activeSelf != false)
            {
                plateOff.SetActive(false);
                plateOn.SetActive(true);
                tree.SetActive(false);
            }
        }
    }
}
