using UnityEngine;

namespace Test1D
{
    public class TestDirect : MonoBehaviour
    {
        [SerializeField] float _width = 10;

        Vector3 _origin;

        void Start()
        {
            _origin = transform.position;
        }

        void Update()
        {
            var position = Input.GetAxis("Horizontal") * _width;
            transform.position = _origin + Vector3.right * position;
        }
    }
}
