using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public partial class CharacterController : MonoBehaviour, IDamageable
{
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
    }

    private void Update()
    {
        if (IsHit)                                                
        {
            return;
        }
        if (Time.timeScale == 0f)                                
        {
            return;
        }

        HandleMovement();                                        
        HandleJump();                                            
        HandleAttack();                                           
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))          
        {
            ResetJumpCount();                                   
        }
    }
}
