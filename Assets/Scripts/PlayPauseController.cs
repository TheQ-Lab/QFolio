using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayPauseController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite playSprite;
    public Sprite pauseSprite;

    private ProjectViewController projectViewController;
    private Image image;
    private Button button;

    //private bool hoverVideo;
    private bool hoverButton;
    private bool isPlay = false;
    private float remainingIconShowTime = -1f;
    private readonly float maxIconShowTime = 1.1f;


    // Start is called before the first frame update
    void Start()
    {
        projectViewController = transform.parent.GetComponentInChildren<ProjectViewController>();
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    public void EnterHover()
    {
        //Debug.Log("Hover");
        //hoverVideo = true;
        Undim();
        InitializeDim();
    }

    public void MoveHover()
    {
        Undim();
        InitializeDim();
    }

    public void ExitHover()
    {
        //hoverVideo = false;
        InitializeDim();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //((IPointerEnterHandler)button).OnPointerEnter(eventData);
        hoverButton = true;
        Undim();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        hoverButton = false;
        InitializeDim();
    }

    private void InitializeDim()
    {
        remainingIconShowTime = maxIconShowTime;
    }

    private void Undim()
    {
        image.CrossFadeAlpha(1f, 0.3f, false);
    }

    private void FixedUpdate()
    {
        if (isPlay)
        {
            if (!hoverButton)
            {
                if(remainingIconShowTime > 0f)
                    remainingIconShowTime = Mathf.Max(remainingIconShowTime-Time.fixedDeltaTime, 0f);
                if(remainingIconShowTime == 0f)
                {
                    image.CrossFadeAlpha(0f, 0.5f, false);
                    remainingIconShowTime = -1f;
                }
            }
        }
    }

    public void OnClickPlayPause()
    {
        //Debug.Log("click");
        isPlay = !isPlay;
        if (!isPlay)
            image.sprite = playSprite;
        else
            image.sprite = pauseSprite;
        projectViewController.PlayPause();
        //StartCoroutine(Dim(1f));
    }

    public void SetIsPlay(bool b)
    {
        isPlay = b;
    }

    private void DimIcon()
    {

    }

    private void UndimIcon()
    {

    }

    // Test for continuous Coroutine
    /*
    IEnumerator Dim(float dimTime)
    {
        while (dimTime > 0)
        {
            Debug.Log("Dim");
            
            dimTime -= Time.fixedDeltaTime;
        }
        yield return new WaitForEndOfFrame();
    }*/


}
