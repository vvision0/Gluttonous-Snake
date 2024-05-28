using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SNAKE
{
    public class FoodSpawner : MonoBehaviour
    {
        public Food foodPrefab;
        public Vector2 minRandom;
        public Vector2 maxRandom;
        private int foodAmount = 3;
        private List<Food> foods;

        private void Start()
        {
            foods = new List<Food>();
        }

        public void GenerateFood()
        {
            foodAmount = Option.instance.foodAmount;
            if (foods.Count != 0)
            {
                foreach(var food in foods)
                {
                    Destroy(food.gameObject);
                }
                foods.Clear();
            }
            for (int i = 0; i < foodAmount; i++)
            {
                Food food = Instantiate(foodPrefab);
                SceneManager.MoveGameObjectToScene(food.gameObject, gameObject.scene);
                food.transform.position = RandomizeSpawnPosition();
                food.spawner = this;
                foods.Add(food);
            }
        }

        public Vector3 RandomizeSpawnPosition()
        {
            minRandom = new Vector2(1f, 1f);
            maxRandom = new Vector2(Option.instance.mapWidth - 2, Option.instance.mapHeight - 2);
            Vector3 randomPosition = new Vector2(Mathf.Round(Random.Range(minRandom.x, maxRandom.x)), 
                                                 Mathf.Round(Random.Range(minRandom.y, maxRandom.y)));
            randomPosition.z = 0;
            return randomPosition;
        }
    }
}
