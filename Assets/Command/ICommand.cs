using System;

namespace Management.Command
{
    public interface ICommand 
    {
        void Execute(Action callback);
        void Abort();
    }
}