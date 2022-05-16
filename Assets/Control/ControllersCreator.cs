using Management.CharacterControl;
using System.Collections.Generic;

namespace Management.Control
{
    public class ControllersCreator : IControllersCreator
    {
        public List<IController> Create()
        {
            List<IController> list = new List<IController>()
            {
                new AIController()
            };

            return list;
        }
    }
}