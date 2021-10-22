using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _counter = 0f;
    [SerializeField] private Image rightBar, leftBar;
    [SerializeField] private Animator anim;
    private float desiredPosX;
    private bool _isMoving = true;
    private float _deltaMouseX = 0f;
    private float _prevMouseX = 0f;
    //private bool finish = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Pink")
        {
            _counter--;
        }
        else if (other.gameObject.tag == "Blue") {
            _counter++;
        }
        else if (other.gameObject.tag == "RBonus")
        {
            _counter -= 0.5f;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "BBonus")
        {
            _counter += 0.5f;
            other.gameObject.SetActive(false);
        } else
        {
            if (other.gameObject.tag == "Finish") { 
                anim.SetBool("Finish", true);
                move = false;
            }
        }
        rightBar.fillAmount = _counter * (1f / 6f);
        leftBar.fillAmount = -_counter * (1f / 6f);

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            desiredPosX = transform.position.x;
            _prevMouseX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0) && _isMoving)
        {
            _deltaMouseX = _prevMouseX - Input.mousePosition.x;
            if ((desiredPosX > -4f || _deltaMouseX < 0) && (desiredPosX < 4f || _deltaMouseX > 0))
            {
                desiredPosX -= _deltaMouseX * Time.deltaTime;
            }
            Vector3 smoothedPos = Vector3.Lerp(transform.position, new Vector3(desiredPosX, transform.position.y, transform.position.z), _speed * Time.deltaTime);
            transform.position = smoothedPos;
            _prevMouseX = Input.mousePosition.x;
        }
    }
    private void FixedUpdate()
    {
        if (_isMoving)
            {
                transform.Translate(0, 0, _speed * Time.fixedDeltaTime);
            }
       
    }

    public bool move
    {
        get { return _isMoving; }
        set { _isMoving = value; }
    }

}