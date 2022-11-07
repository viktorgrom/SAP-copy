using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGUIManager : MonoBehaviour
{
    public void ShowGameFinishWindow(int NumStars)
    {
        GameObject go = Instantiate(Resources.Load("CanvasFinishWindow")) as GameObject;
        
        go.GetComponent<RectTransform>().localPosition = new Vector3(960f, 540f, 0);
        Debug.Log(NumStars);
        go.transform.GetChild(0).GetChild(2).GetChild(NumStars).GetComponent<Image>().enabled = true;
       // Debug.Log(Stats.instance.ScoreLevel.ToString());
       //go.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Text>().text = Stats.instance.ScoreLevel.ToString();
    }
}

