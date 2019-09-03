using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PlayerController  : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    
    [SerializeField]
    private Player player;
    
    private SpriteRenderer _spriteRenderer;

    private Animator _animator;

    public Rigidbody2D NatureProjectile;
    public Rigidbody2D IceShotProjectile;
    public Rigidbody2D FireballProjectile;
    public int projectileSpeed = 900;

    // Use this for initialization
    void Awake () 
    {

        _spriteRenderer = GetComponent<SpriteRenderer> (); 
        _animator = GetComponent<Animator> ();
        GameObject gameManager = GameObject.Find("GameManager");
        LoadScene loadComponent = gameManager.GetComponent<LoadScene>();
        player = new Player(300, new Class(loadComponent.getClassType()));
        if (player.currentClass.type == Class.ClassType.Mage)
        {
            _animator.SetInteger("setItem", 1);
        }
    }

    private void Update()
    {
        var position = transform.position;
        
        var rotation = transform.rotation;
        rotation.z += 1;

        Vector2 cloneVelocity;
        if (_spriteRenderer.flipX)
        {
            cloneVelocity = Vector2.left * projectileSpeed;
            position.x -= 3;
        }
        else
        {
            cloneVelocity = Vector2.right * projectileSpeed;
            position.x += 3;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (player.currentClass.type == Class.ClassType.Mage)
            {
                var clone = Instantiate(IceShotProjectile, position, Quaternion.Euler(new Vector3(0, 0, 90)));
                clone.AddForce(cloneVelocity);
            }
            else
            {
                var clone = Instantiate(NatureProjectile, position, Quaternion.Euler(new Vector3(0, 0, 90)));
                clone.AddForce(cloneVelocity);
            }

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (player.currentClass.type == Class.ClassType.Mage)
            {
                var clone = Instantiate(FireballProjectile, position, Quaternion.Euler(new Vector3(0, 0, 90)));
                clone.AddForce(cloneVelocity);
            }
            else
            {
                var clone = Instantiate(NatureProjectile, position, Quaternion.Euler(new Vector3(0, 0, 90)));
                clone.AddForce(cloneVelocity);
            }
        }

        PhysicUpdate();
    }


    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (Input.GetButtonDown ("Jump") && Grounded) {
            Velocity.y = jumpTakeOffSpeed;
        } else if (Input.GetButtonUp ("Jump")) 
        {
            if (Velocity.y > 0) {
                Velocity.y *= 0.5f;
            }
        }

        bool flipSprite = (_spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0f));
        if (flipSprite)
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }

        _animator.SetBool ("grounded", Grounded);
        _animator.SetFloat ("velocityX", Mathf.Abs (Velocity.x) / maxSpeed);

        TargetVelocity = move * maxSpeed;
    }

}