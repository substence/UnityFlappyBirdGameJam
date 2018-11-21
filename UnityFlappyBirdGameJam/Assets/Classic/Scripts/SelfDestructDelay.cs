using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructDelay : MonoBehaviour
{
    [SerializeField] private float lifetime = 10.0f;
    private float spawnTime;

    private void Start()
    {
        spawnTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time - spawnTime >= lifetime)
        {
            Destroy(this.gameObject);
            this.enabled = false;
        }
    }
}
