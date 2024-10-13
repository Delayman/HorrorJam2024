using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointNClickItem : MonoBehaviour
{
    public GameObject[] itemDataUi;

    public void OnClickTEST()
    {
        itemDataUi[0].SetActive(true);
    }

    public void OnClickOk()
    {
        foreach (var item in itemDataUi)
        {
            item.SetActive(false);
        }
    }
}
