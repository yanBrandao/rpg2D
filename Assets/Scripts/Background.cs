using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public bool scrolling, parallax;


    public float backgroundSize, parallaxSpeed;

    private Transform _camera;
    [SerializeField]
    private Transform[] layers;
    private float _viewZone = 50;
    [SerializeField]
    private int leftIndex;
    [SerializeField]
    private int rightIndex;
    private float _lastCameraX;

    private void Start()
    {
        _camera = Camera.main.transform;
        _lastCameraX = _camera.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void Update()
    {
        if (parallax)
        {
            var cameraPosition = _camera.position;
            var deltaX = cameraPosition.x - _lastCameraX;
            transform.position += Vector3.right * (deltaX * parallaxSpeed);
            _lastCameraX = cameraPosition.x;
        }

        if (!scrolling) return;

        if (_camera.position.x < (layers[leftIndex].transform.position.x + backgroundSize))
        {
            ScrollLeft();
        }

        if (_camera.position.x > (layers[rightIndex].transform.position.x - backgroundSize))
        {
            ScrollRight();
        }
    }

    private void ScrollLeft()
    {
        var lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}
