using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    public float speed = 4f;
    public InputActionReference moveAction;

    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y) * speed * Time.deltaTime;
        transform.Translate(move);
    }
}