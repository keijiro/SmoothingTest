using UnityEngine;

public class SmoothingTest : MonoBehaviour
{
    public enum Mode { Direct, Exponential, Spring }

    [SerializeField] Mode _mode;
    [SerializeField] float _width = 10;
    [SerializeField] float _omega = 1;

    Vector3 _origin;
    float _position;
    float _velocity;

    static float ExpEase(float current, float target, float omega)
    {
        return target - (target - current) * Mathf.Exp(-omega * Time.deltaTime);
    }

    static float CSpring(float current, float target, ref float velocity, float omega)
    {
        var dt = Time.deltaTime;
        var n1 = velocity - omega * omega * dt * (current - target);
        var n2 = 1 + omega * dt;
        velocity = n1 / (n2 * n2);
        return current + velocity * dt;
    }

    void Start()
    {
        _origin = transform.position;
    }

    void Update()
    {
        var target = Input.GetAxis("Horizontal") * _width;

        if (_mode == Mode.Direct)
        {
            _position = target;
        }
        else if (_mode == Mode.Exponential)
        {
            _position = ExpEase(_position, target, _omega);
        }
        else // Spring
        {
            _position = CSpring(_position, target, ref _velocity, _omega);
        }

        transform.position = _origin + Vector3.right * _position;
    }
}
