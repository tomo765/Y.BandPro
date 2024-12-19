using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nakaya.UI
{
    /// <summary> ISelectableUI のオブジェクトを管理するコンテナUIのベースクラス </summary>
    public abstract class SelectableGroupBase : MonoBehaviour
    {
        /// <summary> 継承先のクラスで押したボタンに応じて選択する ISelectableUI を変更するために使う</summary>
        protected Dictionary<ISelectableUI, ReselectNodeContainer> m_Selectables = new Dictionary<ISelectableUI, ReselectNodeContainer>();


        /// <summary> 最初に選択するUIを取得する </summary>
        /// <remarks> 継承先のクラスで指定する </remarks>
        public abstract ISelectableUI GetInitSelect();

        public bool TryReselectUI(string dir, ISelectableUI current, out ISelectableUI next)
        {
            next = m_Selectables[current].Reselect(dir);
            return next != null;
        }

        public void SetActive(bool b) => gameObject.SetActive(b);
    }
}