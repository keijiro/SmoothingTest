using UnityEngine;
using Flask;

namespace Test1D
{
    public class TestDTween : MonoBehaviour
    {
        [SerializeField] float _width = 10;
        [SerializeField] float _omega = 1;

        Vector3 _origin;
        DTween _position = new DTween(0, 1);

        void Start()
        {
            _origin = transform.position;
        }

        void Update()
        {
            var target = Input.GetAxis("Horizontal") * _width;

            _position.omega = _omega;
            _position.Step(target);

            transform.position = _origin + Vector3.right * _position;
        }
    }
}
