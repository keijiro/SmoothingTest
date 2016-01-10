using UnityEngine;
using Flask;

namespace TestRotation
{
    public class TestDTween : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] float _omega = 1;

        DTweenQuaternion _rotation = new DTweenQuaternion(Quaternion.identity, 1);

        void Update()
        {
            _rotation.omega = _omega;
            _rotation.Step(_target.rotation);
            transform.rotation = _rotation;
        }
    }
}
