using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnCollision : MonoBehaviour
{
    [SerializeField]private static string requiredTag = "Obstacle" ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(requiredTag))
        {
            Destroy(this.gameObject);
        }
    }
}
