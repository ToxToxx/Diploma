using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMovementView : MonoBehaviour
{
    private PlayerMovementController _playerMovementController;

    [Inject]
    public void Construct(PlayerMovementController controller)
    {
        _playerMovementController = controller;
        _playerMovementController.OnMove += ControllerOnMovePerformed;
    }

    private void ControllerOnMovePerformed(Vector2 obj, float speed)
    {
        Move(obj, speed);
    }

    public void Move(Vector2 direction, float moveSpeed)
    {
        transform.Translate(new Vector2(direction.x, direction.y) * moveSpeed * Time.deltaTime);
    }

}
