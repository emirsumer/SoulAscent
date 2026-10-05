using System.Collections.Generic;
using UnityEngine;

public partial class EnemyController
{
    [SerializeField] private List<Transform> patrolPoints;       
    [SerializeField] private float moveSpeed;                  

    private int _currentPointIndex;
    public void Patrol()
    {
        if (patrolPoints == null || patrolPoints.Count == 0)
        {
            return;
        }

        Transform target = patrolPoints[_currentPointIndex];
        MoveTowards(target.position);

        float distance = Mathf.Abs(transform.position.x - target.position.x);
        if (distance < 0.1f)                         
        {
            _currentPointIndex++;

            if (_currentPointIndex >= patrolPoints.Count)         // Listenin sonuna geldiysek baþa dön
            {
                _currentPointIndex = 0;
            }
        }
    }

    public void MoveTowards(Vector3 destination)
    {
        float minX = GetMinPatrolX();
        float maxX = GetMaxPatrolX();

        Vector3 direction = (destination - transform.position).normalized;
        float targetX = transform.position.x + direction.x * moveSpeed * Time.deltaTime;

        if (targetX < minX || targetX > maxX)                     // Devriye sýnýrýný geçmesin
        {
            StopMoving();
            return;
        }

        _rigidbody2D.linearVelocity = new Vector2(direction.x * moveSpeed, _rigidbody2D.linearVelocity.y);
        FaceTarget(destination);
        AnimMoveSpeed(Mathf.Abs(_rigidbody2D.linearVelocity.x));
    }


    private float GetMinPatrolX()
    {
        float min = patrolPoints[0].position.x;
        foreach (var point in patrolPoints)
        {
            if (point.position.x < min)
            {
                min = point.position.x;
            }
        }
        return min;
    }
    private float GetMaxPatrolX()
    {
        float max = patrolPoints[0].position.x;
        foreach (var point in patrolPoints)
        {
            if (point.position.x > max)
            {
                max = point.position.x;
            }
        }
        return max;
    }
    public void FaceTarget(Vector3 target)
    {
        float directionX = target.x - transform.position.x;

        if (Mathf.Abs(directionX) < 0.01f)
        {
            return;
        }

        if (directionX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);      
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);    
        }
    }
        public void StopMoving()
    {
        _rigidbody2D.linearVelocity = new Vector2(0, _rigidbody2D.linearVelocity.y);
        AnimMoveSpeed(0f);
    }
}
