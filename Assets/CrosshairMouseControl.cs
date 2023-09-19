using UnityEngine;

public class CrosshairMouseControl : MonoBehaviour
{
    void Update()
    {
        // Mendapatkan posisi mouse dalam layar
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10.0f; // Jarak z dari kamera ke objek crosshair

        // Mengubah posisi crosshair sesuai dengan posisi mouse
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
