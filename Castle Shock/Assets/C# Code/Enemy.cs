using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float minDistanceFromPlayer;

    private GameObject _playerObject;
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerObject = GameObject.Find("Player");
    }
    
    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        Vector2 enemyPosition = transform.position;
        Vector2 playerPosition = _playerObject.transform.position;
        Vector2 targetPosition = Vector2.MoveTowards(enemyPosition, (enemyPosition - playerPosition).normalized * minDistanceFromPlayer + playerPosition, Time.deltaTime * speed);

        _rigidbody.MovePosition(targetPosition);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        
        switch (otherObject.tag)
        {
            // collided with a bullet.
            case "Bullet":
            {
                // for now we just destroy ourselves.
                Destroy(gameObject);
                break;
            }
        }
    }
}
