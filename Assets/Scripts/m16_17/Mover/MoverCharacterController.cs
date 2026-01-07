using UnityEngine;

namespace m16_17
{
    public class MoverCharacterController : MonoBehaviour, IMover
    {
        [SerializeField] UnityEngine.CharacterController _characterController;

        public void Move(Vector3 normalizedDirection, float speed)
        {
            _characterController.Move(normalizedDirection * speed * Time.deltaTime);
        }
    }
}