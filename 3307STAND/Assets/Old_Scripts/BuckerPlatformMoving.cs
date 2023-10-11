using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
public class BuckerPlatformMoving : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 startpos;
    private float speed=0.1F;
    private float minY;
    private float maxY;
    private int flag = 0;
    private GameObject marker;
    private bool isFirst = true;
    private int _previosFlag=1;
    private bool _alarmStatus = false;
    private int _objectNum = 2;
    private float _scale = 1;
    [SerializeField] private GameObject _stand;
    private void Get_Start_Pos()
    {
        _scale = _stand.GetComponent<Transform>().localScale.x;
        marker = GameObject.Find("BuckerMarket");
        if (flag == 0)
        {
            startpos = rb.position;
            maxY = startpos[1] + 0.1F*_scale;
            minY = startpos[1] - 0.4F*_scale;
            flag = 1;
            
            isFirst = false;
        }
    }
    public void Pusk()
    {
        if (isFirst)
        {
            Get_Start_Pos();
            SendMessegeMQTT("Moving up");
        }
        flag = _previosFlag;
        if (_alarmStatus)
        {
            _alarmStatus = false;
        }
    }

    // Update is called once per frame

    void FixedUpdate()
    {
     
        float deltaFromMax = maxY - rb.position[1];
        if (flag == 1)
        {
            if (rb.position[1] < maxY)
            {

                rb.position += Vector3.up * speed*_scale * Time.fixedDeltaTime;
            }
            else
            {
                flag = -1;
                SendMessegeMQTT("Moving Down");
            }
        }   
        if (flag == -1)
        {
            if (rb.position[1] > minY)
            {
                rb.position += Vector3.down * speed*_scale * Time.fixedDeltaTime;
            }
            else
            {
                flag = 1;
                SendMessegeMQTT("Moving up");
            }
        }
        if(flag!=0) marker.GetComponent<PinchSlider>().SliderValue = 1-deltaFromMax / 1f;
        
    }
    public void Stop()
    {
        SendMessegeMQTT("Stoped");
        _previosFlag = flag;
        flag = 0;
    }
    private void SendMessegeMQTT(string messege)
    {
        gameObject.GetComponent<mqttReceiverBuncer>().messagePublish = messege;
        gameObject.GetComponent<mqttReceiverBuncer>().Publish();
    }
    public void GetMqqtMessage(string msg)
    {
        if (msg == "Start")
        {
            Pusk();
        }
        if (msg == "Stop")
        {
            Stop();
        }
    }
}
