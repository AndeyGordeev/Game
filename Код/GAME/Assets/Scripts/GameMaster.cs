using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    private static GameMaster gm;
    public GameObject gameOverUI;
    public GameObject scoreUI;
    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text gameOverScoreText;
    private int score;

    public GameObject CoinPrefab { get => coinPrefab; }
    public int Score
    { 
        get
        {
            return score; 
        }
        set
        {
            scoreText.text = value.ToString(); 
            this.score = value; 
        } 
    }
    public static GameMaster Gm { get => gm; set => gm = value; }

    public static void KillPlayer(Play player)
    {
        Destroy(player);
        gm.EndGame();
    }


    public static void KillBear(BearFollower bear)
    {
        Destroy(bear);
    }
    

    private void Start()
    {
        if (gm == null)
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void EndGame()
    {
        scoreUI.SetActive(false);
        gameOverScoreText.text = string.Format("score: {0}", score);
        gameOverUI.SetActive(true);
    }

    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy);
    }

}
