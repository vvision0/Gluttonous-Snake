using UnityEngine;

namespace SNAKE
{
    public class Option : MonoBehaviour
    {
        public static Option instance;
        public Settings selectedSettings;

        [Header("MapSize")]
        public int mapWidth;
        public int mapHeight;
        public float cameraDistance;
        public int wallIndex;
        public enum MapSize
        {
            Small,
            Middle,
            Big
        }

        [Header("MoveSpeed")]
        public float speed;
        public int bodyOffset;
        public enum MoveSpeed
        {
            Slow,
            Middle,
            Fast
        }

        [Header("Food Amount")]
        public int foodAmount;
        public enum FoodAmount
        {
            Little,
            Middle,
            Many
        }

        public struct Settings
        {
            public MapSize mapSize;
            public MoveSpeed moveSpeed;
            public FoodAmount foodAmount;
        };

        private void Awake()
        {
            instance = this;
            UpdateMapSize();
            UpdateMoveSpeed();
            UpdateFoodAmount();
        }

        private void Update()
        {
            UpdateMapSize();
            UpdateMoveSpeed();
            UpdateFoodAmount();
        }

        public void UpdateMapSize()
        {
            switch (selectedSettings.mapSize)
            {
                case MapSize.Small : 
                {
                    mapWidth = 16;
                    mapHeight = 9;
                    cameraDistance = -7.5f;
                    wallIndex = 0;
                    break;
                }
                case MapSize.Middle : 
                {
                    mapWidth = 32;
                    mapHeight = 18;
                    cameraDistance = -15.5f;
                    wallIndex = 1;
                    break;
                }
                case MapSize.Big : 
                {
                    mapWidth = 48;
                    mapHeight = 27;
                    cameraDistance = -23.5f;
                    wallIndex = 2;
                    break;
                }
                default :
                {
                    mapWidth = 16;
                    mapHeight = 9;
                    cameraDistance = -8f;
                    wallIndex = 0;
                    break;
                }
            }
        }

        public void UpdateMoveSpeed()
        {
            switch (selectedSettings.moveSpeed)
            {
                case MoveSpeed.Slow :
                {
                    speed = 5f;
                    bodyOffset = 40;
                    break;
                }
                case MoveSpeed.Middle :
                {
                    speed = 10f;
                    bodyOffset = 20;
                    break;
                }
                case MoveSpeed.Fast :
                {
                    speed = 25f;
                    bodyOffset = 10;
                    break;
                }
                default :
                {
                    speed = 5f;
                    bodyOffset = 40;
                    break;
                }
            }
        }

        public void UpdateFoodAmount()
        {
            switch (selectedSettings.foodAmount)
            {
                case FoodAmount.Little :
                {
                    foodAmount = 1;
                    break;
                }
                case FoodAmount.Middle :
                {
                    foodAmount = 3;
                    break;
                }
                case FoodAmount.Many :
                {
                    foodAmount = 5;
                    break;
                }
                default :
                {
                    foodAmount = 1;
                    break;
                }
            }
        }

        public void SwitchMapSize(int sizeIndex)
        {
            switch (sizeIndex)
            {
                case 0 : selectedSettings.mapSize = MapSize.Small; 
                         break;
                case 1 : selectedSettings.mapSize = MapSize.Middle;
                         break;
                case 2 : selectedSettings.mapSize = MapSize.Big;
                         break;
            }
        }

        public void SwitchMoveSpeed(int speedIndex)
        {
            switch (speedIndex)
            {
                case 0 : selectedSettings.moveSpeed = MoveSpeed.Slow; 
                         break;
                case 1 : selectedSettings.moveSpeed = MoveSpeed.Middle;
                         break;
                case 2 : selectedSettings.moveSpeed = MoveSpeed.Fast;
                         break;
            }
        }

        public void SwitchFoodAmount(int amountIndex)
        {
            switch (amountIndex)
            {
                case 0 : selectedSettings.foodAmount = FoodAmount.Little; 
                         break;
                case 1 : selectedSettings.foodAmount = FoodAmount.Middle;
                         break;
                case 2 : selectedSettings.foodAmount = FoodAmount.Many;
                         break;
            }
        }
    }
}
