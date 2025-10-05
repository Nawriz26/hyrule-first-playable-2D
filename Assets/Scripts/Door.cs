using UnityEngine;

public class Door : MonoBehaviour
{
    public void Open()
    {
        // simplest: disable collider + fade out sprite
        var col = GetComponent<Collider2D>();
        if (col) col.enabled = false;
        var sr = GetComponent<SpriteRenderer>();
        if (sr) sr.color = new Color(1,1,1,0.3f);
    }
}
