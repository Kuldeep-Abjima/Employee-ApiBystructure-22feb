using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.microservices.Data
{
    public class Disposable : IDisposable
    {
        private bool _disposed;
        ~Disposable() 
        {
            Dispose(false);
        
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public void Dispose(bool disposing)
        {
            if(!_disposed && disposing)
            {
                DisposeCore();
            }
            _disposed= true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}
