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
    [SerializeField] private bool _isJumping;

    [Inject]
    public void Construct(PlayerMovementController controller)
    {
        _playerMovementController = controller;
        _playerMovementController.OnPlayersJump += OnPlayersJump;
    }

    private void OnPlayersJump(object sender, System.EventArgs e)
    {
        Jump();
    }

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _isJumping = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        _playerRigidbody.velocity = new Vector2(_playerMovementController.GetMovementVectorMoveSpeed().x, _playerRigidbody.velocity.y);
        FlipIfNeeded();
    }

    private void FlipIfNeeded()
    {
        float moveSpeed = _playerMovementController.GetMovementVectorMoveSpeed().x;

        if (moveSpeed > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveSpeed < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Jump()
    {
        if(!_isJumping)
        {
            _playerRigidbody.AddForce(Vector3.up * _playerMovementController.GetJumpForce(), ForceMode2D.Impulse);
            _isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isJumping = false;
    }
}
