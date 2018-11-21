using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnCollision : MonoBehaviour
{
    [SerializeField]private static string requiredTag = "Obstacle" ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collided(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collided(collision.gameObject);
    }

    void Collided(GameObject collidee)
    {
        if (collidee.gameObject.CompareTag(requiredTag))
        {
            this.GetComponent<Vitality>().Kill();
        }
    }
}
