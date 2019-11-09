using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisp;
    [TextArea(3, 10)]
    public string[] sentences;

    public GameObject[] pointDialog;

    private int numberWords;

    public GameObject nextButt;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (pointDialog.Length > numberWords)
        {
            if (player.transform.position.x >= pointDialog[numberWords].transform.position.x - 0.5 && player.transform.position.x <= pointDialog[numberWords].transform.position.x + 0.5)
            {
                textDisp.text = sentences[numberWords];
                Time.timeScale = 0f;
                nextButt.SetActive(true);
                numberWords++;
            }
        }

        if (Input.anyKeyDown && nextButt.activeSelf)
        {
            NextSentence();
        }
    }

    public void NextSentence()
    {
        textDisp.text = "";
        nextButt.SetActive(false);
        Time.timeScale = 1f;
    }
}
