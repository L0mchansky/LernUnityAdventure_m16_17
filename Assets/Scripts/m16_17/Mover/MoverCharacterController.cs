using UnityEngine;

namespace m16_17
{
    public class MoverCharacterController : MonoBehaviour
    {
        public void Move(Vector3 normalizedDirection, float speed, UnityEngine.CharacterController _characterController)
        {
            _characterController.Move(normalizedDirection * speed * Time.deltaTime);
        }
    }
}