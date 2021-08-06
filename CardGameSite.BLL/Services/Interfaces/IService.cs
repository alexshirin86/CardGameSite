using System.Collections.Generic;


namespace CardGameSite.BLL.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        T GetObjectDto(int? idT);
        IEnumerable<T> GetObjectsDto();
        void Dispose();
    }
}
