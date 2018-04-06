using System.Collections;
using UnityEngine;

public class Camera2DTrigger : MonoBehaviour
{

    [SerializeField] private SpriteRenderer bounds;

    void OnTriggerEnter2D(Collider2D other)
    {
        Camera2D.CalculateBounds(bounds);
    }
}
