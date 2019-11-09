using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        StartCoroutine(Example());
    }

    public IEnumerator Example()
    {
        for (int i = 10; i > -1; i--)
        {
            GameObject.Find("Background").GetComponent<Image>().color = new Color(1f, 1f, 1f, i * 0.1f);
            yield return new WaitForSeconds(.3f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
