using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointNClickItem : MonoBehaviour
{
    public GameObject[] itemDataUi;

    public void OnClickItem_1()
    {
        itemDataUi[0].SetActive(true);
    }

    public void OnClickItem_2()
    {
        itemDataUi[1].SetActive(true);
    }

    public void OnClickItem_3()
    {
        itemDataUi[2].SetActive(true);
    }

    public void OnClickItem_4()
    {
        itemDataUi[3].SetActive(true);
    }

    //case picked up key

    public void OnClickItem_Sp()
    {
        itemDataUi[4].SetActive(true);
    }

    public void OnClickOk()
    {
        foreach (var item in itemDataUi)
        {
            item.SetActive(false);
        }
    }
}
