using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
 {
    [SerializeField] private float JumpMagnitude = 500.0f;  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonUp("Jump"))
        {
            DoJump(Vector2.up, JumpMagnitude);
        }
	}

    void DoJump(Vector2 direction, float magnitude)
    {
        Vector2 force = direction * magnitude;
        GetComponent<Rigidbody2D>().AddForce(force);
    }
}
