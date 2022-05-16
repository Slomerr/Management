using System.Collections.Generic;

namespace Management.Control
{
    public interface IControllersCreator
    {
        List<IController> Create();
    }
}