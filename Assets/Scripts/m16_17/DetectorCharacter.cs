using UnityEngine;

namespace m16_17
{
    public class DetectorCharacter : MonoBehaviour
    {
        private string _characterGameObjectName = "Character";
        private float _minDistanceForDetect = 10f;

        private DetectorDistance _detectorDistance;
        private Character _character;

        private void Awake()
        {
            _detectorDistance = new DetectorDistance();

            GameObject character = GameObject.Find(_characterGameObjectName);
            _character = character.GetComponent<Character>();
        }

        public Character Detect()
        {
            if (_detectorDistance.IsWithinDistance(transform, _character.transform, _minDistanceForDetect))
            {
                return _character;
            }
            return null;
        }
    }
}