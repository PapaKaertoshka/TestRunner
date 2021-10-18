using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _counter = 0f;
    private bool _isMoving = true;
    private float _deltaMouseX = 0f;
    private float _prevMouseX = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pink")
        {
            _counter++;
        }
        else if (other.gameObject.tag == "Blue") _counter--;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _prevMouseX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0) && _isMoving)
        {
            _deltaMouseX = _prevMouseX - Input.mousePosition.x;
            if ((transform.position.x > -7f || _deltaMouseX < 0) && (transform.position.x < 7f || _deltaMouseX > 0))
                transform.Translate(-_deltaMouseX * Time.deltaTime, 0, 0);
            _prevMouseX = Input.mousePosition.x;
        }
    }
    private void FixedUpdate()
    {
        if (_isMoving)
            transform.Translate(0, 0, _speed * Time.fixedDeltaTime);
    }

    public bool move
    {
        get { return _isMoving; }
        set { _isMoving = value; }
    }

}