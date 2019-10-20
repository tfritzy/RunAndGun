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
        }
        if (isSliding){
            this.isSliding = false;
            this.canJump = true;
            TryStandUp();
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

    protected void MoveLeft(){
        this.Move(Vector2.left);
    }

    public void MoveRight(){
        this.Move(Vector2.right);
    }

    public override void AutonomousBehaviorLoop(){
        this.TryStandUp();
    }

    bool isSliding = false;
    float startSlideTime;
    float slideDuration = 1f;
    public void Slide(){
        if (!isSliding && !isJumping){
            this.canJump = false;
            SetPlayerRotation(90);
            startSlideTime = Time.time;
            this.isSliding = true;
        }
    }

    protected void TryStandUp(){
        if (this.transform.rotation.eulerAngles.z > 45){
            if (isSliding && Time.time > startSlideTime + slideDuration){
                SetPlayerRotation(0);
                isSliding = false;
                this.canJump = true;
            }
            if (!isSliding){
                SetPlayerRotation(0);
            }
        }
    }

    private void SetPlayerRotation(float angle){
        Vector3 rotation = this.transform.rotation.eulerAngles;
        rotation.z = angle;
        this.transform.rotation = Quaternion.Euler(rotation);
    }
}
