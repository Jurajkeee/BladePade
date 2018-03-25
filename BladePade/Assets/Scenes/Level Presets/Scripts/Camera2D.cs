using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class Camera2D : MonoBehaviour
{

    [SerializeField] private float smooth = 2.5f;
    private Vector3 min, max;
    private Camera cam;
    private Transform player;
    private static Camera2D _internal;
    private SpriteRenderer bounds;

    void Awake()
    {
        _internal = this;
        cam = GetComponent<Camera>();
        FindPlayer_internal();
    }

    public static void FindPlayer()
    {
        _internal.FindPlayer_internal();
    }

    public static void CalculateBounds(SpriteRenderer ren)
    {
        _internal.CalculateBounds_internal(ren);
    }

    void FindPlayer_internal()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null) transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    void Follow()
    {
        Vector3 position = player.position;
        position.z = transform.position.z;
        position = MoveInside(position, new Vector3(min.x, min.y, position.z), new Vector3(max.x, max.y, position.z));
        transform.position = Vector3.Lerp(transform.position, position, smooth * Time.deltaTime);
    }

    void LateUpdate()
    {
        if (player != null)
        {
            Follow();
        }
    }

    public void CalculateBounds_internal(SpriteRenderer ren)
    {
        bounds = ren;
        float height = cam.orthographicSize * 2;
        Bounds b = new Bounds(Vector3.zero, new Vector3(height * cam.aspect, height, 0));
        min = b.max + ren.bounds.min;
        max = b.min + ren.bounds.max;
    }

    Vector3 MoveInside(Vector3 current, Vector3 pMin, Vector3 pMax)
    {
        if (bounds == null) return current;
        current = Vector3.Max(current, pMin);
        current = Vector3.Min(current, pMax);
        return current;
    }
}
