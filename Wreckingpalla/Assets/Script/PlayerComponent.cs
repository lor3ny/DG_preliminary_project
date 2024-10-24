using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private Vector3 inputVector;
    int up = 0, right = 0, down = 0, left = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        //int ciao = Input.GetKeyDown(KeyCode.W);

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
        //Debug.Log(inputVector);
    }

    private void FixedUpdate()
    {
        rb.AddForce(inputVector * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("hit");
            Destroy(other.gameObject);
        }
    }
}
