using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMagicFormBehaviour : MonoBehaviour
{
    private static bool _isTimeShiftActivatePrevious;
    private static bool _isInForm;
    //private static bool 
    private static float _formTimer;
    private static float _coolDawnTimer;
    private static bool _isCoolDawn;
    void Start()
    {
        _isTimeShiftActivatePrevious = false;
        _formTimer = 0f;
        _coolDawnTimer = 0f;
        _isCoolDawn = false;
        _isInForm = false;
    }

    void Update()
    {
        //print(_formTimer + "f");
        //print(_coolDawnTimer + "c");
        if (_formTimer >0)
            _formTimer -= Time.deltaTime;
        if (_coolDawnTimer > 0)
            _coolDawnTimer -= Time.deltaTime;
        if (_formTimer <= 0 && _isInForm)
        {
            _formTimer = 0f;
            _isInForm = false;
            OnChange();
        }

        if (_coolDawnTimer <= 0 && _isCoolDawn)
        {
            _coolDawnTimer = 0f;
            _isCoolDawn = false;
        }
    }

    public static void OnChange()
    {
        if (_isTimeShiftActivatePrevious)
        {
            print("deactivate");
            TimeShiftConstants.UpdateAllExceptPlayer(1);
            _coolDawnTimer = 1f;
            //_isTimeShiftActivatePrevious = !_isTimeShiftActivatePrevious;
            _isTimeShiftActivatePrevious = false;
            _isCoolDawn = true;
        }
        else if (!_isCoolDawn && !_isTimeShiftActivatePrevious)
        {
            print("activate");
            TimeShiftConstants.UpdateAllExceptPlayer(0);
            _formTimer = 1f;
            _isInForm = true;
            _isTimeShiftActivatePrevious = true;
        }
    }
}
