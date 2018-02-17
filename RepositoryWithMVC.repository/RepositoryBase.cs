using System;
using System.Data.Entity;

namespace RepositoryWithMVC.repository
{
    public class RepositoryBase<C> : IDisposable
        where C : DbContext, new()
    {
        private C _DataContext;

        public virtual C DataContext
        {
            get
            {
                if(_DataContext == null)
                {
                    _DataContext = new C();
                }
                return _DataContext;
            }
        }
        public void Dispose()
        {
            if (DataContext != null) DataContext.Dispose();
        }
        #region IDisposable.Dispose()      
       /* private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    DataContext.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }*/
        #endregion
    }
}