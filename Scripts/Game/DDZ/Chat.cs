using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour, IIndexer
{
    public int seatIndex { get; set; }
    private Image icon;
    public void Initialize(int seatIndex)
    {
        this.seatIndex = seatIndex;
        icon = Util.FindDeepChildAndGetComponent<Image>(transform, "BG");
    }

    public void ShowChat(string iconName)
    {
        icon.sprite = Resources.Load<Sprite>(PublicDefine.spritePath+"ddz/chat/"+iconName);
        gameObject.SetActive(true);
    }
    public void HideChat()
    {
        gameObject.SetActive(false);
    }
}
