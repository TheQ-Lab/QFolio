using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{

    // make sure, that character is immovable
    private void OnEnable()
    {
        ManagerGame.Instance.SetState(ManagerGame.State.Dialogue);
    }

    public void OnDialogueContinue()
    {
        if (transform.GetSiblingIndex() + 1 >= transform.parent.childCount)
        {
            // reset Dialogue State
            ManagerGame.Instance.SetState(ManagerGame.State.Play);
            gameObject.SetActive(false);
            transform.parent.gameObject.SetActive(false);
            transform.parent.GetChild(0).gameObject.SetActive(true);
            return;
        }
        else
        {
            // activate next Dialogue Box
            transform.parent.GetChild(transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    
}
