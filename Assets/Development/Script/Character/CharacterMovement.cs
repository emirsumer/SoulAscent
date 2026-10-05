using UnityEngine;

public partial class CharacterController
{
    [SerializeField] private float moveSpeed;                     
    [SerializeField] private float jumpForce;                   

    private int _jumpCount;                                       
    private int _maxJumpCount = 1;                              

    public void HandleMovement()
    {
        float horizontalRaw = InputManager.Instance.Horizontal;  

        _rigidbody2D.linearVelocity = new Vector2(horizontalRaw * moveSpeed, _rigidbody2D.linearVelocity.y); 

        if (horizontalRaw != 0)
        {
            transform.localScale = new Vector3(horizontalRaw, 1, 1); 
        }

        AnimMoveSpeed(Mathf.Abs(horizontalRaw));                 
    }

    public void HandleJump()
    {
        if (!InputManager.Instance.JumpPressed)                 
        {
            return;
        }
        if (_jumpCount >= _maxJumpCount)                       
        {
            return;
        }

        SoundManager.Instance.PlayJumpSFX();                    
        _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, 0); 
        _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);         
        AnimJump();                                              
        _jumpCount++;
    }

    public void StopMovement()
    {
        _rigidbody2D.linearVelocity = new Vector2(0, _rigidbody2D.linearVelocity.y); 
    }

    public void ResetJumpCount()
    {
        _jumpCount = 0;                                          
    }
}
