using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private int sec;
    [SerializeField] private int min; 

    [SerializeField] private TMP_Text timer;
    IEnumerator SecM()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = -1;
            }
            sec = sec + 1;
            timer.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    } 
    IEnumerator TTimer() 
    {
        while (true)
        {
            if (sec == 00 && min >= 1)
            {
                min--; sec = 60;
            }
            if (sec == 1 && min == 0)
            {
            StopAllCoroutines(); 
            }

            sec = sec - 1;
            timer.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    } 
    public void SecMer()
    {
        StopAllCoroutines();
        StartCoroutine(SecM()); 
    }
    public void Timmer()
    {
        StopAllCoroutines();
        StartCoroutine(TTimer());
    }
    public void Stop()
    {
        StopAllCoroutines();
    }
}
