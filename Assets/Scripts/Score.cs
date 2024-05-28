using UnityEngine;
using TMPro;

namespace SNAKE
{
    public class Score : MonoBehaviour
    {
        public Snake snake;
        public bool highest;
        private TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            if (highest)
            {
                text.text = snake.highestPoints.ToString();
            }
            else
            {
                text.text = snake.points.ToString();
            }
        }
    }
}
