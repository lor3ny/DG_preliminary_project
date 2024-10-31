using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{

    private bool isSeen = false;
    private Vector3 playerPosition;
    private Transform pl;
    private Rigidbody rb;
    private int layerMask;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float shotPower;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        layerMask = ~LayerMask.GetMask("Coins");
        StartCoroutine(WaitAndShoot(1.5f));
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
            }
            else
            {
                isSeen = false;
            }
        }
    }

    IEnumerator WaitAndShoot(float waitTime)
    {
        // Wait for the specified time
        if (isSeen)
        {
            Shoot();
        }
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(WaitAndShoot(2.0f));
    }

    private void Shoot()
    {
        GameObject bull =Instantiate(bullet);
        bull.transform.position = transform.position;
        bull.GetComponent<Rigidbody>().velocity = playerPosition.normalized * shotPower;
    }

}
