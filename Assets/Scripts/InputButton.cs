using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputButton : MonoBehaviour
{
    public bool left;

    public Player player;

    private void OnMouseDown()
    {
        if (left)
        {
            player.OnLeftPressed();
        } else
        {
            player.OnRightPressed();
        }
    }
}
