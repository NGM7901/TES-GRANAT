using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Camera fpsCamera;
    private RectTransform rectTransform;

    private float canvasWidth = 635f;
    private float canvasHeight = 397f;
    private float crosshairSize = 15f;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Cursor.visible = true; // Untuk menampilkan kursor
        Cursor.lockState = CursorLockMode.None; // Untuk mengizinkan kursor bergerak bebas
    }

    private void Update()
    {
        // Mendapatkan posisi mouse dalam koordinat layar
        Vector3 mousePosition = Input.mousePosition;

        // Menghitung faktor skala sesuai dengan ukuran crosshair dan canvas
        float scaleX = canvasWidth / Screen.width;
        float scaleY = canvasHeight / Screen.height;

        // Konversi posisi mouse ke dalam koordinat canvas
        float canvasX = (mousePosition.x * scaleX) - (canvasWidth / 2f);
        float canvasY = (mousePosition.y * scaleY) - (canvasHeight / 2f);

        // Mengatur posisi anchored (UI) dari RectTransform
        rectTransform.anchoredPosition = new Vector2(canvasX, canvasY);
    }
}
