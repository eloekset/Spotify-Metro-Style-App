using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spotify.Metro.Util
{
    public sealed class DelegateMarshaler
    {
        private SynchronizationContext _synchronizationContext;
        
        public static DelegateMarshaler Create()
        {
            if (SynchronizationContext.Current == null)
            {
                throw new InvalidOperationException("No SynchronizationContext exists for the current thread.");
            }

            return new DelegateMarshaler(SynchronizationContext.Current);
        }

        private DelegateMarshaler(SynchronizationContext synchronizationContext)
        {
            this._synchronizationContext = synchronizationContext;
        }

        private bool IsMarshalRequired
        {
            get
            {
                return this._synchronizationContext != SynchronizationContext.Current;
            }
        }

        public void Invoke<T>(Action<T> action, T arg)
        {
            if (this.IsMarshalRequired == false)
            {
                // already on the target thread, just invoke delegate directly
                action(arg);
            }
            else
            {
                // marshal the delegate call to the target thread
                this._synchronizationContext.Send(delegate { action(arg); }, null);
            }
        }

        //simplifies use of threadpool so arguments do not need to be cast
        public static void QueueOnThreadPoolThread<T>(Action<T> action, T arg)
        {
            ThreadPool.QueueUserWorkItem(delegate { action(arg); });
        }
    }
}
