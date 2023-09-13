using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera tpsCamera; // Kamera TPS
    public Camera fpsCamera; // Kamera FPS

    private bool isFPS = false; // Apakah sedang dalam mode FPS

    void Start()
    {
        // Awalnya, aktifkan kamera TPS dan nonaktifkan kamera FPS
        tpsCamera.enabled = true;
        fpsCamera.enabled = false;
    }

    void Update()
    {
        // Ubah ukuran dan posisi overlap box sesuai dengan posisi pemain
        Vector3 boxCenter = transform.position;
        Vector3 boxSize = new Vector3(2f, 2f, 2f);

        // Pengecekan apakah ada dinding dalam overlap box
        Collider[] colliders = Physics.OverlapBox(boxCenter, boxSize);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Wall")) // Sesuaikan dengan tag dinding Anda
            {
                // Beralih antara mode FPS dan TPS dengan tombol atau kondisi yang sesuai
                if (Input.GetKeyDown(KeyCode.E)) // Ganti mode dengan tombol "C"
                {
                    isFPS = !isFPS;
                    tpsCamera.enabled = !isFPS;
                    fpsCamera.enabled = isFPS;
                }
            }
        }
        
    }
}
