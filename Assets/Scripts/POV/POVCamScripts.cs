using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class POVCamScripts : MonoBehaviour
{
    public float heightLimit;
    public float moveSpeed;
    [SerializeField] private float baseHeight;
    [SerializeField] private string moving;
    public Slider heightSlider;
    [SerializeField] private float heightCap;

    public CinemachineVirtualCamera vcm;
    public float scrollSpeed;
    public float zoomLimit;
    [SerializeField] private float baseZoom;
    public Slider zoomSlider;
    [SerializeField] private float zoomCap;

    public GameObject cameraObject;
    public float itemRange;
    public LayerMask itemMask;
    public GameObject testUI;

    public Image showPicture;
    public Album album;
    public GameObject camUI;
    public ObjectBase obj;

    private void Start()
    {
        baseHeight = this.transform.position.y;
        baseZoom = vcm.m_Lens.FieldOfView;
        heightCap = heightLimit * 2;
        zoomCap = zoomLimit * 2;
        Defaults();
    }

    public void Defaults()
    {
        this.transform.position = new Vector3(this.transform.position.x, baseHeight, this.transform.position.z);
        vcm.m_Lens.FieldOfView = baseZoom;
    }
    private void Update()
    {
        ShiftingInputs();
        ScrollInputs();
        HeightSlider();
        ZoomSlider();
        if(cameraObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(TakePicture());
                camUI.SetActive(false);
            }
            if(ItemInPictureCheck())
            {
                testUI.SetActive(true);
            }
            else testUI.SetActive(false);
        }
    }

    private void ShiftingInputs()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moving = ShiftingLogic("up");
        }

        if (Input.GetKey(KeyCode.S))
        {
            moving = ShiftingLogic("down");
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            moving = "none";
        }

        Shift();
    }
    private string ShiftingLogic(string dir)
    {
        if (dir == "up")
        {
            if (this.transform.position.y - baseHeight >= heightLimit)
            {
                return "none";
            }
            else return dir;
        }
        else if (dir == "down")
        {
            if (baseHeight - this.transform.position.y >= heightLimit)
            {
                return "none";
            }
            else return dir;
        }
        else return "none";
    }
    private void Shift()
    {
        switch (moving)
        {
            case "up":
                this.transform.position += this.transform.up * moveSpeed;
                break;
            case "down":
                this.transform.position -= this.transform.up * moveSpeed;
                break;
        }
    }
    private void HeightSlider()
    {
        heightSlider.value = (this.transform.position.y - baseHeight + heightLimit) / heightCap;
    }

    private void ScrollInputs()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            if(baseZoom - vcm.m_Lens.FieldOfView <= zoomLimit)
            {
                vcm.m_Lens.FieldOfView -= Input.mouseScrollDelta.y * scrollSpeed;
            }
        }
        else if(Input.mouseScrollDelta.y < 0)
        {
            if (vcm.m_Lens.FieldOfView - baseZoom <= zoomLimit)
            {
                vcm.m_Lens.FieldOfView -= Input.mouseScrollDelta.y * scrollSpeed;
            }
        }
    }
    private void ZoomSlider()
    {
        zoomSlider.value = (zoomCap -(vcm.m_Lens.FieldOfView - baseZoom + zoomLimit)) / zoomCap;
    }

    private bool ItemInPictureCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraObject.transform.position, cameraObject.transform.TransformDirection(Vector3.forward), out hit, itemRange, itemMask))
        {
            Vector3 hitAngle = hit.point - cameraObject.transform.position;
            Vector3 centerAngle = hit.transform.gameObject.transform.position - cameraObject.transform.position;
            if (Vector3.Angle(hitAngle, centerAngle) <= 5)
            {
                obj = hit.transform.gameObject.GetComponent<ObjectBase>();
                return true;
            }
            else return false;
        }
        else return false;
    }

    private IEnumerator TakePicture()
    {
        album.CreatePage();
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
        if (ItemInPictureCheck() == true)
        {
            RecordPicture();
        }
    }

    private void RecordPicture()
    {

    }
}
