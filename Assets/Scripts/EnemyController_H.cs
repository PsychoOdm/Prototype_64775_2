using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_H : MonoBehaviour
{
    public float speed = 2.0f;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2d;
    float timer;
    int direction = 1;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        if (rigidbody2d == null)
            Debug.LogError("Rigidbody2D não encontrado no inimigo!");
        timer = changeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        if (rigidbody2d == null) return;
        Vector2 position = rigidbody2d.position;
        position.x += speed * direction * Time.fixedDeltaTime;
        rigidbody2d.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
            player.ChangeHealth(-1);
    }
}