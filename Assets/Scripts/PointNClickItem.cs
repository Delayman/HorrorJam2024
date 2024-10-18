using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointNClickItem : MonoBehaviour
{
    public GameObject[] itemDataUi;
    public GameObject itemFrame;
    public GameObject itemFrameBtn;
    public GameObject itemFrameFallenBtn;
    public GameObject key;

    private bool isPickUpKey;

    public void OnClickItem_1()
    {
        itemDataUi[0].SetActive(true);
        itemDataUi[0].GetComponent<Animator>().SetBool("IsUp", true);
    }

    public void OnClickItem_2()
    {
        itemDataUi[1].SetActive(true);
        itemDataUi[1].GetComponent<Animator>().SetBool("IsUp", true);
    }

    public void OnClickItem_3()
    {
        itemDataUi[5].SetActive(true);
        itemDataUi[5].GetComponent<Animator>().SetBool("IsUp", true);
    }

    public void OnClickItem_4()
    {
        itemDataUi[3].SetActive(true);
        itemDataUi[3].GetComponent<Animator>().SetBool("IsUp", true);

        if(!isPickUpKey) return;

        itemDataUi[4].SetActive(true);
        itemDataUi[4].GetComponent<Animator>().SetBool("IsUp", true);
        
    }

    public void OnClickItem_Key()
    {
        isPickUpKey = true;
        key.SetActive(false);
    }

    //case picked up key

    public void OnClickItem_Sp()
    {
        itemFrame.GetComponent<Rigidbody>().useGravity = true;
        itemDataUi[2].GetComponent<Animator>().SetBool("IsUp", true);
        itemFrameBtn.SetActive(false);
        itemFrameFallenBtn.SetActive(true);
    }

    public void OnClickOk()
    {
        foreach (var item in itemDataUi)
        {
            item.GetComponent<Animator>().SetBool("IsUp", false);
        }
    }
}
