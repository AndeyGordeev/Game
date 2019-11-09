using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public GameObject player;
    public GameObject bearFollower;
    public Transform spawnPoint;
    private static GameMaster gm;
    public GameObject gameOverUI;
    public GameObject scoreUI;
    public GameObject lifeUI;
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
    private Play playerScript;
    private BearFollower bearScript;


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

    public static void KillPlayer()
    {
        if (gm.lifeCount <= 1) //хз, что не так
        {
            gm.EndGame();
        }
        else
        {
            gm.RespawnPlayer();
        }
    }

    public static void KillBear(GameObject bear)
    {
        bear.SetActive(false);
    }

    public void RespawnPlayer()
    {
        //перемещение девочки на позицию респавна и восстановление хп
        player.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        playerScript = FindObjectOfType<Play>();
        playerScript.health = 100f;
        playerScript.UpdateHealth();
        if (!playerScript.isFacingRight) playerScript.Flip();

        //перемещение мишки на позицию респавна и восстановление хп
        if (!bearFollower.activeSelf) bearFollower.SetActive(true);
        bearScript = FindObjectOfType<BearFollower>();
        if (SceneManager.GetActiveScene().buildIndex == 2)
            bearFollower.transform.position = new Vector3(26, -1, 0);
        else
        {
            bearFollower.transform.position = new Vector3(spawnPoint.position.x + 2, spawnPoint.position.y, spawnPoint.position.z);
            if (!bearScript.isFacingRight) bearScript.Flip();
        }
        bearScript.health = 100f;
        bearScript.UpdateHealth();
        bearScript.isAttacking = false;
        bearScript.attackHitBox.SetActive(false);
        bearScript.movementBlock = false;
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
        lifeUI.SetActive(false);
        gameOverScoreText.text = string.Format("Счет: {0}", score);
        gameOverUI.SetActive(true);
        Destroy(bearFollower);
        Destroy(player);
    }

    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

}
