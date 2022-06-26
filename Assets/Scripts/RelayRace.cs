using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayRace : MonoBehaviour
{
    [SerializeField] private Transform[] runners;
    private int _nextRunner;
    private int _currentRunner;
    private float _runnerVelocity;
    private float _currentDistance;
    private float _passDistance;
    
    private void Start()
    {
        _currentRunner = 0;
        _runnerVelocity = 2f;
        _passDistance = 0.3f;
    }
    
    private void Update()
    {
        _nextRunner = _currentRunner + 1;
        if (runners.Length - 1 < _nextRunner) _nextRunner = 0;

        runners[_currentRunner].transform.LookAt(runners[_nextRunner]);
        runners[_currentRunner].transform.position = Vector3.MoveTowards(runners[_currentRunner].position,
            runners[_nextRunner].position,
            Time.deltaTime * _runnerVelocity);

        _currentDistance = Vector3.Distance(
            runners[_currentRunner].transform.position,
            runners[_nextRunner].transform.position);
        
        if (_currentDistance<_passDistance)
            _currentRunner = _nextRunner;
    }
}
