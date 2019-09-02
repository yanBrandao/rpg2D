using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

    public float minGroundNormalY = .65f;
    public float gravityModifier = 1f;

    protected Vector2 TargetVelocity;
    protected bool Grounded;
    private Vector2 _groundNormal;
    private Rigidbody2D _rb2D;
    protected Vector2 Velocity;
    private ContactFilter2D _contactFilter;
    private readonly RaycastHit2D[] _hitBuffer = new RaycastHit2D[16];
    private readonly List<RaycastHit2D> _hitBufferList = new List<RaycastHit2D> (16);


    private const float MinMoveDistance = 0.001f;
    private const float ShellRadius = 0.01f;

    private void OnEnable()
    {
        _rb2D = GetComponent<Rigidbody2D> ();
    }

    private void Start () 
    {
        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask (Physics2D.GetLayerCollisionMask (gameObject.layer));
        _contactFilter.useLayerMask = true;
    }

    public void PhysicUpdate () 
    {
        TargetVelocity = Vector2.zero;
        ComputeVelocity (); 
    }

    protected virtual void ComputeVelocity()
    {
    
    }

    private void FixedUpdate()
    {
        Velocity += gravityModifier * Time.deltaTime * Physics2D.gravity;
        Velocity.x = TargetVelocity.x;

        Grounded = false;

        Vector2 deltaPosition = Velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2 (_groundNormal.y, -_groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement (move, false);

        move = Vector2.up * deltaPosition.y;

        Movement (move, true);
    }

    private void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > MinMoveDistance) 
        {
            int count = _rb2D.Cast (move, _contactFilter, _hitBuffer, distance + ShellRadius);
            _hitBufferList.Clear ();
            for (int i = 0; i < count; i++) {
                _hitBufferList.Add (_hitBuffer [i]);
            }

            for (int i = 0; i < _hitBufferList.Count; i++) 
            {
                Vector2 currentNormal = _hitBufferList [i].normal;
                if (currentNormal.y > minGroundNormalY) 
                {
                    Grounded = true;
                    if (yMovement) 
                    {
                        _groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot (Velocity, currentNormal);
                if (projection < 0) 
                {
                    Velocity = Velocity - projection * currentNormal;
                }

                float modifiedDistance = _hitBufferList [i].distance - ShellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }


        }

        _rb2D.position = _rb2D.position + move.normalized * distance;
    }

}