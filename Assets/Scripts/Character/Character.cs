using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    public Animator animator;
    protected Rigidbody2D rb;
    public BoxCollider2D characterCollider;
    public float MaxMovementSpeed;
    public float MovementAccelerationForce;
    public abstract void Initialize();
    public abstract void ControlLoop();
    protected Weapon Weapon;
    public string GunName = "Pistol";
    protected GameObject Gun;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        Initialize();
        this.animator = GetComponent<Animator>();
        characterCollider = GetComponent<BoxCollider2D>();
        this.Gun = Instantiate(
            (GameObject)Resources.Load($"Prefabs/Weapons/{this.GunName}"),
            Vector3.zero,
            new Quaternion(),
            null);
        this.Weapon = this.Gun.GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlLoop();
        AutonomousBehaviorLoop();
        TryStartStanding();
        AimWeapon();
    }

    public abstract void AutonomousBehaviorLoop();

    public bool IsMoving;
    private float lastMoveTime;
    public virtual void Move(Vector2 direction)
    {
        if (!IsMoving)
        {
            this.IsMoving = true;
            this.animator.SetBool("moving", this.IsMoving);
        }
        
        Vector2 forceVector = direction.Unit()
                              * MovementAccelerationForce;
        this.rb.AddForce(forceVector);
        this.lastMoveTime = Time.time;
    }

    private void TryStartStanding()
    {
        if (Time.time > lastMoveTime + .2f)
        {
            this.IsMoving = false;
            this.animator.SetBool("moving", IsMoving);
        }
    }

    protected void AimWeapon(){
        this.Weapon.SetHandsLocation(
            this.transform.position + new Vector3(0, .2f), 
            Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

}
