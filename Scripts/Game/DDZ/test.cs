using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
    public class test : MonoBehaviour
    {
        // Start is called before the first frame update
        SPGroup s;
    void Start()
        {
            s = GameObject.Find("SPGroup0").GetComponent<SPGroup>();
            s.Initialize(0);
            List<CardData> temp = new List<CardData>();
            for (int i = 0; i < 17; i++)
            {
                CardData data = new CardData("1",Random.Range(5,14));
                temp.Add(data);
            }
            s.ShowSP(temp);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
