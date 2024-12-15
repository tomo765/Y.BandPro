using System.Collections;
using System.Collections.Generic;

namespace Nakaya.UI
{
    public class ReselectNode
    {
        private ISelectableUI m_Next;

        private ReselectNode() { }
        public ReselectNode(ISelectableUI next)
        {
            m_Next = next;
        }

        public ISelectableUI Reselect()
        {
            m_Next.Select();
            return m_Next;
        }
    }
}