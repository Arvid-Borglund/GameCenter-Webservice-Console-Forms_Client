
using System.Collections.Generic;

namespace WebApplicationGameCenter.Interfaces
{
    public interface IEntityManager
    {
        bool Create(List<KeyValuePairCustom> entityData);
        bool Delete(string idDelete);
        string Load();
    }
}
