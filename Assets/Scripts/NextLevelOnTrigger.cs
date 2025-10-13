using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelOnTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)
    {
        if (!c.CompareTag("Player")) return;
        var i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i + 1);
    }
}
