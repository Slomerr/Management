using Management.Command;
using UnityEngine;

namespace Management.UI.CommandsView
{
    public class CommandsLotCreator : MonoBehaviour
    {
        [SerializeField] private RectTransform m_ItemsRoot;
        [SerializeField] private CommandView m_PrefabLot;

        public ICommandLot Create(ICommand command)
        {
            var view = Instantiate(m_PrefabLot, m_ItemsRoot);
            return new CommandLot(view, command);
        }
    }
}
