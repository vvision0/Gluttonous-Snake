using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SNAKE
{
    public class Snake : MonoBehaviour
    {
        public int bodyPartsOffset = 40;
        public int MaxAmountOfBodyParts = 10;
        public int points = 0;
        public int highestPoints = 0;
        public SnakeBody snakeBodyPrefab;
        public List<SnakeBody> snakeBodyParts;
        public Vector2 targetDirection = Vector2.zero;
        public UnityEvent onGameOver;
        [SerializeField] private float speed = 50f;
        private SnakeInput snakeInput;
        private Vector3 deltaPosition;
        private Vector3 direction = Vector2.zero;
        private PositionRecorder positionRecorder;

        private void Awake()
        {
            snakeInput = GetComponent<SnakeInput>();
            positionRecorder = GetComponent<PositionRecorder>();
            snakeBodyParts = new List<SnakeBody>();
        }

        private void Update()
        {
            if (snakeInput.MovementInput.x == 1)
            {
                targetDirection = Vector2.right;
            }
            else if (snakeInput.MovementInput.x == -1)
            {
                targetDirection = Vector2.left;
            }
            else if (snakeInput.MovementInput.y == 1)
            {
                targetDirection = Vector2.up;
            }
            else if (snakeInput.MovementInput.y == -1)
            {
                targetDirection = Vector2.down;
            }

            if (targetDirection != new Vector2(direction.x, direction.y) && Vector3.Dot(direction, targetDirection) != -1)
            {
                if (Mathf.Abs(Mathf.Round(transform.localPosition.x) - transform.localPosition.x) < 0.001f && Mathf.Abs(Mathf.Round(transform.localPosition.y) - transform.localPosition.y) < 0.001f)
                {
                    if (Vector3.Cross(direction, new Vector3(targetDirection.x, targetDirection.y, 0)).z < 0)
                    {
                        transform.eulerAngles -= new Vector3(0, 0, 90);
                        if (transform.rotation.z == -360)
                        {
                            transform.eulerAngles = Vector3.zero;
                        }
                    }
                    if (Vector3.Cross(direction, new Vector3(targetDirection.x, targetDirection.y, 0)).z > 0)
                    {
                        transform.eulerAngles += new Vector3(0, 0, 90);
                        if (transform.rotation.z == 360)
                        {
                            transform.eulerAngles = Vector3.zero;
                        }
                    }
                    direction = targetDirection;
                    targetDirection = Vector3.zero;
                }
            }
        }

        private void FixedUpdate()
        {
            deltaPosition = Time.fixedDeltaTime * direction * speed;
            deltaPosition.x = Mathf.Round(deltaPosition.x * 10) / 10;
            deltaPosition.y = Mathf.Round(deltaPosition.y * 10) / 10;
            transform.position += deltaPosition;
        }

        public void Eat()
        {
            if (points < MaxAmountOfBodyParts - 1)
            {
                SnakeBody body = Instantiate(snakeBodyPrefab);
                SceneManager.MoveGameObjectToScene(body.gameObject, gameObject.scene);
                body.transform.position = transform.position;
                body.targetRecorder = positionRecorder;
                body.offset = (points * bodyPartsOffset) + bodyPartsOffset + 1;
                body.name = "SnakeBodyPart" + snakeBodyParts.Count;
                snakeBodyParts.Add(body);
            }

            points++;
            highestPoints = Mathf.Max(points, highestPoints);
        }

        public void StartGame()
        {
            snakeInput.EnableInput();
            snakeInput.MovementInput = Vector3.zero;
            transform.position = new Vector3(1, 1, 0);
            points = 0;
            foreach(var body in snakeBodyParts)
            {
                Destroy(body.gameObject);
            }
            snakeBodyParts.Clear();
            speed = Option.instance.speed;
            targetDirection = Vector3.zero;
            direction = Vector3.zero;
            transform.rotation = Quaternion.identity;
            
        }

        public void GameOver()
        {
            snakeInput.DisableInput();
            snakeInput.MovementInput = Vector3.zero;
            speed = 0;
            onGameOver?.Invoke();
            targetDirection = Vector3.zero;
            direction = Vector3.zero;
        }

        public void SetOffset()
        {
            bodyPartsOffset = Option.instance.bodyOffset;
        }

        public void ResetRecord()
        {
            highestPoints = 0;
        }
    }
}
