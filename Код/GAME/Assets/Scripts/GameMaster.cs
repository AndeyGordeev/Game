using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm;
    public GameObject gameOverUI;

    public static void KillPlayer(Play player)
    {
        Destroy(player);
        gm.EndGame();
    }

    private void Start()
    {
        if (gm == null)
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void EndGame()
    {
        gameOverUI.SetActive(true);
    }

    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy);
    }

}
