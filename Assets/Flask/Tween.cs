using UnityEngine;

namespace Flask
{
    // exponential interpolation
    static class ETween
    {
        public static float Step(float current, float target, float omega)
        {
            return target - (target - current) * Mathf.Exp(-omega * Time.deltaTime);
        }
    }

    // tweening with the critically damped sprint model
    struct DTween
    {
        public float position;
        public float velocity;
        public float omega;

        public DTween(float position, float omega)
        {
            this.position = position;
            this.velocity = 0;
            this.omega = omega;
        }

        public void Step(float target)
        {
            var dt = Time.deltaTime;
            var n1 = velocity - omega * omega * dt * (position - target);
            var n2 = 1 + omega * dt;
            velocity = n1 / (n2 * n2);
            position += velocity * dt;
        }

        public static implicit operator float(DTween m)
        {
            return m.position;
        }
    }
}
