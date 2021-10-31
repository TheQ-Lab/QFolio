using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame Instance;

    public enum State {Play, Pause, Dialogue, Project};
    public State state = State.Play;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(transform.parent);
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    public void SetState(State _state)
    {
        if (_state == State.Play)
        {
            Time.timeScale = 1f;
        }
        else if (_state == State.Pause)
        { }
        else if (_state == State.Dialogue)
        { }
        else if (_state == State.Project)
        { }

        state = _state;

        Debug.Log("GameState set to " + state.ToString());
    }

}
