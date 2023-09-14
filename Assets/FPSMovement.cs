using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Kecepatan pergerakan karakter FPS

    private Transform playerTransform;

    void Start()
    {
        playerTransform = transform;
    }

    void Update()
    {
        // Pergerakan kiri dan kanan hanya saat mode FPS
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);

        // Menggunakan Transform untuk menggerakkan karakter
        playerTransform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
