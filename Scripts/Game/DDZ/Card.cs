using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
namespace DDZ
{
    public class Card : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
    {
        private Image imgIcon;
        // Start is called before the first frame update
        public RectTransform rectTransform;
        private Tween tween;
        [HideInInspector]
        private bool select;
        public void Initialize()
        {
            imgIcon = Util.FindDeepChildAndGetComponent<Image>(transform, "BG");
            rectTransform = GetComponent<RectTransform>();
            select = false;
        }
        // Update is called once per frame
        void Update()
        {
        }

        public void SetIcon(string iconName)
        {
            string path = PublicDefine.spritePath + "ddz/" + iconName;
            imgIcon.sprite = Resources.Load<Sprite>(path);
        }
        public void SetColor(Color color)
        {
            imgIcon.color=color;
        }
        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        public void ChangeAnchors(Vector2 vector)
        {
            GetComponent<RectTransform>().anchorMin = vector;
            GetComponent<RectTransform>().anchorMax = vector;
        }
        public void ChangePivot(Vector2 vector)
        {
            GetComponent<RectTransform>().pivot = vector;
        }
        public void Select()
        {
            if (select)
                Select(false);
            else
                Select(true);
        }
        public void Select(bool select)
        {
            if (this.select == select)
                return;
            if (select)
                rectTransform.DOAnchorPosY(-Constants.spCardHeight[0] / 2 + 20, 0.1f).SetEase(Ease.Linear);
            else
                rectTransform.DOAnchorPosY(-Constants.spCardHeight[0] / 2, 0.1f).SetEase(Ease.Linear);
            this.select = select;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (CanOpreate())
            {
                Constants.startDrag = true;
                Constants.startDragCardIndex = transform.GetSiblingIndex();
                Constants.endDragCardIndex = transform.GetSiblingIndex();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {

            if (CanOpreate())
            {
                Constants.endDragCardIndex = transform.GetSiblingIndex();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {

            if (CanOpreate())
            {
                Constants.endDrag = true;
            }
        }
        private bool CanOpreate()
        {
            return true;
        }
        public bool IsSelect()
        {
            return select;
        }
    }

}