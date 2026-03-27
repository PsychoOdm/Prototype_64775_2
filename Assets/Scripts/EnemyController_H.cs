using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_H : MonoBehaviour
{
   public float speed;
   public float changeTime = 3.0f;
  
   Rigidbody2D rigidbody2d;
   Animator animator;
   float timer;
   int direction = 1;

   void Start()
   {
       rigidbody2d = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
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
       Vector2 position = rigidbody2d.position;
       position.x = position.x + speed * direction * Time.deltaTime;
       animator.SetFloat("Move X", direction);
       animator.SetFloat("Move Y", 0);
       rigidbody2d.MovePosition(position);
   }

   void OnTriggerEnter2D(Collider2D other)
   {
       PlayerController player = other.GetComponent<PlayerController>();
       if (player != null)
       {
           player.ChangeHealth(-1);
       }
   }
}