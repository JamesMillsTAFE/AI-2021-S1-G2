using UnityEngine;

namespace Steering
{
    public class SteeringAgent : MonoBehaviour
    {
        public Vector3 Position => transform.localPosition;
        public Quaternion Rotation => transform.localRotation;

        public Vector3 Forward => transform.forward;
        public Vector3 Right => transform.right;
        public Vector3 Up => transform.up;

        public Vector3 CurrentForce => currentForce;
        [System.NonSerialized] public Vector3 velocity;

        public float Speed => speed;
        public float ViewAngle => viewAngle;
        public float MovementSmoothing => smoothing;

        [SerializeField, Range(.01f, .1f)] private float smoothing = .05f;
        [SerializeField, Range(45f, 180f)] private float viewAngle = 180f;
        [SerializeField] private new MeshRenderer renderer;
        [SerializeField] private SteeringBehaviour behaviour;

        [SerializeField] private bool drawCorona = false;

        private Vector3 currentForce;
        private float speed;

        public void SetPosAndRot(Vector3 _pos, Quaternion _rot)
        {
            transform.localPosition = _pos;
            transform.localRotation = _rot;
        }

        public void Initialise(float _speed) => speed = _speed;
        public void UpdateAgent() => behaviour?.UpdateAgent(this);
        public void UpdateCurrentForce(Vector3 _force) => currentForce = _force;
        public void SetColor(Color _color) => renderer.material.color = _color;

        // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, CurrentForce);
            Gizmos.DrawWireSphere(transform.position + CurrentForce, .1f);

            if(drawCorona)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawSphere(transform.position, .5f);

                foreach(Vector3 direction in SteeringAgentHelper.DirectionsInCone(viewAngle, Forward, true))
                {
                    Gizmos.color = new Color(1, 0, 0, .3f);
                    Gizmos.DrawSphere(transform.position + direction, .1f);

                    Gizmos.color = new Color(.75f, 0, .75f, 1f);
                    Gizmos.DrawLine(transform.position, transform.position + direction);
                }
            }
            else
            {
                Gizmos.color = new Color(1, 0, 0, .3f);
                
                foreach(Vector3 direction in SteeringAgentHelper.DirectionsInCone(viewAngle, Forward, true))
                {
                    Gizmos.DrawSphere(transform.position + direction, .1f);
                }
            }
        }
    }
}