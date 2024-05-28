using UnityEngine;

namespace SNAKE
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private Color baseColor, offsetColor;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void Init(bool isOffset)
        {
            spriteRenderer.color = isOffset ? offsetColor : baseColor;
        }
    }
}
