using System.Collections.Generic;
using System.Threading.Tasks;


namespace CardGameSite.BLL.Services.Interfaces
{
    public interface IService<classDTO> where classDTO : class
    {
        Task<classDTO> GetObjectDtoAsync(int idClassDTO);
        Task<IEnumerable<classDTO>> GetObjectsDtoAsync();

        void SaveObjectAsync(classDTO obj);

        Task<classDTO> DeleteObjectAsync(int idClassDTO);
        void Dispose();
    }
}
