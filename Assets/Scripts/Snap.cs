using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SNAKE
{
    public class Snap : MonoBehaviour
    {
        public ScrollRect scrollRect;
        public RectTransform contentPanel;
        public RectTransform sampleListItem;
        public HorizontalLayoutGroup horizontalLayoutGroup;
        public List<UnityEvent> itemSelectedAction;
        private bool isSnapped;
        private float snapForce = 500;
        private float snapSpeed;

        private void Awake()
        {
            isSnapped = false;
        }

        private void Update()
        {
            int currentItem = Mathf.RoundToInt(0 - contentPanel.localPosition.x / (sampleListItem.rect.width + horizontalLayoutGroup.spacing));
            if (scrollRect.velocity.magnitude < 800 && !isSnapped)
            {
                scrollRect.velocity = Vector2.zero;
                snapSpeed += snapForce * Time.deltaTime;
                contentPanel.localPosition = new Vector3(
                                                Mathf.MoveTowards(contentPanel.localPosition.x, 0 - (currentItem * (sampleListItem.rect.width + horizontalLayoutGroup.spacing)), snapSpeed),
                                                contentPanel.localPosition.y,
                                                contentPanel.localPosition.z);
                if (Mathf.Approximately(contentPanel.localPosition.x, 0 - (currentItem * (sampleListItem.rect.width + horizontalLayoutGroup.spacing))))
                {
                    isSnapped = true;
                }
            }
            if (scrollRect.velocity.magnitude > 800)
            {
                isSnapped = false;
                snapSpeed = 0;
            }
            itemSelectedAction[currentItem]?.Invoke();
        }

        public void RandomizeOptions()
        {
            int randomIndex = Random.Range(0, itemSelectedAction.Count - 1);
            contentPanel.localPosition = new Vector3(
                                0 - (randomIndex * (sampleListItem.rect.width + horizontalLayoutGroup.spacing)),
                                contentPanel.localPosition.y,
                                contentPanel.localPosition.z);
        }

        public void ResetOptions()
        {
            contentPanel.localPosition = new Vector3(0, contentPanel.localPosition.y, contentPanel.localPosition.z);
        }
    }
}
