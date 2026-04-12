using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 2f;

    public InputActionReference sprintAction;
    public InputActionReference jumpAction;
    
    public AudioSource walkSound;
    public AudioSource runSound;


    private Vector2 movementInput;
    private Rigidbody rb;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
     
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void OnMovement(InputValue data) 
    { 
        movementInput = data.Get<Vector2>();
        walkSound.Play();
    }

    public void MovePlayer() 
    { 
        Vector3 direction = transform.right * movementInput.x + transform.forward * movementInput.y;
        if (sprintAction.action.IsPressed())
        {
            movementSpeed = 7.5f;
            runSound.Play();
        }
        else         
        {
            movementSpeed = 5f;
        }
        rb.linearVelocity = new Vector3(direction.x * movementSpeed, rb.linearVelocity.y, direction.z * movementSpeed);
        if (jumpAction.action.IsPressed() && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }



}
