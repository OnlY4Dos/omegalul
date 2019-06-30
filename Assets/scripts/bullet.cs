using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private Vector3 mousePosition;
    private float angle;
    void Start ()
    {   
        myRigidbody = GetComponent<Rigidbody2D> ();
        myRigidbody.AddForce(transform.right * moveSpeed, ForceMode2D.Impulse);
    }

    void OnBecameInvisible ()
    {
        Destroy (gameObject);
    }
   
}
