using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GroundCharacter : Character
{
    public float JumpForce;
    private int jumpCount;
    public int MaxJumpCount;
    public bool canJump;
    public bool isJumping;
    public void Jump()
    {
        if (this.jumpCount > 0 && canJump)
        {
            Vector3 jumpVector = new Vector3(0, this.JumpForce, 0);
            this.rb.AddForce(jumpVector);
            this.jumpCount -= 1;
            this.isJumping = true;
            this.animator.SetTrigger("jump");
        }
        if (isSliding)
        {
            ExitSlide();
            Jump();
        }
    }

    private void RestoreJumpCount()
    {
        this.jumpCount = this.MaxJumpCount;
        this.isJumping = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            RestoreJumpCount();
        }
    }

    private bool movingLeft;
    protected void MoveLeft()
    {
        this.Move(Vector2.left);
        this.animator.SetTrigger("running");
        if (!movingLeft)
        {
            SetYRotation(180);
            movingLeft = true;
        }
    }

    public void MoveRight()
    {
        
        this.animator.SetTrigger("running");
        this.Move(Vector2.right);
        if (movingLeft)
        {
            SetYRotation(0);
            movingLeft = false;
        }
    }

    private void SetYRotation(int angle)
    {
        Vector3 rotation = this.transform.rotation.eulerAngles;
        rotation.y = angle;
        this.transform.rotation = Quaternion.Euler(rotation);
    }

    public override void AutonomousBehaviorLoop()
    {
        this.TryStandUp();
    }

    public bool isSliding = false;
    float startSlideTime;
    float slideDuration = 1f;
    public void Slide()
    {
        if (!isSliding && !isJumping && IsMoving)
        {
            StartSlide();
        }
    }

    private void StartSlide()
    {
        startSlideTime = Time.time;
        this.canJump = false;
        this.isSliding = true;
        this.animator.SetTrigger("slide");
        ReverseColliderForSlide();
    }

    private void ExitSlide()
    {
        ReverseColliderForSlide();
        this.isSliding = false;
        this.canJump = true;
    }

    private void ReverseColliderForSlide()
    {
        Vector2 size = characterCollider.size;
        float temp = size.y;
        size.y = size.x;
        size.x = temp;
        characterCollider.size = size;
    }

    protected void TryStandUp()
    {
        if (isSliding && Time.time > startSlideTime + slideDuration)
        {
            ExitSlide();
        }
    }
}
