using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestruction : MonoBehaviour
{

    ParticleSystem ps;
    MeshRenderer meshRenderer;
    TrailRenderer trailRenderer;
    private void Awake()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        meshRenderer = GetComponent<MeshRenderer>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Autodestroy();
        }
    }

    public void Autodestroy()
    {
        StartCoroutine(DestructionCoroutine());
    }

    IEnumerator DestructionCoroutine()
    {
        ps.Play();
        meshRenderer.enabled = false;
        trailRenderer.enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(gameObject);
    }
}
