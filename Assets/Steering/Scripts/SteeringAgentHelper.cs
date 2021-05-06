using UnityEngine;

using System.Collections.Generic;

namespace Steering
{
    public static class SteeringAgentHelper
    {
        const int viewDirections = 100;

        public static readonly Vector3[] directions;
        private static Vector3[] coneDirections = null;

        // Default parameters must be at the end of the list, and can only be compile-time constants, meaning
        // you cannot use anything that would use the 'new' keyword
        public static Vector3[] DirectionsInCone(float _angle, Vector3 _forward, bool _forceRecalculate = false)
        {
            // Determine if this function has been run before
            if(coneDirections == null || _forceRecalculate)
            {
                List<Vector3> newDirections = new List<Vector3>();
                // Loop through every direction that has been generated
                foreach(Vector3 direction in directions)
                {
                    // Calculate the angle between the forward of the boid and the current direction
                    if(Vector3.Angle(direction, _forward) < _angle)
                    {
                        // This is inside the view angle so add it to the list
                        newDirections.Add(direction);
                    }
                }

                // Pass all the calculated directions into the coneDirections array
                coneDirections = newDirections.ToArray();
            }

            return coneDirections;
        }

        static SteeringAgentHelper()
        {
            directions = new Vector3[viewDirections];

            float goldenRatio = (1 + Mathf.Sqrt(5)) / 2;
            float angleIncrement = Mathf.PI * 2 * goldenRatio;

            for (int i = 0; i < viewDirections; i++)
            {
                float t = (float)i / viewDirections;
                float inclination = Mathf.Acos(1 - 2 * t);
                float azimuth = angleIncrement * i;

                float x = Mathf.Sin(inclination) * Mathf.Cos(azimuth);
                float y = Mathf.Sin(inclination) * Mathf.Sin(azimuth);
                float z = Mathf.Cos(inclination);

                directions[i] = new Vector3(x, y, z);
            }
        }
    }
}