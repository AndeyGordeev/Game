using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public Transform player;
    public Transform bearFollower;
    public Transform spawnPoint;
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
    [SerializeField]
    private GameObject lifePrefab;
    private int lifeCount = 3;
    [SerializeField]
    private Text lifesText;


    public GameObject CoinPrefab { get => coinPrefab; }
    public GameObject LifePrefab { get => lifePrefab; }
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
    public int LifeCount
    {
        get
        {
            return lifeCount;
        }
        set
        {
            this.lifeCount = value;
            lifesText.text = value.ToString();
        }
    }
    public static GameMaster Gm { get => gm; set => gm = value; }

    public static void KillPlayer(Play player)
    {
        Destroy(player.gameObject);
        Destroy(GameObject.FindGameObjectWithTag("Companion"));
        if (gm.lifeCount <= 1) //хз, что не так
        {
            gm.EndGame();
        }
        else
        {
            gm.RespawnPlayer();
        }
    }


    public static void KillBear(BearFollower bear)
    {
        Destroy(bear.gameObject);
    }

    public void RespawnPlayer()
    {
        Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        Instantiate(bearFollower, new Vector3(player.position.x + 2, player.position.y, player.position.z), spawnPoint.rotation);
    }
    private void Start()
    {
        lifesText.text = lifeCount.ToString();
        if (gm == null)
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    public void EndGame()
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
