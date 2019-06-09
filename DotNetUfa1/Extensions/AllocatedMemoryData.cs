using System;

namespace Sparrow.Extensions
{
    public unsafe class AllocatedMemoryData
    {
        public int SizeInBytes;
        public int ContextGeneration;


#if MEM_GUARD_STACK || TRACK_ALLOCATED_MEMORY_DATA
        public string AllocatedBy = Environment.StackTrace;
        public string FreedBy;
#endif

#if !DEBUG
        public byte* Address;
#else
        public bool IsLongLived;
        public bool IsReturned;
        private byte* _address;
        public byte* Address
        {
            get
            {
                if (this.IsLongLived == false &&
                    this.IsReturned)
                    this.ThrowObjectDisposedException();

                return this._address;
            }
            set
            {
                if (this.IsLongLived == false &&
                    this.IsReturned)
                    this.ThrowObjectDisposedException();

                this._address = value;
            }
        }

        private void ThrowObjectDisposedException()
        {
            throw new ObjectDisposedException(nameof(AllocatedMemoryData));
        }
#endif

    }
}