using UnityEngine;

namespace m16_17
{
    public class DetectorCharacter : MonoBehaviour
    {
        private string _characterGameObjectName = "Character";
        private float _minDistanceForDetect = 10f;

        private DetectorDistance _detectorDistance;
        public Character Character { private set; get; }

        private void Awake()
        {
            _detectorDistance = new DetectorDistance();

            GameObject character = GameObject.Find(_characterGameObjectName);
            Character = character.GetComponent<Character>();
        }

        public Character Detect()
        {
            if (_detectorDistance.IsWithinDistance(transform, Character.transform, _minDistanceForDetect))
            {
                return Character;
            }
            return null;
        }
    }
}