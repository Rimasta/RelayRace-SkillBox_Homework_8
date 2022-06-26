using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPoint : MonoBehaviour
{
    [SerializeField] private GameObject runner;
    [SerializeField] private Transform[] checkPoints;

    private int _targetIndex;
    private float _runnerSpeed;
    private bool _forward;
    private Vector3 _runnerTarget;
    private void Start()
    {
        _targetIndex = 1;
        _runnerSpeed = 3f;
        _runnerTarget = checkPoints[_targetIndex].position;
    }
    
    private void Update()
    {
        runner.transform.position =
            Vector3.MoveTowards(runner.transform.position, _runnerTarget, Time.deltaTime * _runnerSpeed);

        if (_targetIndex == checkPoints.Length-1) _forward = true;
        if (_targetIndex == 0) _forward = false;
        
        if (runner.transform.position == _runnerTarget)
        {
            if (_forward) _targetIndex--; 
            else _targetIndex++;
            
            _runnerTarget = checkPoints[_targetIndex].position;
            runner.transform.LookAt(_runnerTarget);
        }
    }
}
