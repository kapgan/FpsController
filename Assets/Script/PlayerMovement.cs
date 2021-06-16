using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace playerSetting
{

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

        [SerializeField] private PlayerSettings _playerSettings;
        
    private float gravity;
    private float groundDistance;
    float jumpHeight;
    private float speed;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;
        // Update is called once per frame
        private void Start()
        {

          
           

        }
        void Update()
        {
            speed = _playerSettings.speed;
            gravity = _playerSettings.gravity;
            groundDistance = _playerSettings.groundDistance;
            jumpHeight = _playerSettings.jumpHeight;

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float mHorizontal = Input.GetAxis("Horizontal");
        float mVertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * mHorizontal + transform.forward * mVertical;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

}