namespace Sparrow.Extensions
{
    public class JsonOperationContext
    {
        public AllocatedMemoryData GetMemory(int size)
        {
            // Выделение памяти.
            return new AllocatedMemoryData();
        }
    }
}