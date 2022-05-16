namespace Management.Misc
{
    public class Result<T>
    {
        private bool m_Success;
        private T m_Object;

        public Result(bool success, T result)
        {
            m_Success = success;
            m_Object = result;
        }

        public bool IsSuccess()
        {
            return m_Success;
        }

        public T GetResultObject()
        {
            return m_Object;
        }
    }
}