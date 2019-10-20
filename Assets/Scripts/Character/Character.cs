using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float MaxMovementSpeed;
    public float MovementAccelerationForce;

    public abstract void Initialize();
    public abstract void ControlLoop();

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        ControlLoop();
        AutonomousBehaviorLoop();
    }

    public abstract void AutonomousBehaviorLoop();

    public virtual void Move(Vector2 direction)
    {
        Vector2 forceVector = direction.Unit()
                                * MovementAccelerationForce;
        this.rb.AddForce(forceVector);
    }

}
