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
        private Vector3 move;


        void Update()
        {
            speed = _playerSettings.speed;
            gravity = _playerSettings.gravity;
            groundDistance = _playerSettings.groundDistance;
            jumpHeight = _playerSettings.jumpHeight;

            #region groundedCheck
            isGrounded = controller.isGrounded;
            //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            #endregion
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float mHorizontal = Input.GetAxis("Horizontal");
            float mVertical = Input.GetAxis("Vertical");

            //çarpraz gidimin avantaj saðlamamasý için
            if (mHorizontal != 0f && mVertical != 0f)
            {
                mHorizontal *= 2 / 3f;
                mVertical *= 2 / 3f;
            }

            if (isGrounded)
            {
                move = transform.right * mHorizontal + transform.forward * mVertical;
            }
            else
            {//havada yapýlan hareketlerin hýzlarý farklýdýr
                mHorizontal = Mathf.Clamp(mHorizontal, -0.8f, 0.8f);
                mVertical = Mathf.Clamp(mVertical, -0.5f, 0.8f);
                move = transform.right * mHorizontal + transform.forward * mVertical;
            }

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight *-3f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

}