using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piv : MonoBehaviour
{
    public float explosionRadius = 5f; // Radius area efek ledakan granat
    public LayerMask playerLayer; // LayerMask untuk pemain
    public LayerMask wallLayer; // LayerMask untuk tembok

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, playerLayer);

        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("Player"))
            {
                Vector3 toPlayer = hit.transform.position - transform.position;

                // Periksa apakah ada tembok antara granat dan pemain
                if (!Physics.Raycast(transform.position, toPlayer, toPlayer.magnitude, wallLayer))
                {
                    // Tidak ada tembok di antara granat dan pemain, pemain terkena
                    Debug.Log("a");
                }
            }
        }
    }
}
