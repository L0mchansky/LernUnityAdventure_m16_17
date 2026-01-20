using UnityEngine;

namespace m16_17
{
    public class CharacterController : MonoBehaviour
    {
        private string _horizontalAxisName = "Horizontal";
        private string _verticalAxisName = "Vertical";

        [SerializeField] private UnityEngine.CharacterController _characterController;

        [SerializeField] private MoverAttributes _moverAttributes;
        [SerializeField] private Rotater _rotater;
        [SerializeField] private MoverCharacterController _mover;

        private float _deadZone = 0.1f;

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw(_horizontalAxisName), 0, Input.GetAxisRaw(_verticalAxisName));

            if (input.magnitude <= _deadZone)
                return;

            Vector3 normalizedInput = input.normalized;

            _mover.Move(normalizedInput, _moverAttributes.MoveSpeed, _characterController);
            _rotater.Rotate(normalizedInput, _moverAttributes.RotationSpeed, transform);
        }
    }
}