using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelectorController : MonoBehaviour
{
    
    private GameObject[] arrayAvatars;
    private int i;
    
    // Start is called before the first frame update
    void Start()
    {
        arrayAvatars = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            arrayAvatars[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject avatar in arrayAvatars)
        {
            avatar.SetActive(false);
        }

        if (arrayAvatars[0])
        {
            i = 0;
            arrayAvatars[i].SetActive(true);
            PlayerPrefs.SetInt("AvatarSelected",i);
        }
    }

    public void ChangeLeft()
    {
        arrayAvatars[i].SetActive(false);
        i--;
        if (i<0)
        {
            i = arrayAvatars.Length - 1;
        }
        arrayAvatars[i].SetActive(true);
        PlayerPrefs.SetInt("AvatarSelected",i);
    }
    
    public void ChangeRight()
    {
        arrayAvatars[i].SetActive(false);
        i++;
        if (i>arrayAvatars.Length - 1)
        {
            i = 0;
        }
        arrayAvatars[i].SetActive(true);
        PlayerPrefs.SetInt("AvatarSelected",i);
    }
    
}
