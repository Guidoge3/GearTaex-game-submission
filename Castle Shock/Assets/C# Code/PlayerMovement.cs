using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public float jumpPower = 5.0f;
    public float gravity = -9.81f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Rigidbody2D _playerRigidbody;
    private bool _facingRight;

    bool isGrounded;
    Vector2 velocity;



    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _facingRight = true;
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

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

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }

    private void flip()
    {
        transform.Rotate(0f, 180, 0f);
    }
}
