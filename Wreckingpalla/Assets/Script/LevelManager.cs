using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LevelManager : MonoBehaviour
{

    private int coins;
    private int points;
    private GameObject pl;

    [SerializeField]
    private int startingPoints = 0;
    [SerializeField]
    private TMP_Text textPoints;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //pl = Instantiate(playerPrefab);
        pl = GameObject.FindGameObjectWithTag("Player");
        StartFromSpawn();
        coins = GameObject.Find("Coins").GetComponentsInChildren<Transform>().Length-1;
        points = startingPoints;
    }

    public void StartFromSpawn()
    {
        pl.transform.position = spawnPoint.position;
    }

    public void IncreasePoint()
    {
        points += 1;
        textPoints.text = points.ToString();
        if (points == coins)
        {
            Debug.Log("Level Finished!");
        }
    }

}
