using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rg2D;
    private MeshRenderer _meshRenderer;
    public List<Material> materialsProjectile;
    
    // Start is called before the first frame update
    void Start()
    {
        _rg2D = GetComponent<Rigidbody2D>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    public void SetMaterial(string material)
    {
        if (material.Equals("Nature"))
            _meshRenderer.material = materialsProjectile[0];
        else if (material.Equals("Ice"))
            _meshRenderer.material = materialsProjectile[1];
        else if (material.Equals("Fire"))
            _meshRenderer.material = materialsProjectile[2];
    }
}
