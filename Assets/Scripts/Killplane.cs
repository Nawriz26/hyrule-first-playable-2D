using UnityEngine;
using UnityEngine.SceneManagement;
public class KillPlane : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player")) SceneManager.LoadScene("GameOver");
    }
}