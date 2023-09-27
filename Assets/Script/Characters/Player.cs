using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed, jumpForce;
    [SerializeField] private LayerMask groundLayer;
    
    private bool isGrounded;

    private Vector3 _moveDir;

    private Rigidbody rb;
    private float depth;
    [SerializeField] private GameObject sphere;
    [SerializeField] private GameObject floor;



    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(myPlayer: this);
        InputManager.Gamemode();

        rb = GetComponent<Rigidbody>();
        depth = GetComponent<Collider>().bounds.size.y;
    }

    public void SpawnObject()
    {
        Instantiate(sphere, transform.position, transform.rotation);
    }
    //spawns a sphere from the player

    public void EndObject()
    {
        Destroy(floor);
    }
    //destroys the floor

    // Update is called once per frame
    void Update()
    {
        transform.position += (speed * Time.deltaTime * _moveDir);
        CheckGround();
    }

    public void SetMovementDirection(Vector3 newDirection)
    {
        _moveDir = newDirection;

        
    }
    public void Jump()
    {
        Debug.Log("jump called");
        if (isGrounded)
        {
            Debug.Log("Yes");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, depth, groundLayer);
        Debug.DrawRay(transform.position, Vector3.down * depth, Color.green, 0, false);
    }
}
