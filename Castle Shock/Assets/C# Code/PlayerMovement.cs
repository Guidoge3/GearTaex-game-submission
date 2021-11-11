using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public float jumpPower = 5.0f;

    private Rigidbody2D _playerRigidbody;
    private bool _facingRight;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _facingRight = true;
    }
    private void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.D) && !_facingRight)
        {
            flip();
            _facingRight = true;
        }

        if (Input.GetKeyDown(KeyCode.A) && _facingRight)
        {
            flip();
            _facingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            Jump();
    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }
    private void Jump() => _playerRigidbody.AddForce(transform.up = new Vector2(0, jumpPower));

    private bool IsGrounded()
    {
        var groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        return groundCheck.collider != null && groundCheck.collider.CompareTag("Ground");
    }

    private void flip()
    {
        transform.Rotate(0f, 180, 0f);
    }
}
