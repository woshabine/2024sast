using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using Random = System.Random;

public class CarControl : MonoBehaviour
{
    [SerializeField]
    private  TextMeshProUGUI SpeedText;
    private Rigidbody2D Rigidbody2DCar;
    private Vector3 offset;
    private Animator _animator;
    private int _isTurning = 0;//转动判断
    public int isDisturbed = 1;//混乱

    private bool isWorking = true;
    private bool flag = false;
    
    public float _r = 0.7f;//blendtree参数
    private float _rAngleV = 1f;//转动速度
    private float _rAngle;//虚拟轴转动角度
    private float _Angle;//up转为角度
    private Vector2 _vRotation;//虚拟转轴
    
    private float _fm = 2f;
    public bool _isBackUp = false;//刹车判断
    
    public float burstRate1 = 0.0025f;
    public float burstV1 = 200f;
    public float burstRate2 = 0.0033f;
    public float burstV2 = 250f;
    public float burstRate3 = 0.005f;
    public float burstV3 = 300f;

    public int artifact = 0;

    // Start is called before the first frame update
    void Start()
    {
        offset = Camera.main.transform.position-transform.position;
        Rigidbody2DCar = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //前进和刹车控制
        if (Input.GetKeyDown(KeyCode.W)&&isWorking)
        {
            flag = true;
        }

        if (flag && isWorking)
        {
            Rigidbody2DCar.drag = 0.05f;
            Rigidbody2DCar.AddForce(transform.up * _fm, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.S) && (Rigidbody2DCar.velocity.magnitude > 0.001f && _isBackUp))
        {
            Rigidbody2DCar.drag = 0.8f;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Rigidbody2DCar.drag = 0.1f;
        }
        //左右转弯控制
        if(Input.GetKeyDown(KeyCode.A))
        {
            _isTurning -= isDisturbed;
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            _isTurning += isDisturbed;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            _isTurning += isDisturbed;
        }    
        else if(Input.GetKeyUp(KeyCode.D))
        {
            _isTurning -= isDisturbed;
        }
        _isTurning=Mathf.Clamp(_isTurning,-1,1);
        
        //转动
        if(_r>=0.1f&&_r<=0.9f)
        {
            _r += _isTurning * _rAngleV * Time.deltaTime;
        }
        else if(_r<0.1f)
        {
            _r += 0.05f;
        }
        else if(_r>0.9f)
        {
            _r -= 0.05f;
        }
            
        _animator.SetFloat("Rotate", _r);
        
        
        _Angle=Mathf.Atan2(transform.up.y,transform.up.x) * Mathf.Rad2Deg;//up的绝对角度
        //blendtree参数转化为绝对角度
        _rAngle = _Angle-(12119980f + (-22.49977f - 12119980f) / (float)Math.Pow(1f + (_r / 74163.58f),1.000009f ))+60f;
        _vRotation = new Vector2(Mathf.Cos(_rAngle*Mathf.Deg2Rad), Mathf.Sin(_rAngle*Mathf.Deg2Rad) ).normalized;
        
        //速度转向
        Rigidbody2DCar.velocity = _vRotation * Rigidbody2DCar.velocity.magnitude;
        SpeedText.text = "SPEED:" + Math.Floor(Rigidbody2DCar.velocity.magnitude);
        
        //相机转向
        if (_r > 0.8820704f || _r < 0.1276953f)
        {
            transform.Rotate(new Vector3(0,0,1),-_isTurning * _rAngleV *100f* Time.deltaTime);
            Camera.main.transform.Rotate(new Vector3(0,0,1),-_isTurning * _rAngleV *100f* Time.deltaTime);
        }
        //爆缸
        if (isCylinderBursted(Rigidbody2DCar.velocity.magnitude))
        {
            isWorking = false;
        }
        //相机跟随
        Camera.main.transform.position = transform.position+offset;
    }

    

    //爆缸
    private bool isCylinderBursted(float velocity)
    {
        if ((velocity >= burstV1&&velocity<burstV2&&UnityEngine.Random.Range(0f,1f)<burstRate1)||(velocity>=burstV2&&velocity<burstV3&&UnityEngine.Random.Range(0f,1f)<burstRate2)||(velocity>=burstV3&&UnityEngine.Random.Range(0f,1f)<burstRate3))
        {
            return true;
        }
        return false;
    }
    public void change_r(float r)
    {
        if (Time.deltaTime % 2 == 0)
        {
            _r += r;
        }
        else
        {
            _r -= r;
        }
    }
    public void setrAngleV(float angleV)
    {
        _rAngleV = angleV;
    }

    

    
}
