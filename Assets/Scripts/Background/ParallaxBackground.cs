using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Transform _target;  
    [SerializeField] private float _parallaxSpeed = 0.5f;  // Скорость параллакса. Значение < 1 делает фон медленнее, > 1 - быстрее.

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (_target != null)
        {
            float backgroundTargetPosX = _startPosition.x + (_target.position.x - _startPosition.x) * _parallaxSpeed;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, transform.position.y, transform.position.z);
            transform.position = backgroundTargetPos;
        }
    }
}
