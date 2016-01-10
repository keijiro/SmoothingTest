using UnityEngine;
using System.Collections;

namespace TestRotation
{
    public class RandomRotation : MonoBehaviour
    {
        [SerializeField] float _interval = 1;

        IEnumerator Start()
        {
            while (true)
            {
                transform.rotation = Random.rotation;
                yield return new WaitForSeconds(_interval);
            }
        }
    }
}
