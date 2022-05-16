
using Management.Command;
using System.Collections.Generic;
using UnityEngine;

namespace Management.UI.CommandsView
{
    public class CommandsViewGenerator
    {
        private CommandsLotCreator m_Creator;
        private List<ICommandLot> m_Lots;

        public CommandsViewGenerator(CommandsLotCreator creator)
        {
            m_Creator = creator;
            m_Lots = new List<ICommandLot>();
        }

        public void GenerateView(List<ICommand> commands)
        {
            if (commands != null && 0 < commands.Count)
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    GenerateView(commands[i], i);
                }
            }
        }

        public void GenerateView(ICommand command, int index)
        {
            if (command != null && 0 <= index)
            {
                if (m_Creator != null)
                {
                    m_Lots.Insert(index, m_Creator.Create(command));
                    m_Lots[index].SetSibling(index);
                }
                else
                {
                    Debug.LogError("CommandsLotCreator is null in CommandsViewGenerator at GenerateView");
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (0 <= index && index < m_Lots.Count)
            {
                m_Lots[index].Clear();
                m_Lots.RemoveAt(index);
            }
        }

        public void Clear()
        {
            foreach (var lot in m_Lots)
            {
                lot.Clear();
            }

            m_Lots.Clear();
        }
    }
}
