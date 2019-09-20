using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDB : MonoBehaviour
{
    public Sprite[] HealthSprite;

    public Image HealthB;

    private BearFollower bear;

    void Start()
    {
        bear = GameObject.FindGameObjectWithTag("Companion").GetComponent<BearFollower>();
    }

    void Update() 
    {
        HealthB.sprite = HealthSprite[bear.curHealth];
    }
}
