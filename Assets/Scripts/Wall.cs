using UnityEngine;

namespace SNAKE
{
    public class Wall : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent<Snake>(out Snake snake))
            {
                snake.GameOver();
            }
        }
    }
}
