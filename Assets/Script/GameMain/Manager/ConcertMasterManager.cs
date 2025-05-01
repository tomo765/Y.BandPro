using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConcertMasterManager : SingletonBehaviour<ConcertMasterManager>
{
    private ConcertMasterModel m_ConcertMasterModel;

    [SerializeField] private ConcertMasterObject m_ConcertMasters;

    private void Start()
    {
        m_ConcertMasterModel = new ConcertMasterModel(m_ConcertMasters);
    }

    public void CheckMatchFiewColor()
    {
        bool isMatch = true;
        var allColor = GameDataManager.Instance.FiewsModel.AllFiewColor;


        if (allColor.Contains(ColorType.White)) { isMatch = false; }
        else if (allColor.Length != 3) { isMatch = false; }
        else if(allColor.Distinct().Count() != 1) {  isMatch = false; }


        if (isMatch)
        {
            InCome(ScriptablesManager.Instance.ActorSprites.GetActorSprite(allColor[0]));
        }
        else
        {
            OutCome();
        }
    }


    private void InCome(Sprite sprite) => m_ConcertMasterModel.InCome(sprite);
    private void OutCome() => m_ConcertMasterModel.OutCome();
}
