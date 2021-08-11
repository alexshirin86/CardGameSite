using System.Collections.Generic;


namespace CardGameSite.BLL.Services.Interfaces
{
    public interface IService<classDTO> where classDTO : class
    {
        classDTO GetObjectDto(int idClassDTO);
        IEnumerable<classDTO> GetObjectsDto();

        void SaveObject(classDTO obj);

        classDTO DeleteObject(int idClassDTO);
        void Dispose();
    }
}
