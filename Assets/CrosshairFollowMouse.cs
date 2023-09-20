using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWithMouseCrosshair : MonoBehaviour
{
    [SerializeField] public Camera fpsCamera;
    [SerializeField] public Transform crosshair;
    [SerializeField] private float raycastDistance = 100f;

    private void Start()
    {
    }

    private void Update()
    {
        // Mengambil posisi mouse dalam koordinat layar
        Vector3 mousePosition = Input.mousePosition;

        // Konversi posisi mouse ke dalam dunia permainan
        Vector3 worldPosition = fpsCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, raycastDistance));

        // Memperbarui posisi crosshair sesuai dengan posisi mouse
        crosshair.position = worldPosition;

        // Cast ray dari pusat layar ke arah yang dituju oleh crosshair
        Ray ray = fpsCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Objek terkena oleh raycast, lakukan sesuatu di sini
            Debug.Log("Objek yang terkena: " + hit.collider.name);

            // Misalnya, Anda dapat menampilkan informasi objek yang terkena di UI atau menjalankan logika lainnya.
        }
    }
}
