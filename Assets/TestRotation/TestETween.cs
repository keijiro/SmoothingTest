using UnityEngine;
using Flask;

namespace TestRotation
{
    public class TestETween : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] float _omega = 1;

        void Update()
        {
            transform.rotation =
                ETween.Step(transform.rotation, _target.rotation, _omega);
        }
    }
}
