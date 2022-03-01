using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 50f;
    public float maxSpeed = 6f;
    public float jumpForce = 2f;
    public bool groundContact;
    private Rigidbody body;
    private Collider contact;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        contact = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        float castDist = contact.bounds.extents.y * 0.1f;
        groundContact = Physics.Raycast(transform.position, Vector3.down, castDist);
    
        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right * axis * speed, ForceMode.Force);

        if(groundContact && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(Mathf.Abs(body.velocity.x) > maxSpeed)
        {
            float newX = maxSpeed * Mathf.Sign(body.velocity.x);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }

        if(axis < 0.1f)
        {
            float newX = body.velocity.x * (1f - Time.deltaTime * 5f);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }

    }
}
