using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Settings")]
    Rigidbody2D rb2d;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    float moveX;

    [Header("GroundCheck Settings")]
    public Transform groundCheck;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);
    public LayerMask groundLayer;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        rb2d.linearVelocity = new Vector2(moveX * moveSpeed, rb2d.linearVelocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveX = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
             if (context.performed)
            {
                rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            }
        }
    }

    private bool IsGrounded()
    {
        if (Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer))
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }
}
