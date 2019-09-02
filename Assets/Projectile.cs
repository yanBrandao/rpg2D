using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rg2D;
    // Start is called before the first frame update
    void Start()
    {
        _rg2D = GetComponent<Rigidbody2D>();
        //_rg2D.AddForce(Vector2.right * 100);
    }
}
