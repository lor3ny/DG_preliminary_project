using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerBehaviour : MonoBehaviour
{

    [SerializeField]
    private float speed = 1;


    private bool isSeen = false;
    private Vector3 playerPosition;
    private Transform pl;
    private Rigidbody rb;
    private int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        layerMask = ~LayerMask.GetMask("Coins");
    }

    // Update is called once per frame
    void Update()
    {

        playerPosition = pl.position - transform.position;
        Ray ray = new Ray(transform.position, playerPosition);
        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f, Color.red);

        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // Player is hided! Don't follow.
                isSeen = true;
            } else
            {
                isSeen = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isSeen) return;

        rb.AddForce(playerPosition.normalized * speed);
    }
}
