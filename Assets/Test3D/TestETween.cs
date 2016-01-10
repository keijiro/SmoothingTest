using UnityEngine;
using Flask;

namespace Test3D
{
    public class TestETween : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] float _omega = 1;

        void Update()
        {
            transform.position =
                ETween.Step(transform.position, _target.position, _omega);
        }
    }
}
