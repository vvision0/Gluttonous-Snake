using System;
using UnityEngine;

namespace SNAKE
{
    public class PositionRecorder : MonoBehaviour
    {
        public Vector3[] positions;
        public int recordingNumber = 1000;

        private void Awake()
        {
            positions = new Vector3[recordingNumber];
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = transform.position;
            }
        }

        private void Update()
        {
            RecordPosition();
        }

        private void RecordPosition()
        {
            positions[0] = transform.position;
            Array.Copy(positions, 0, positions, 1, positions.Length - 1);
        }
    }
}
