using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBallMotionScript : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public int maxImpulse;
    private Vector3 _initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -60)
        {
            transform.position = _initialPosition;
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.name.StartsWith("Mesh"))
        {
            _rigidbody.AddForce(other.impulse.normalized * 10, ForceMode.Impulse);
            return;
        }
        // Debug.Log(other.impulse);
        if (other.impulse.magnitude > maxImpulse)
        {
            _rigidbody.AddForce(other.impulse.normalized * maxImpulse, ForceMode.Impulse);
        }
        else
        {
            _rigidbody.AddForce(other.impulse, ForceMode.Impulse);
        }

        // GetComponent<Rigidbody>().AddExplosionForce(other.relativeVelocity,ForceMode.Impulse);
    }
}