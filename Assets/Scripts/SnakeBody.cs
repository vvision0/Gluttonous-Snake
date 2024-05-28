using UnityEngine;

namespace SNAKE
{
    public class SnakeBody : MonoBehaviour
    {
        public PositionRecorder targetRecorder;

        public int offset;

        private void Update()
        {
            
            transform.position = targetRecorder.positions[offset];
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent<Snake>(out Snake snake))
            {
                snake.GameOver();
            }
        }
    }
}
