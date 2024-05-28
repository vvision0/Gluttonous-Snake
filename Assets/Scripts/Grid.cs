using System.Collections.Generic;
using UnityEngine;

namespace SNAKE
{
    public class GridGenerator : MonoBehaviour
    {
        
        public List<Tile> tiles;
        public GameObject[] walls;
        private int width, height;
        [SerializeField] private Tile tilePrefab;
        [SerializeField] private Transform cameraPosition;
        private int index;

        private void Start()
        {
            GenerateGrid();
            tiles = new List<Tile>();
        }

        public void GenerateGrid()
        {
            width = Option.instance.mapWidth;
            height = Option.instance.mapHeight;

            if (tiles.Count != 0)
            {
                DestroyGrid();
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Tile spawnedTiles = Instantiate(tilePrefab, new Vector3(i, j), Quaternion.identity);
                    spawnedTiles.transform.SetParent(this.transform);
                    spawnedTiles.name = $"Tile {i} {j}";

                    tiles.Add(spawnedTiles);

                    bool isOffset = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0);
                    spawnedTiles.Init(isOffset);
                }
            }

            cameraPosition.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, Option.instance.cameraDistance);
        }

        public void DestroyGrid()
        {
            foreach(var tile in tiles)
            {
                Destroy(tile.gameObject);
            }
            tiles.Clear();
        }

        public void EnableWall()
        {
            index = Option.instance.wallIndex;
            for (int i = 0; i < walls.Length; i++)
            {
                if (i == index)
                {
                    walls[i].SetActive(true);
                }
                else
                {
                    walls[i].SetActive(false);
                }
            }
        }
    }
}
