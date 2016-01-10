using UnityEngine;
using Flask;

namespace Test3D
{
    public class TestDTween : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] float _omega = 1;

        DTweenVector3 _position = new DTweenVector3(Vector3.zero, 1);

        void Update()
        {
            _position.omega = _omega;
            _position.Step(_target.position);
            transform.position = _position;
        }
    }
}
