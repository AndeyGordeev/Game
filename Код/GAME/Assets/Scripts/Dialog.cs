using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisp;
    [TextArea(3, 10)]
    public string[] sentences;
    public float typingSpeed;

    public float[] pointDialog;
    public int[] endingDialog;

    private int id;
    private int numberDialog;

    public GameObject nextButt;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pointDialog = new[] { -4f, 7f };//точки на оси ОХ, где включаются диалоги
        endingDialog = new[] { 0, 2, sentences.Length };/*на кокаой реплике останавливается диалог. 
        То есть если у нас на данный момент прописанно только 5 реплик, 
        то первый диалог будет состоять из первых 2х реплик, а вротой из 3 последующих. 
        */
    }

    private void Update()
    {
        if (pointDialog.Length > numberDialog)
        {
            if (player.transform.position.x >= pointDialog[numberDialog] - 0.5 && player.transform.position.x <= pointDialog[numberDialog] + 0.5)
            {
                StartCoroutine(Type());
                numberDialog++;
            }
        }

        if (textDisp.text == sentences[id])
        {
            nextButt.SetActive(true);
        }
        if (Input.anyKeyDown && nextButt.activeSelf)
        {
            NextSentence();
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[id].ToCharArray())
        {
            textDisp.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        nextButt.SetActive(false);

        if (id < endingDialog[numberDialog] - 1)
        {
            id++;
            textDisp.text = "";
            StartCoroutine(Type());

        }
        else
        {
            textDisp.text = "";
            nextButt.SetActive(false);
            id++;
        }
    }
}
