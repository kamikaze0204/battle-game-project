using UnityEngine;
using System.Collections;

public class MyController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        character = GetComponent<Rigidbody>();
    }
    Rigidbody character;
    public float MoveSpeed = 5.0f;
    public float JumpSpeed = 300.0f;
    public float GroundDistance=0.9f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            character.velocity = new Vector3(-MoveSpeed, character.velocity.y, character.velocity.z);//Vector3.left* MoveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            character.velocity = new Vector3(MoveSpeed, character.velocity.y, character.velocity.z);//Vector3.right* MoveSpeed;
        }
        else
        {
            character.velocity = new Vector3(0, character.velocity.y, character.velocity.z);
        }

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            character.AddForce(Vector3.up* JumpSpeed);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, GroundDistance);
    }
}
