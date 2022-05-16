using System.Collections.Generic;
using UnityEngine;

namespace Management.Control
{
    public class ControllersStorage : MonoBehaviour
    {
        private List<IController> m_Controllers = new List<IController>();

        private List<IController> CollectControllers()
        {
            List<IController> list = new List<IController>();
            IControllersCreator creator = new ControllersCreator();
            IControllersFinder finder = new ControllersFinder();
            list.AddRange(creator.Create());
            list.AddRange(finder.CollectControllers());
            return list;
        }

        private void PreInit()
        {
            for (int i = 0; i < m_Controllers.Count; i++)
            {
                m_Controllers[i].PreInit();
            }
        }

        private void LinkContorllers()
        {
            for (int i = 0; i < m_Controllers.Count; i++)
            {
                if (m_Controllers[i] is ILinkControllers controller)
                {
                    controller.LinkControllers(m_Controllers);
                }
            }
        }

        private void Init()
        {
            for (int i = 0; i < m_Controllers.Count; i++)
            {
                m_Controllers[i].Init();
            }
        }

        private void Start()
        {
            m_Controllers = CollectControllers();
            PreInit();
            LinkContorllers();
            Init();
        }
    }
}
