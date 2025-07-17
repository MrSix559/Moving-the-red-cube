using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMoving : MonoBehaviour
{
    [SerializeField] private float _acceleration;
    private float _offsetX;
    private float _offset;
    private Renderer _renderer;
    private string _textureProperyName = "_MainTex";

    private void OnEnable()
    {
        MapController.OnChangedSpeed += ChangeAccleration;
    }

    private void OnDisable()
    {
        MapController.OnChangedSpeed -= ChangeAccleration;
    }

    private void ChangeAccleration()
    {
        _acceleration += 0.1f;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        _offset = -Time.time * _acceleration;
        _renderer.material.SetTextureOffset(_textureProperyName, new Vector2(_offset, 0));
    }
}
