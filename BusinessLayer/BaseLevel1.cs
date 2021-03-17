using Common.Enum;
using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   

    public class BaseLevel1 : IDisposable
    {
        protected BusinessEntity.CustomerDBEntities context = null;
        protected ICache iCache;
        private bool disposed = false;

        public BaseLevel1(ICache _iCache)
        {

            iCache = _iCache;

            string connectionString = GetConnectionString(Common.Enum.QueryStringType.CustomerDBEntityFramework);

            if (connectionString != null)
            {
                context = new BusinessEntity.CustomerDBEntities(connectionString);
            }
        }


        #region IDispose

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion







        public string GetConnectionString(QueryStringType type)
        {



            if (iCache == null)
            {
                return string.Empty;
            }


            

            string connectionString = iCache.GetCache<string>(type.ToString()?? "");
           
            return connectionString;
        }

         
        

       
    }


}
