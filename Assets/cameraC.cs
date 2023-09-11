using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCameraManager : MonoBehaviour
{
    private Camera tpsCamera; // Kamera TPS
    private Camera wallCamera; // Kamera dinding
    private bool nearWall = false; // Status player berdekatan dengan dinding

    void Start()
    {
        // Temukan kamera TPS dan kamera dinding dalam proyek
        tpsCamera = Camera.main; // Ganti ini dengan kamera TPS Anda jika perlu
        wallCamera = GameObject.FindGameObjectWithTag("WallCamera").GetComponent<Camera>();

        // Nonaktifkan kamera dinding saat awal
        wallCamera.enabled = false;
    }

    void Update()
    {
        // Mendeteksi apakah player berdekatan dengan dinding dengan raycast dari pemain
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f)) // Raycast dimulai dari posisi pemain dan mengikuti arah pandangan pemain
        {
            if (hit.collider.CompareTag("Walls")) // Pastikan dinding memiliki tag "Wall"
            {
                nearWall = true;

                // Menampilkan pesan "Tekan E untuk mengganti kamera" jika player dekat dengan dinding
                // Anda dapat menggunakan GUI atau UI lainnya untuk menampilkan pesan ini sesuai dengan preferensi Anda
                // Contoh: GUI.Label(new Rect(10, 10, 200, 30), "Tekan E untuk mengganti kamera");

                // Jika pemain menekan tombol "E", beralih kamera
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SwitchCamera();
                }
            }
            else
            {
                nearWall = false;
            }
        }
        else
        {
            nearWall = false;
        }
    }

    void SwitchCamera()
    {
        // Aktifkan kamera TPS dan nonaktifkan kamera dinding jika kamera dinding aktif, dan sebaliknya
        tpsCamera.enabled = !tpsCamera.enabled;
        wallCamera.enabled = !wallCamera.enabled;
    }
}
