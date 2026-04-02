using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healthAmount = 1;

    // CORRIGIDO: agora está dentro da classe
    public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(healthAmount);

           
            if (collectedClip != null)
            {
                controller.PlaySound(collectedClip);
            }

            Destroy(gameObject);
        }
    }
}