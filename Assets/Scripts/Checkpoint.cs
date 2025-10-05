using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            col.GetComponent<PlayerHealth>()?.SetCheckpoint(transform.position);
    }
}
