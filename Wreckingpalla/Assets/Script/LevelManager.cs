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
    private TMP_Text livesText;
    private GameObject wonUI;
    private GameObject lostUI;

    [SerializeField]
    private int startingPoints = 0;
    [SerializeField]
    private TMP_Text textPoints;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject playerPrefab;

    public int lives; 


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        pl = GameObject.FindGameObjectWithTag("Player");
        StartFromSpawn();
        coins = GameObject.Find("Coins").GetComponentsInChildren<Transform>().Length-1;
        points = startingPoints;
        wonUI = GameObject.Find("WinUI");
        lostUI = GameObject.Find("LoseUI");
        livesText = GameObject.Find("Lives").GetComponent<TMP_Text>();
        livesText.SetText(lives.ToString());
        wonUI.SetActive(false);
        lostUI.SetActive(false);
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
        livesText.SetText(lives.ToString());
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
    }

    public void LevelLost()
    {

        lostUI.SetActive(true);
        Time.timeScale = 0f;
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
