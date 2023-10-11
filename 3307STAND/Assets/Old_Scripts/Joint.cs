using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    [SerializeField] private GameObject _HMI;
    private void Update()
    {
        transform.position = _HMI.transform.position + new Vector3(-0.03f, 0, -0.03f); ;
    }
}
