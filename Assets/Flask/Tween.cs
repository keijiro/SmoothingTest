using UnityEngine;
using System.Runtime.InteropServices;

namespace Flask
{
    // exponential interpolation
    static class ETween
    {
        public static float Step(float current, float target, float omega)
        {
            return target - (target - current) * Mathf.Exp(-omega * Time.deltaTime);
        }

        public static float StepAngle(float current, float target, float omega)
        {
            return target - Mathf.DeltaAngle(current, target) * Mathf.Exp(-omega * Time.deltaTime);
        }

        public static Vector3 Step(Vector3 current, Vector3 target, float omega)
        {
            return Vector3.Lerp(target, current, Mathf.Exp(-omega * Time.deltaTime));
        }

        public static Quaternion Step(Quaternion current, Quaternion target, float omega)
        {
            if (current == target)
                return target;
            else
                return Quaternion.Lerp(target, current, Mathf.Exp(-omega * Time.deltaTime));
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
            var n1 = velocity - (position - target) * (omega * omega * dt);
            var n2 = 1 + omega * dt;
            velocity = n1 / (n2 * n2);
            position += velocity * dt;
        }

        public static implicit operator float(DTween m)
        {
            return m.position;
        }
    }

    struct DTweenVector2
    {
        public Vector2 position;
        public Vector2 velocity;
        public float omega;

        public DTweenVector2(Vector2 position, float omega)
        {
            this.position = position;
            this.velocity = Vector2.zero;
            this.omega = omega;
        }

        public void Step(Vector2 target)
        {
            var dt = Time.deltaTime;
            var n1 = velocity - (position - target) * (omega * omega * dt);
            var n2 = 1 + omega * dt;
            velocity = n1 / (n2 * n2);
            position += velocity * dt;
        }

        public static implicit operator Vector2(DTweenVector2 m)
        {
            return m.position;
        }
    }

    struct DTweenVector3
    {
        public Vector3 position;
        public Vector3 velocity;
        public float omega;

        public DTweenVector3(Vector3 position, float omega)
        {
            this.position = position;
            this.velocity = Vector3.zero;
            this.omega = omega;
        }

        public void Step(Vector3 target)
        {
            var dt = Time.deltaTime;
            var n1 = velocity - (position - target) * (omega * omega * dt);
            var n2 = 1 + omega * dt;
            velocity = n1 / (n2 * n2);
            position += velocity * dt;
        }

        public static implicit operator Vector3(DTweenVector3 m)
        {
            return m.position;
        }
    }

    struct DTweenVector4
    {
        public Vector4 position;
        public Vector4 velocity;
        public float omega;

        public DTweenVector4(Vector4 position, float omega)
        {
            this.position = position;
            this.velocity = Vector4.zero;
            this.omega = omega;
        }

        public void Step(Vector4 target)
        {
            var dt = Time.deltaTime;
            var n1 = velocity - (position - target) * (omega * omega * dt);
            var n2 = 1 + omega * dt;
            velocity = n1 / (n2 * n2);
            position += velocity * dt;
        }

        public static implicit operator Vector4(DTweenVector4 m)
        {
            return m.position;
        }
    }

    struct DTweenQuaternion
    {
        [StructLayout(LayoutKind.Explicit)]
        struct QVUnion
        {
            [FieldOffset(0)] public Vector4 v;
            [FieldOffset(0)] public Quaternion q;
        }

        static Vector4 q2v(Quaternion q)
        {
            return new Vector4(q.x, q.y, q.z, q.w);
        }

        QVUnion _rotation;

        public Quaternion rotation {
            get { return _rotation.q; }
            set { _rotation.q = value; }
        }

        public Vector4 velocity;
        public float omega;

        public DTweenQuaternion(Quaternion rotation, float omega)
        {
            _rotation.v = Vector4.zero; // needed for suppressing warnings
            _rotation.q = rotation;
            velocity = Vector4.zero;
            this.omega = omega;
        }

        public void Step(Quaternion target)
        {
            var vtarget = q2v(target);
            // We can use either of vtarget/-vtarget. Use closer one.
            if (Vector4.Dot(_rotation.v, vtarget) < 0) vtarget = -vtarget;
            var dt = Time.deltaTime;
            var n1 = velocity - (_rotation.v - vtarget) * (omega * omega * dt);
            var n2 = 1 + omega * dt;
            velocity = n1 / (n2 * n2);
            _rotation.v = (_rotation.v + velocity * dt).normalized;
        }

        public static implicit operator Quaternion(DTweenQuaternion m)
        {
            return m.rotation;
        }
    }
}
