using UnityEngine;
using Flask;

namespace Test1D
{
    public class TestETween : MonoBehaviour
    {
        [SerializeField] float _width = 10;
        [SerializeField] float _omega = 1;

        Vector3 _origin;
        float _position;

        void Start()
        {
            _origin = transform.position;
        }

        void Update()
        {
            var target = Input.GetAxis("Horizontal") * _width;

            _position = ETween.Step(_position, target, _omega);

            transform.position = _origin + Vector3.right * _position;
        }
    }
}
