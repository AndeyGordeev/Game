using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordsOfTheAuthor : MonoBehaviour
{
    public TextMeshProUGUI textDisp;
    [TextArea(3, 10)]
    public string[] sentences;

    public float[] pointDialog;
    
    private int numberWords;

    public GameObject nextButt;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pointDialog = new[] {-14f,-4f,15f,24f};//точки на оси ОХ, где включается монолог
    }

    private void FixedUpdate()
    {
        if (pointDialog.Length > numberWords)
        {
            if (player.transform.position.x >= pointDialog[numberWords] - 0.5 && player.transform.position.x <= pointDialog[numberWords] + 0.5)
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
