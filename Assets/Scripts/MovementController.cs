using UnityEngine;
using System.Collections;

namespace Runner
{
    [RequireComponent(typeof(Animator),typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {

        private const float GroundedRadius = 0.2f;
        private const string GroundedAnimationName = "Ground";
        private const string VerticalSpeedAnimationName = "vSpeed";
        private const string SpeedAnimationName = "Speed";

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce = 800f;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _rigidbody;

        private bool _isGrounded = false;
        private bool _hasJumpedOnce = false;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _isGrounded = false;
            // Get list of all overlaps within the radius of ground check
            var colliders = Physics2D.OverlapCircleAll(_groundCheck.position, GroundedRadius);

            for (var i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    _isGrounded = true;
                }
            }

            _animator.SetBool(GroundedAnimationName, _isGrounded);
            _animator.SetFloat(VerticalSpeedAnimationName, _rigidbody.velocity.y);
        }

        public void Move (float move, bool jump)
        {
            // Should we move?
            if (_isGrounded)
            {
                _animator.SetFloat(SpeedAnimationName, move);
                _rigidbody.velocity = new Vector2(move * _speed, _rigidbody.velocity.y);
            }

            if (!_isGrounded && _hasJumpedOnce && jump)
            {
                performJump();
                _hasJumpedOnce = false;
            }

            // Should we jump
            if (_isGrounded && jump)
            {
                performJump();
                _hasJumpedOnce = true;
            }
        }

        private void performJump()
        {
            _isGrounded = false;
            _animator.SetBool(GroundedAnimationName, _isGrounded);
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
        }
      
    }
}