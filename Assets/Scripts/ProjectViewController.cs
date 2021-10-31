using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class ProjectViewController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    private VideoPlayer videoPlayer;
    private PlayPauseController playPauseController;
    
    private void Start()
    {
        playPauseController = transform.parent.GetComponentInChildren<PlayPauseController>();
    }

    private void OnEnable()
    {
        ManagerGame.Instance.SetState(ManagerGame.State.Project);
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Prepare();
        videoPlayer.loopPointReached += ResetVideo;
    }

    public void OnProjectViewClose()
    {
        ManagerGame.Instance.SetState(ManagerGame.State.Play);
    }

    public void PlayPause()
    {
        if (!videoPlayer.isPlaying)
            videoPlayer.Play();
        else
            videoPlayer.Pause();

    }

    void ResetVideo(VideoPlayer vp)
    {
        videoPlayer.time = 0;
        playPauseController.SetIsPlay(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        playPauseController.EnterHover();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        playPauseController.ExitHover();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        playPauseController.MoveHover();
    }
}
