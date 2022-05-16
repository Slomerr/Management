using Management.Command;
using UnityEngine;

namespace Management.UI.CommandsView
{
    public class CommandLot : ICommandLot
    {
        private CommandView m_View;
        private ICommand m_Command;

        public CommandLot(CommandView view, ICommand command)
        {
            m_View = view;
            m_Command = command;
            m_View.SetName(m_Command.GetType().Name);
        }

        public void Clear()
        {
            GameObject.Destroy(m_View.gameObject);
        }

        public void SetSibling(int sibling)
        {
            m_View.SetSibling(sibling);
        }
    }
}