using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private Text txtTime;
    // Start is called before the first frame update
    void Start()
    {
        txtTime = Util.FindDeepChildAndGetComponent<Text>(transform, "Text");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetClock(Vector3 position,float time)
    {
        transform.position = position;
        StartCoroutine("StartClock", time);
    }
    public void StopClick()
    {
        StopCoroutine("StartClock");
    }
    private IEnumerator StartClock(float time)
    {
        while (time>0)
        {
            txtTime.text = time.ToString();
            time--;
            yield return new WaitForSeconds(1);
        }
    }
}
