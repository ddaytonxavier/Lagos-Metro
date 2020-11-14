using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastPlayer.LagosMetro
{
    public class PlayerController : MonoBehaviour
    {
        public float Speed = 10f;
        private Rigidbody rb;
        private Collider col;
        private Animator anim;
        private float startTime;
        private Vector2 startPos;
        private float endTime;
        private Vector2 endPos;
        private float swipeDistance;
        private float swipeTime;
        private float distToGround;

        [SerializeField] private float minSwipeDist;
        [SerializeField] private float maxTime;
        [SerializeField] private float jumpForce;
        [SerializeField] private float distanceToSideJump;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            col = GetComponent<Collider>();
            anim = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            distToGround = col.bounds.extents.y;
            anim.SetBool("IsRunning", true);
        }

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);   // First touch

                if (touch.phase == TouchPhase.Began)
                {
                    startTime = Time.time;   // Storing start time
                    startPos = touch.position; // storing start position
                }

                else if (touch.phase == TouchPhase.Ended)  // Touch ended
                {
                    endTime = Time.time;
                    endPos = touch.position;

                    swipeDistance = (endPos - startPos).magnitude;
                    swipeTime = endTime - startTime;

                    if (swipeTime < maxTime && swipeDistance > minSwipeDist)
                    {
                        Swipe();
                    }
                }
            }

            
        }

        private void FixedUpdate()
        {
            MoveForward();
        }

        private void MoveForward()
        {
            Vector3 tempVect = new Vector3(0, 0, 1);
            tempVect = transform.position + tempVect.normalized * Speed * Time.deltaTime;
            rb.MovePosition(tempVect);
        }

        private void Swipe()
        {
            Vector2 distance = endPos - startPos;

            if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
            {
                if (distance.x > 0 && transform.position.x != 2)
                {
                    transform.Translate(new Vector3(distanceToSideJump, 0f, 0f));  // move right while flipped
                }

                if (distance.x < 0 && transform.position.x != -2)
                {
                    transform.Translate(new Vector3(-distanceToSideJump, 0f, 0f));  // move left while flipped
                }
            }

            else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
            {
                if (distance.y > 0)
                {
                    if (Grounded())
                    {
                        Jump();
                    }
                }

                if (distance.y < 0)
                {
                    if (!Grounded())
                    {
                        rb.AddForce(Vector3.down * jumpForce);
                    }
                    else Roll();
                }
            }

            //if (transform.position.x > 2) transform.position = new Vector3(2, transform.position.y, transform.position.z);
            //else if (transform.position.x < -2) transform.position = new Vector3(2, transform.position.y, transform.position.z);
        }

        [ContextMenu("Jump")]
        private void Jump()
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
            anim.SetTrigger("CanJump");
        }

        private void Roll()
        {
            //rb.AddForce(Vector3.up * JumpForce);
            anim.SetTrigger("CanRoll");
        }

        private bool Grounded()
        {
            return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        }
    }
}