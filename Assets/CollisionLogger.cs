using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log($"[COLLISION] {gameObject.name} touché par {other.gameObject.name}");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[TRIGGER] {gameObject.name} traversé par {other.gameObject.name}");
    }
}