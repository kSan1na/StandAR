using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class Moving : MonoBehaviour
{
    private Rigidbody _conveyer;
    [SerializeField] private Rigidbody _botPartOfConv;
    [SerializeField] private Material _botMaterial;
    public float _speed = 0;
    private float _matirealSpeed = 0;
    private Material _material;
    private bool _moveStatus = false;
    [SerializeField] private GameObject _speedBar;
    [SerializeField] private GameObject _leftBaraban;
    [SerializeField] private GameObject _rightBaraban;
    private float _startSpeedBarStatus = 0.5f;
    private bool _alarmStatus=false;
    private bool _globalAlarm;
    [SerializeField] private int _objectNum;
    [SerializeField] private GameObject _alarmLamp;
    [SerializeField] private bool _aboba;
    private Vector3 startpos;
    [SerializeField] GameObject MainStand;
    private void Start()
    {
        _conveyer = GetComponent<Rigidbody>();
        _material = GetComponent<MeshRenderer>().material;
        
    }
    void FixedUpdate()
    {

        if (_moveStatus)
        if (_moveStatus)
        {
            _material.mainTextureOffset = new Vector2(0f, Time.time * _matirealSpeed * Time.deltaTime);
            Vector3 pos = _conveyer.position;
            if (_aboba) {
                var random = new System.Random();
                float dispose = (float)(random.Next(-200, 200));
                if (dispose < 195 && dispose > -195)
                {
                    dispose = dispose / 1000000000;
                }
                else
                {
                    dispose = dispose / 10000000;
                }
                pos.z -= dispose;
            }

            
            _conveyer.position += Vector3.left * _speed * Time.fixedDeltaTime;
            
            _conveyer.MovePosition(pos);
            _botMaterial.mainTextureOffset = new Vector2(0, Time.time * _matirealSpeed * -1 * Time.deltaTime);
            Vector3 pos1 = _botPartOfConv.position;
            _botPartOfConv.position += Vector3.right * _speed * Time.fixedDeltaTime;
            _botPartOfConv.MovePosition(pos1);
            
        }
        

    }
    public void Pusk() {
        _moveStatus = true;
        _speed = 0.1f;
        _matirealSpeed = 50;
        _speedBar.GetComponent<PinchSlider>().SliderValue = _speed / 2 + 0.5f;
        //_speedBar.GetComponent<SliderSounds>().playTickSounds = true;
        SetSpeedBaraban();
        MainStand.GetComponent<ObjectManipulator>().enabled = false;
        MainStand.GetComponent<Rigidbody>().isKinematic = true;
        if (_alarmStatus)
        {
            _alarmStatus = false;
        }
        startpos = _conveyer.position;
        SendMessegeMQTT();
        MainStand.GetComponent<ObjectManipulator>().enabled = false;
        MainStand.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Stop() {
        _moveStatus = false;
        _speed = 0;
        _matirealSpeed = 0;
        _speedBar.GetComponent<PinchSlider>().SliderValue = 0.5f;
        //_speedBar.GetComponent<SliderSounds>().playTickSounds = false;
        SetSpeedBaraban();
        SendMessegeMQTT();
        MainStand.GetComponent<Rigidbody>().isKinematic = true;
        MainStand.GetComponent<ObjectManipulator>().enabled = true;
    }

    public void SpeedBar()
    {
        //max = 1;
        //min = -1;
        
        float currentSpeedOfBar = _speedBar.GetComponent<PinchSlider>().SliderValue;
        if (currentSpeedOfBar != _startSpeedBarStatus)
        {
            if (_moveStatus)
            {
                float deltaSpeed = currentSpeedOfBar - _startSpeedBarStatus;
                _speed = deltaSpeed * 2;

                _matirealSpeed = deltaSpeed * 1;
                SetSpeedBaraban();
                Debug.Log("Publish");

                SendMessegeMQTT();
            }
            else
            {
                _speedBar.GetComponent<PinchSlider>().SliderValue = 0.5f;
                SendMessegeMQTT();
            }
        }
        MainStand.GetComponent<ObjectManipulator>().enabled = true;

    }
    private void SetSpeedBaraban()
    {
        _leftBaraban.GetComponent<Baraban>().SetSpeed(_speed * 480);
        _rightBaraban.GetComponent<Baraban>().SetSpeed(_speed * 480);
        Debug.Log(_leftBaraban.GetComponent<Baraban>().GetSpeed());
    }

    public void EmergancyShotDown()
    {
        Stop();
        _alarmLamp.GetComponent<AlarmLamp>().alarm();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        EmergancyShotDown();
        _conveyer.position = startpos;
    }
    private void SendMessegeMQTT()
    {
        string speedToMessege = _speed.ToString();
        gameObject.GetComponent<mqttReceiver>().messagePublish = speedToMessege;
        gameObject.GetComponent<mqttReceiver>().Publish();
    }
    public void GetMqqtMessage(string nmg)
    {
        if (nmg == "Start" || nmg=="Stop")
        {
            if (nmg == "Start")
            {
                Pusk();

            }
            else
            {
                Stop();
            }
        }
        else
        {
            float updatedSpeed;
            bool check = float.TryParse(nmg, out updatedSpeed);
            if (check)
            {
                _speed = updatedSpeed;
                _matirealSpeed = _speed * 2.5f;
                SetSpeedBaraban();
            }
            else
            {
                
            }

        }
    }
    public void SpeedUp()
    {
        _speed += 0.1f;
        _matirealSpeed += 40f;
        _speedBar.GetComponent<PinchSlider>().SliderValue = _speed / 2 + 0.5f;
        //_speedBar.GetComponent<SliderSounds>().playTickSounds = true;
        SetSpeedBaraban();
    }
    public void SpeedDown()
    {
        _speed -= 0.1f;
        _matirealSpeed -= 40f;
        _speedBar.GetComponent<PinchSlider>().SliderValue = _speed / 2 + 0.5f;
        //_speedBar.GetComponent<SliderSounds>().playTickSounds = true;
        SetSpeedBaraban();
    }
}
