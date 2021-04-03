using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBallMotionScript : MonoBehaviour
{
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        
        _rigidbody.AddForce(other.impulse,ForceMode.Impulse);
        // GetComponent<Rigidbody>().AddExplosionForce(other.relativeVelocity,ForceMode.Impulse);
        
    }
}
