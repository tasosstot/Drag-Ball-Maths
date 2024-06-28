using UnityEngine;

public class Ball : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;

    [SerializeField]
    private float moveSpeed = 10;

    private void Awake()
    {
           // με το RigidBody2D δίνουμε physics στο game object μας
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
         //ορίζουμε την ταχύτητα
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * moveSpeed;
    }
}