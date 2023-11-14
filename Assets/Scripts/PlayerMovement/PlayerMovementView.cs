using ModestTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PlayerMovementView : MonoBehaviour
{
    private PlayerMovementController _playerMovementController;
    private Rigidbody2D _playerRigidbody;
    private bool _isJumping;

    [Inject]
    public void Construct(PlayerMovementController controller)
    {
        _playerMovementController = controller;
    }

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _isJumping = false;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        transform.Translate(_playerMovementController.GetMovementVectorMoveSpeed() * Time.deltaTime);
    }

    public void Jump()
    {
        if(!_isJumping)
        {
            _playerRigidbody.AddForce(_playerMovementController.GetMovementVectorJump(), ForceMode2D.Impulse);
            _isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isJumping = false;
    }


}
