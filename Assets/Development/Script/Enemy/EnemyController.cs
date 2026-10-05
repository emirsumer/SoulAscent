using UnityEngine;

public partial class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] private float followRange;
    [SerializeField] private float attackRange;

    private Transform _character;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        InitHealth();

        CharacterController characterController = FindFirstObjectByType<CharacterController>();

        if (characterController != null)
        {
            _character = characterController.transform;
        }
    }

    private void Update()
    {
        if (IsHit)
        {
            return;
        }

        if (IsAttacking)
        {
            StopMoving();
            return;
        }

        float distanceToCharacter;

        if (_character != null)
        {
            distanceToCharacter = Vector2.Distance(transform.position, _character.position);
        }
        else
        {
            distanceToCharacter = Mathf.Infinity;                 // Oyuncu yoksa sonsuz mesafe anlamsız tepki vermesin
        }

        if (distanceToCharacter <= attackRange)
        {
            StopMoving();
            FaceTarget(_character.position);
            TryAttack();
        }
        else if (distanceToCharacter <= followRange)
        {
            MoveTowards(_character.position);
        }
        else
        {
            Patrol();
        }
    }
}