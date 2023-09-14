using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera tpsCamera; // Kamera TPS
    public Camera fpsCamera; // Kamera FPS

    private bool isFPS = false; // Apakah sedang dalam mode FPS
    public ThirdPersonController characterController; // Komponen CharacterController pemain

    private FPSMovement fpsMovement; // Skrip pergerakan FPS

    void Start()
    {
        // Awalnya, aktifkan kamera TPS dan nonaktifkan kamera FPS
        tpsCamera.enabled = true;
        fpsCamera.enabled = false;

        // Dapatkan komponen CharacterController dari pemain
        characterController = GetComponent<ThirdPersonController>();

        // Dapatkan komponen FPSMovement
        fpsMovement = GetComponent<FPSMovement>();
        fpsMovement.enabled = false; // Matikan pergerakan FPS awalnya
    }

    void Update()
    {
        // Hitung posisi tengah pemain
        Vector3 playerCenter = transform.position;

        // Ubah ukuran overlap box sesuai dengan kebutuhan
        Vector3 boxSize = new Vector3(2f, 2f, 2f);

        // Pengecekan apakah ada dinding dalam overlap box
        Collider[] colliders = Physics.OverlapBox(playerCenter, boxSize);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Wall")) // Sesuaikan dengan tag dinding Anda
            {
                // Beralih antara mode FPS dan TPS dengan tombol atau kondisi yang sesuai
                if (Input.GetKeyDown(KeyCode.E)) // Ganti mode dengan tombol "E"
                {
                    isFPS = !isFPS;
                    tpsCamera.enabled = !isFPS;
                    fpsCamera.enabled = isFPS;

                    // Mengunci atau membuka pergerakan karakter berdasarkan mode FPS atau TPS
                    if (isFPS)
                    {
                        characterController.enabled = false; // Matikan pergerakan karakter saat FPS
                        fpsMovement.enabled = true; // Aktifkan pergerakan FPS
                    }
                    else
                    {
                        characterController.enabled = true; // Aktifkan pergerakan karakter saat TPS
                        fpsMovement.enabled = false; // Matikan pergerakan FPS
                    }
                }
            }
        }
    }
}
