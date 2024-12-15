using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nakaya.UI
{
    public class UISelector : MonoBehaviour
    {
        [SerializeField] private SelectableGroupBase m_CurrentSelectGroup;
        private ISelectableUI m_CurentSelect;
        private ISelectableUI m_PrevSelect;

        public void Reselect(ISelectableUI newSelect)
        {
            m_PrevSelect = m_CurentSelect;
            m_CurentSelect = newSelect;
        }

        void Start()
        {
            m_CurentSelect = m_CurrentSelectGroup.GetInitSelect();
        }


        void Update()
        {

        }
    }
}

