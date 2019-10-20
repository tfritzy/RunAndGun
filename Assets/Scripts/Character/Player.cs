﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GroundCharacter
{
    public override void Initialize()
    {
        this.MaxJumpCount = 1;
        this.JumpForce = 400;
        this.MovementAccelerationForce = 18;
        this.MaxMovementSpeed = 2;
        this.rb.gravityScale = 2;
        this.rb.drag = 2;
        this.canJump = true;
        moveLeft = new MoveLeft();
        moveRight = new MoveRight();
        slide = new Slide();
        jump = new Jump();
    }

    private MoveRight moveRight;
    private MoveLeft moveLeft;
    private Slide slide;
    private Jump jump;

    public override void ControlLoop()
    {
        if (jump.IsPressed())
        {
            this.Jump();
        }
        if (moveLeft.IsPressed())
        {
            this.MoveLeft();
        }
        if (moveRight.IsPressed())
        {
            this.MoveRight();
        }
        if (slide.IsPressed())
        {
            this.Slide();
        }
    }

    protected bool GetInputStatus(List<KeyCode> buttons)
    {
        foreach (KeyCode button in buttons)
        {
            if (Input.GetKeyDown(button))
            {
                return true;
            }
        }
        return false;
    }
}
