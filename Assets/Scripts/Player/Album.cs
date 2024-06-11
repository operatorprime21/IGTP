using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Album : MonoBehaviour
{
    public List<GameObject> page = new List<GameObject>();
    public POVCamScripts povCam;
    public GameObject page1;
    public int curPage = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            PrevPage();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            NextPage();
        }
    }
    
    public void CreatePage()
    {
        GameObject newPage = Instantiate(page1, Vector3.zero, Quaternion.identity);
        //newPage.SetActive(true);
        newPage.transform.SetParent(this.gameObject.transform, false);
        newPage.name = page1.name;
        page.Add(newPage);
        povCam.showPicture = newPage.GetComponent<Image>();
    }

    public void NextPage()
    {
        //a_page.Play();
        if (curPage < page.Count - 1)
        {
            page[curPage].SetActive(false);
            curPage++;
            page[curPage].SetActive(true);
        }
    }

    public void PrevPage()
    {
        //a_page.Play();
        if (curPage != 0)
        {
            page[curPage].SetActive(false);
            curPage--;
            page[curPage].SetActive(true);
        }
    }
}
