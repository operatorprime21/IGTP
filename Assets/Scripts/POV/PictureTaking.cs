using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PictureTaking : MonoBehaviour
{
    public Image showPicture;
    public GameObject camUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(TakePicture());
            camUI.SetActive(false);
        }
    }
    private IEnumerator TakePicture()
    {
        yield return new WaitForEndOfFrame();
        Texture2D pic = ScreenCapture.CaptureScreenshotAsTexture();

        Texture2D newPic = new Texture2D(pic.width, pic.height, TextureFormat.RGB24, false);
        newPic.SetPixels(pic.GetPixels());
        newPic.Apply();

        Destroy(pic);

        Sprite picSprite = Sprite.Create(newPic, new Rect(0, 0, newPic.width, newPic.height), new Vector2(0.5f, 0.5f));
        showPicture.enabled = true;
        showPicture.sprite = picSprite;
        camUI.SetActive(true);
    }
}
