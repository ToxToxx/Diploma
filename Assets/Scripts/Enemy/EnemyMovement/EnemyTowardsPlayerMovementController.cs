using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyMovementConfig _enemyMovementConfig;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _restingPositionObject;
    private IEnemyMovement _enemyMovementModel;

    private bool flip;
    private enum EnemyState
    {
        Resting,
        ChasingPlayer,
        ReturningToRest
    }

    [SerializeField] private EnemyState currentState = EnemyState.Resting;
    private Vector3 restingPosition; // Позиция, где враг начинает отдыхать
    private float _detectionDistance = 10f; // Расстояние для детекции игрока

    private void Awake()
    {
        _enemyMovementModel = new EnemyMovementModel(_enemyMovementConfig);
        restingPosition = _restingPositionObject.transform.position; // Сохраняем начальную позицию для отдыха
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Resting:
                if (PlayerInRange())
                {
                    currentState = EnemyState.ChasingPlayer;
                }
                break;

            case EnemyState.ChasingPlayer:
                MoveTowards(_player.transform.position);
                if (!PlayerInRange())
                {
                    currentState = EnemyState.ReturningToRest;
                }
                break;

            case EnemyState.ReturningToRest:
                MoveTowards(restingPosition);
                break;
        }
    }

    private void MoveTowards(Vector3 targetPosition)
    {
        if (currentState != EnemyState.Resting)
        {
            Vector3 scale = transform.localScale;

            if (targetPosition.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            }

            transform.localScale = scale;
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.Translate(direction * _enemyMovementModel.EnemySpeed * Time.deltaTime, Space.World);
        }
    }

    private bool PlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        return distanceToPlayer <= _detectionDistance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _restingPositionObject)
        {
            currentState = EnemyState.Resting;
        }
    }
}
