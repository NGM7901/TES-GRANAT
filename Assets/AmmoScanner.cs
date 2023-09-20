using UnityEngine;

public class AmmoScanner : MonoBehaviour
{
    public float scanRadius = 2f; // Radius sphere untuk deteksi
    public int ammo = 0;

    private void Update()
    {
        // Membuat sphere deteksi berdasarkan posisi objek saat ini
        Collider[] colliders = Physics.OverlapSphere(transform.position, scanRadius);

        // Memeriksa setiap collider yang terdeteksi
        foreach (Collider collider in colliders)
        {
            // Cek apakah collider memiliki tag "ammo"
            if (collider.CompareTag("ammo"))
            {
                // Hancurkan objek ammo yang terkena
                Destroy(collider.gameObject);
                ammo += 1;
            }
        }
    }

    // Untuk menggambar sphere deteksi pada Scene view dalam Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }
}
