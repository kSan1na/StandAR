using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarabanSpiner : MonoBehaviour
{
    private GameObject Baraban_1_left;
    private GameObject Baraban_1_right;
    private GameObject Baraban_2_left;
    private GameObject Baraban_2_right;
    internal float speed_2 = 0;
    internal float speed_1=0;
    
    // Start is called before the first frame update
    void Start()
    {
        Baraban_1_left = GameObject.Find("LeftBaraban1");
        Baraban_1_right = GameObject.Find("rightBaraban1");
        Baraban_2_left = GameObject.Find("LeftBaraban2");
        Baraban_2_right = GameObject.Find("RigthBaraban2");
    }

    // Update is called once per frame
    void Update()
    {
        Baraban_1_left.transform.Rotate(0, 0, speed_1 * Time.deltaTime);
        Baraban_1_right.transform.Rotate(0, 0, speed_1 * Time.deltaTime);
        Baraban_2_left.transform.Rotate(0, 0, speed_2 * Time.deltaTime);
        Baraban_2_right.transform.Rotate(0, 0, speed_2 * Time.deltaTime);
    }
}
