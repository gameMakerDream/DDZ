using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler,IPointerUpHandler
{
    private Image imgIcon;
    // Start is called before the first frame update
    void Start()
    {
        imgIcon = Util.FindDeepChildAndGetComponent<Image>(transform,"BG");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(string iconName)
    {
        imgIcon.sprite=Resources.Load<Sprite>(PublicDefine.spritePath+"ddz/"+ iconName);
        name= iconName;
        gameObject.SetActive(true);
    }
    public void ChangeAnchors(Vector2 vector)
    {
        GetComponent<RectTransform>().pivot = vector;
        GetComponent<RectTransform>().anchorMin = vector;
        GetComponent<RectTransform>().anchorMax = vector;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}