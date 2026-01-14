using Unity.VisualScripting;
using UnityEngine;

namespace m16_17
{
    public class CharacterController : MonoBehaviour
    {
        private string _horizontalAxisName = "Horizontal";
        private string _verticalAxisName = "Vertical";

        [SerializeField] private UnityEngine.CharacterController _characterController;
        [SerializeField] private Mover _moverPrefab;

        private Mover _mover;
        private float _deadZone = 0.1f;

        private void Awake()
        {
            _mover = CreateMover();
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

            _mover.Move(normalizedInput);
            _mover.Rotate(normalizedInput);
        }

        private Mover CreateMover()
        {
            Mover mover = Instantiate(_moverPrefab, transform.position, Quaternion.identity);

            MoverCharacterController moverCharacter = mover.AddComponent<MoverCharacterController>();
            moverCharacter.Initialize(_characterController);

            Rotater rotater = mover.AddComponent<Rotater>();

            mover.Initialize(moverCharacter, rotater, transform.parent);

            mover.transform.SetParent(transform.parent);

            return mover;
        }
    }
}