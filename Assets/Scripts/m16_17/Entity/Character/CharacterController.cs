using UnityEngine;

namespace m16_17
{
    public class CharacterController : MonoBehaviour
    {
        private string _horizontalAxisName = "Horizontal";
        private string _verticalAxisName = "Vertical";

        [SerializeField] private MoverAttributes _moverAttributes;

        private IMover _mover;
        [SerializeField] private Rotater _rotater;

        private float _deadZone = 0.1f;

        private void Awake()
        {
            if (gameObject.TryGetComponent<IMover>(out IMover mover))
            {
                _mover = mover;
            }
        }

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

            _mover.Move(normalizedInput, _moverAttributes.MoveSpeed);
            _rotater.Rotate(normalizedInput, _moverAttributes.RotationSpeed, _moverAttributes.transform);
        }
    }
}