using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DDZ
{
    public class PlayerHead : MonoBehaviour,IIndexer
    {
        private Image imgIcon;
        private Image imgTG;
        private Image imgDZ;
        private Text txtName;
        private Text txtCoin;
        private GameObject spLeft;
        private GameObject spRight;
        private Text txtSPLeft;
        private Text txtSPRight;

        public int seatIndex 
        {
            get;
            set;
        }

        public void Initialize(int seatIndex)
        {
            this.seatIndex = seatIndex;
            FindChild();
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        private void FindChild()
        {
            imgIcon = Util.FindDeepChildAndGetComponent<Image>(transform, "imgIcon");
            imgTG = Util.FindDeepChildAndGetComponent<Image>(transform, "imgTG");
            imgDZ = Util.FindDeepChildAndGetComponent<Image>(transform, "imgDZ");
            txtName = Util.FindDeepChildAndGetComponent<Text>(transform, "txtName");
            txtCoin = Util.FindDeepChildAndGetComponent<Text>(transform, "txtCoin");
            txtSPLeft = Util.FindDeepChildAndGetComponent<Text>(transform, "txtSPLeft");
            txtSPRight = Util.FindDeepChildAndGetComponent<Text>(transform, "txtSPRight");
            spLeft = Util.FindDeepChild(transform, "spLeft").gameObject;
            spRight = Util.FindDeepChild(transform, "spRight").gameObject;
        }
        // Update is called once per frame
        void Update()
        {
        }



        public void SitDown(PlayerData playerData)
        {
            imgIcon.sprite = Resources.Load<Sprite>(PublicDefine.spritePath+"ddz/icon"+playerData.iconIndex);
            txtName.text = playerData.nickName;
            txtCoin.text = Util.Number2String(playerData.coin);
            gameObject.SetActive(true);
        }
        public void SitUp()
        {
            imgIcon.sprite = null;
            txtName.text = string.Empty;
            txtCoin.text = string.Empty;
            gameObject.SetActive(false);
        }
        public void ShowSPLeft()
        {
            if (seatIndex == 1)
                spLeft.SetActive(true);
            else if (seatIndex == 2)
                spRight.SetActive(true);
        }
        public void HideSPLeft()
        {
            if (seatIndex == 1)
                spLeft.SetActive(false);
            else if (seatIndex == 2)
                spRight.SetActive(false);
        }
        public void SetSPLeft(int count)
        {
            txtSPLeft.text = count.ToString();
            txtSPRight.text = count.ToString();
        }

    }
}
