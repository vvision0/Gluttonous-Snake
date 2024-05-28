using System.Collections;
using UnityEngine;

namespace SNAKE
{
    public class Food : MonoBehaviour
    {
        public GameObject foodImage;
        public AudioSource audioSource;
        public FoodSpawner spawner;
        private Snake snake;
        private float delaySeconds = 1f;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent<Snake>(out snake))
            {
                audioSource.PlayOneShot(audioSource.clip);
                snake.Eat();
                StartCoroutine(Respawn());
            }
        }

        private IEnumerator Respawn()
        {
            foodImage.SetActive(false);
            yield return new WaitForSeconds(delaySeconds);
            foodImage.SetActive(true);
            transform.position = spawner.RandomizeSpawnPosition();
        }
    }
}
