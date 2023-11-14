using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PlayerMovementView : MonoBehaviour
{
    private PlayerMovementController _playerMovementController;

    [Inject]
    public void Construct(PlayerMovementController controller)
    {
        _playerMovementController = controller;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(_playerMovementController.GetMovementTransform() * Time.deltaTime);
    }

}
