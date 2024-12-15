using Nakaya.UI;
using UnityEngine;

public class ExitButton : CommonSelectableButton
{
    void Start()
    {
        AddPressAction(() => Debug.Log("Exit"));
    }
}
