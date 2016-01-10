using UnityEngine;
using System.Collections;

namespace Test3D
{
    public class RandomWalker : MonoBehaviour
    {
        [SerializeField] float _radius = 5;
        [SerializeField] float _interval = 1;

        IEnumerator Start()
        {
            while (true)
            {
                transform.position = Random.insideUnitSphere * _radius;
                yield return new WaitForSeconds(_interval);
            }
        }
    }
}
