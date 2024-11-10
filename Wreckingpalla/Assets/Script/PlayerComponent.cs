using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public float speed = 0;
    public Transform spawnPoint;
    public AudioClip deathSound;
    public AudioClip walkSound;
    public AudioClip coinSound;
    public AudioClip hitSound;

    private Rigidbody rb;
    private Animator anim;
    private LevelManager levelManager;
    private float movementX;
    private float movementY;
    private Vector3 inputVector;
    private AudioSource audioSource;
    int up = 0, right = 0, down = 0, left = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        audioSource = GetComponent<AudioSource>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
            up = 1;

        if (Input.GetKeyDown(KeyCode.D))
            right = 1;

        if (Input.GetKeyDown(KeyCode.S))
            down = -1;

        if (Input.GetKeyDown(KeyCode.A))
            left = -1;

        if (Input.GetKeyUp(KeyCode.W))
            up = 0;

        if (Input.GetKeyUp(KeyCode.D))
            right = 0;

        if (Input.GetKeyUp(KeyCode.S))
            down = 0;

        if (Input.GetKeyUp(KeyCode.A))
            left = 0;


        inputVector = new Vector3(left+right, 0.0f, up+down);
    }

    private void FixedUpdate()
    {
        rb.AddForce(inputVector * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(coinSound, 0.5f);
            levelManager.IncreasePoint();
        }
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Dead!");
            Destroy(other.gameObject);
            levelManager.DecreaseLives();
            if(levelManager.GetLives() == 0)
            {
                audioSource.PlayOneShot(deathSound);
                levelManager.LevelLost();
            } else
            {
                audioSource.PlayOneShot(hitSound);
            }

            //levelManager.StartFromSpawn();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Dead!");
            levelManager.DecreaseLives();
            if (levelManager.GetLives() == 0)
            {
                audioSource.PlayOneShot(deathSound);
                levelManager.LevelLost();
            }
            else
            {
                audioSource.PlayOneShot(hitSound);
            }
            //levelManager.StartFromSpawn();
        }
    }
}
