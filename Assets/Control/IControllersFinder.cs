using System.Collections.Generic;

namespace Management.Control
{
    public  interface IControllersFinder
    {
        List<IController> CollectControllers();
    }
}