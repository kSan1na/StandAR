using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private GameObject _door;  
    private bool _isOpen = false;
    private float _deltaRotate = 0;
    private Rigidbody rd;
    // Update is called once per frame
    private void Start()
    {
        rd = _door.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        
        if (!_isOpen)
        {
            if (_door.transform.localRotation.z > -0.7)
            {
                
                _door.transform.Rotate(0, 0, _deltaRotate);
                
            }
            else
            {
                _isOpen = true;
                _deltaRotate = 0;
            }
        }
        else
        {
            if (_door.transform.rotation.z < -0.5)
            {
                _door.transform.Rotate(0, 0, _deltaRotate);
            }
            else
            {
                _isOpen = false;
                _deltaRotate = 0;
            }
        }
    }
    public void OpenClose()
    {
        if (!_isOpen) _deltaRotate = -1;
        else _deltaRotate = 1;
    }
}
