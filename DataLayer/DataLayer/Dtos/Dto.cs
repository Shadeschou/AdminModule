using System;

namespace DataLayer.Dtos
{
    public abstract class Dto
    {
        public virtual int getPK()
        {
            throw new NotImplementedException();
        }
    }
}
