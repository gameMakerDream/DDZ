using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    private Text[] txtArray;
    // Start is called before the first frame update
    public void Initialize()
    {
        txtArray = GetComponentsInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Show(string[] leftCardArray)
    {
        gameObject.SetActive(true);
        transform.DOScaleX(1, 0.5f);
    }
    public void Hide()
    {
        transform.DOScaleX(0, 0.5f).OnComplete(() => 
        {
            gameObject.SetActive(false);
        });
    }
    public void Set(string[] leftCardArray)
    {
        int[] _valueArray = Translate(leftCardArray);
        int _index = 3;
        for (int i = 0; i < txtArray.Length; i++)
        {
            txtArray[i].text = _valueArray[_index++].ToString();
        }
    }
    private int[] Translate(string[] array)
    {
        int[] _result=new int[18];
        int[] _temp= new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            _temp[i] = int.Parse(array[i].Substring(1, 2));
        }
        for (int i = 0; i < _result.Length; i++)
        {
            _result[_temp[i]]++;
        }
        return _result;
    }
}
