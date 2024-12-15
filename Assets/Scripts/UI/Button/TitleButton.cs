using Nakaya.UI;
using UnityEngine;

public class TitleButton : CommonSelectableButton
{
    void Start()
    {
        AddPressAction(() => Debug.Log("Play"));
    }
}
