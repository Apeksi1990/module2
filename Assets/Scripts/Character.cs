using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Character : MonoBehaviour
{
    public Transform Visual;
    public float MoveForce;
    public float JumpForce;

    Rigidbody2D rigidBody2D;
    TriggerDetector triggerDetector;
    Animator animator;
    float visualDirection;

    private static readonly int Speed = Animator.StringToHash("speed");

    // Start is called before the first frame update
    void Start()
    {
        visualDirection = 1.0f;
        rigidBody2D = GetComponent<Rigidbody2D>();
        triggerDetector = GetComponentInChildren<TriggerDetector>();
        animator = GetComponentInChildren<Animator>();
    }

    public void MoveLeft()
    {
        rigidBody2D.AddForce(new Vector2(-MoveForce, 0), ForceMode2D.Force);
    }

    public void MoveRight()
    {
        rigidBody2D.AddForce(new Vector2(MoveForce, 0), ForceMode2D.Force);
    }

    public void Jump()
    {
        if (triggerDetector.InTrigger)
            rigidBody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Force);
    }

    private void Update()
    {
        float vel = rigidBody2D.velocity.x;

        if (vel < -0.01f) {
            visualDirection = -1.0f;
        } else if (vel > 0.01f) {
            visualDirection = 1.0f;
        }

        Vector3 scale = Visual.localScale;
        scale.x = visualDirection;
        Visual.localScale = scale;

        animator.SetFloat(Speed, Mathf.Abs(vel));
    }
}
