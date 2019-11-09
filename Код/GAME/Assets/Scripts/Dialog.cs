using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text textDisp;
    [TextArea(3, 10)]
    public string[] sentences;
    public float typingSpeed;

    public GameObject[] pointDialog;
    public int[] endingDialog;

    private int id;
    private int numberDialog;

    public GameObject nextButt;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //endingDialog = new[] {0, 5};
        /*на какой реплике останавливается диалог. 
        То есть если у нас на данный момент прописанно только 5 реплик, 
        то первый диалог будет состоять из первых 2х реплик, а вротой из 3 последующих. 
        */
    }

    private void FixedUpdate()
    {
        if (pointDialog.Length > numberDialog)
        {
            if (player.transform.position.x >= pointDialog[numberDialog].transform.position.x - 0.5 && player.transform.position.x <= pointDialog[numberDialog].transform.position.x + 0.5)
            {
                textDisp.text = sentences[id];
                Time.timeScale = 0f;
                nextButt.SetActive(true);
                //StartCoroutine(Type());
                numberDialog++;
            }
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
            textDisp.text = sentences[id];
            nextButt.SetActive(true);
            //StartCoroutine(Type());

        }
        else
        {
            Time.timeScale = 1f;
            textDisp.text = "";
            nextButt.SetActive(false);
            id++;
            BearActivate();
        }
    }

    private void BearActivate()
    {
        if (numberDialog == 1)
        {
            BearFollower bear = FindObjectOfType<BearFollower>();
            bear.canMove = true;
            bear.Flip();
        }
    }
}
