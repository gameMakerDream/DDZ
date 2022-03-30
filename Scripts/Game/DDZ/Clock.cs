using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private Text txtTime;
    // Start is called before the first frame update
    public void Initialize()
    {
        txtTime = Util.FindDeepChildAndGetComponent<Text>(transform, "Text");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetClock(Vector3 position,float time)
    {
        StopClock();
        transform.position = position;
        gameObject.SetActive(true);
        StartCoroutine("StartClock", time);
    }
    public void StopClock()
    {
        StopCoroutine("StartClock");
        gameObject.SetActive(false);
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
