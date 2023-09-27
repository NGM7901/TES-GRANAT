using UnityEngine;

public class dropItem : MonoBehaviour
{
    public GameObject itemToDrop; // Item yang akan di-drop
    public int dropPercentage = 30; // Persentase peluang drop item (misalnya 50 untuk 50%)

    private void OnDestroy()
    {
        int randomValue = Random.Range(1, 101); // Random value antara 1 dan 100 (inklusif)
        
        if (randomValue <= dropPercentage)
        {
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
    }
}

