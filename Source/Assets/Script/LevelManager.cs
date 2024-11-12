using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

    private int coins;
    private int points;
    private GameObject pl;
    private GameObject wonUI;
    private GameObject lostUI;
    private GameObject gameUI;
    private int maxLives;
    private int lives;

    [SerializeField]
    private int startingPoints = 0;
    [SerializeField]
    private TMP_Text textPoints;
    [SerializeField]
    private TMP_Text maxTextPoints;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject playerPrefab;

    public GameObject[] livesImages;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        pl = GameObject.FindGameObjectWithTag("Player");
        StartFromSpawn();
        coins = GameObject.FindGameObjectsWithTag("Coin").Length;
        points = startingPoints;
        wonUI = GameObject.Find("WinUI");
        lostUI = GameObject.Find("LoseUI");
        gameUI = GameObject.Find("GameUI");
        lives = livesImages.Length;
        maxLives = livesImages.Length;
        wonUI.SetActive(false);
        lostUI.SetActive(false);
        gameUI.SetActive(true);
        maxTextPoints.SetText(coins.ToString());
    }

    public int GetLives()
    {
        return lives;
    }

    public void StartFromSpawn()
    {
        pl.transform.position = spawnPoint.position;
    }

    public void DecreaseLives()
    {
        lives -= 1;
        for(int i = lives; i<maxLives; i++)
        {
            livesImages[i].SetActive(false);
        }
    }

    public void IncreasePoint()
    {
        points += 1;
        textPoints.text = points.ToString();
        if (points == coins)
        {
            LevelWon();
        }
    }

    public void LevelWon()
    {
        Time.timeScale = 0f;
        wonUI.SetActive(true);
        gameUI.SetActive(false);
    }

    public void LevelLost()
    {
        Time.timeScale = 0f;
        gameUI.SetActive(false);
        lostUI.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
