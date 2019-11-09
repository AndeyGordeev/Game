using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSetOn : MonoBehaviour
{

    public GameObject plateOff;
    public GameObject plateOn;
    public GameObject tree;
    private bool isBearStanding = false;
    private bool isPlayerStanding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Companion")) isBearStanding = true;
        if (collision.gameObject.tag.Equals("Player")) isPlayerStanding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Companion")) isBearStanding = false;
        if (collision.gameObject.tag.Equals("Player")) isPlayerStanding = false;

        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("Companion"))
        {
            if (!isBearStanding && !isPlayerStanding)
            {
                plateOff.SetActive(true);
                plateOn.SetActive(false);
                tree.SetActive(true);
            }
        }
    }
}
