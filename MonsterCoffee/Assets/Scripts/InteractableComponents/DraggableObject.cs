using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DraggableObject : MonoBehaviour
{
    private bool _isDragging = false;
    private Vector2 _offset = Vector2.zero;
    private Vector2 _originalPos = Vector2.zero;
    private Camera _camera;
    private BoxCollider2D _boxCollider2D;
    public UnityEvent Dropped = new UnityEvent();

    private void Awake()
    {
        _camera = Camera.main;
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        _originalPos = transform.position;

    }

    private void Update()
    {
        if (!_isDragging)
            return;

        var mousePosition = getMousePos();
        transform.position = mousePosition - _offset;
    }

    private void OnMouseUp()
    {
        transform.position = _originalPos;
        _isDragging = false;
        _boxCollider2D.enabled = true;
        PlayerManager.Instance.StartDragging(null);
        Dropped.Invoke();
    }

    private void OnMouseOver()
    {
        
    }

    private void OnMouseDown()
    {
        _isDragging = true;
        _boxCollider2D.enabled = false;
        _offset = getMousePos() - (Vector2)transform.position;
        PlayerManager.Instance.StartDragging(gameObject);
    }

    private Vector2 getMousePos()
    {
        return (Vector2)_camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
