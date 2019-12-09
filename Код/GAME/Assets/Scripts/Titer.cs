using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titer : MonoBehaviour
{
    public float sec;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(sec);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
