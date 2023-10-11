using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baraban : MonoBehaviour
{

    private float _speed=0;
    
    void Update()
    {
        transform.Rotate(0, 0, _speed * Time.deltaTime);
    }
    public void SetSpeed(float speed)
    {
        _speed=speed;
    }
    public float GetSpeed()
    {
        return _speed;
    }
}
