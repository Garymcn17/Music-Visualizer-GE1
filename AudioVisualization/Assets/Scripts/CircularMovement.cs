﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour {

    public Vector2 Velocity = new Vector2(1, 0);

    [Range(0, 5)]
    public float RotateSpeed = 1f;
    [Range(0, 5)]
    public float RotateRadiusX = 1f;
    [Range(0, 5)]
    public float RotateRadiusY = 1f;

    public bool Clockwise = true;

    private Vector2 _centre;
    private float _angle;

    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {
        _centre += Velocity * Time.deltaTime;

        _angle += (Clockwise ? RotateSpeed : -RotateSpeed) * Time.deltaTime;

        var x = Mathf.Sin(_angle) * RotateRadiusX;
        var y = Mathf.Cos(_angle) * RotateRadiusY;

        transform.position = _centre + new Vector2(x, y);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_centre, 0.1f);
        Gizmos.DrawLine(_centre, transform.position);
    }
}
