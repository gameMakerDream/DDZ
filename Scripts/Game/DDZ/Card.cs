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
        public bool select;
        void Awake()
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
            GetComponent<RectTransform>().pivot = vector;
            GetComponent<RectTransform>().anchorMin = vector;
            GetComponent<RectTransform>().anchorMax = vector;
        }
        public void Select()
        {
            if (select)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -Constants.spCardHeight[0] / 2);
                select = false;
            }
            else
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y+20);
                select = true;
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (CanOpreate())
            {
                
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {

            if (CanOpreate())
            {

            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {

            if (CanOpreate())
            {

            }
        }
        private bool CanOpreate()
        {
            return Constants.gameState == GameState.PlayCard;
        }
    }

}