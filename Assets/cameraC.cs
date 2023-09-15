using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraC : MonoBehaviour
{
    public Camera tpsCamera; // Kamera TPS
    public Camera fpsCamera; // Kamera FPS

    private bool isFPS = false; // Apakah sedang dalam mode FPS
    private bool isPlayerTeleporting = false; // Apakah pemain sedang dalam proses teleportasi
    private Transform teleportDestination; // Posisi tujuan teleportasi
    private ThirdPersonController characterController; // Komponen CharacterController pemain

    private FPSMovement fpsMovement; // Skrip pergerakan FPS
    private bool isScanning = false;


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
        if (!isPlayerTeleporting)
        {
            // Hitung posisi tengah pemain
            Vector3 playerCenter = transform.position;

            // Ubah ukuran overlap box sesuai dengan kebutuhan
            Vector3 boxSize = new Vector3(2f, 2f, 2f);

            // Pengecekan apakah ada objek teleportasi dalam overlap box
            Collider[] colliders = Physics.OverlapBox(playerCenter, boxSize);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("posisiCover")) // Sesuaikan dengan tag "Wall" Anda
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
                            teleportDestination = collider.transform;
                            StartCoroutine(TeleportPlayer(teleportDestination.position));
                        }
                        else
                        {
                            characterController.enabled = true; // Aktifkan pergerakan karakter saat TPS
                            fpsMovement.enabled = false; // Matikan pergerakan FPS
                        }
                    }
                }
            }
            if (isFPS && !isScanning) // Aktifkan pemindaian saat tombol "R" ditekan
            {
                isScanning = true;
                StartCoroutine(ScanForWalls());
            }
        }
    }

    IEnumerator TeleportPlayer(Vector3 destination)
    {
        isPlayerTeleporting = true;

        // Matikan pergerakan karakter sementara
        characterController.enabled = false;
        fpsMovement.enabled = false;

        // Teleportasi karakter ke posisi tujuan
        transform.position = destination;

        // Tunggu sejenak sebelum mengaktifkan kembali pergerakan
        yield return new WaitForSeconds(0.1f);

        // Aktifkan kembali pergerakan karakter
        if (isFPS)
        {
            fpsMovement.enabled = true;
        }
        else
        {
            characterController.enabled = true;
        }

        isPlayerTeleporting = false;
    }

    IEnumerator ScanForWalls()
    {
        while (isScanning)
        {
            // Rotasi pemain secara perlahan
            transform.Rotate(Vector3.up, 200f * Time.deltaTime);

            // Raycast ke depan dari pemain
            Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2f)) // Sesuaikan jarak raycast sesuai kebutuhan
            {
                if (hit.collider.CompareTag("Wall")) // Deteksi tembok
                {
                    // Tembok terdeteksi, berhenti pemindaian
                    isScanning = false;
                    transform.rotation = Quaternion.identity; // Menghentikan rotasi pemain
                }
            }

            yield return null;
        }
    }
}
