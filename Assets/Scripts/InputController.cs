using UnityEngine;
using System.Collections;

namespace Runner
{

    public class InputController : MonoBehaviour
    {
        private MovementController _movementController;
        private bool _jump;

        private void Awake()
        {
            _movementController = GetComponentInChildren<MovementController>(true);
        }


        private void Update()
        {
            if (!_jump)
            {
                _jump = Input.GetButtonDown("Jump");
            }
        }

        private void FixedUpdate()
        {
            _movementController.Move(1, _jump);
            _jump = false;
        }


    }
}
