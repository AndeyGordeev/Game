using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSetOn : MonoBehaviour
{

    public GameObject plateOff;
    public GameObject plateOn;
    public GameObject tree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("Companion"))
        {
            if (tree.activeSelf != true)
            {
                plateOff.SetActive(true);
                plateOn.SetActive(false);
                tree.SetActive(true);
            }
        }
    }
}
