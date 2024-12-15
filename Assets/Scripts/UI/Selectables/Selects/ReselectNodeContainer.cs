using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Nakaya.UI
{
    public class ReselectNodeContainer
    {
        private ReselectNode m_Right;
        private ReselectNode m_Left;
        private ReselectNode m_Top;
        private ReselectNode m_Bottom;

        private ReselectNodeContainer() { }
        public ReselectNodeContainer(ReselectNode right = null, ReselectNode left = null, ReselectNode top = null, ReselectNode bottom = null)
        {
            m_Right = right;
            m_Left = left;
            m_Top = top;
            m_Bottom = bottom;
        }

        public ISelectableUI Reselect(string dir)
        {
            return (dir) switch
            {
                InputActions.InputSettings.UI.Right => m_Right?.Reselect(),
                InputActions.InputSettings.UI.Left => m_Left?.Reselect(),
                InputActions.InputSettings.UI.Up => m_Top?.Reselect(),
                InputActions.InputSettings.UI.Down => m_Bottom?.Reselect(),
                _ => null
            };
        }
    }

    public enum Dirction  //Fixme : 仮置き, InputSystem のキーバインドに変更する
    {
        Right,
        Left,
        Top,
        Bottom
    }
}