using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDgirl : MonoBehaviour
{
    public Sprite[] HealthSprites;

    public Image HealthUI;

    private Play player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Play>();
    }

    void Update()
    {
        HealthUI.sprite = HealthSprites[player.curHealth];
    }
}
