using CardGameSite.DAL.Repositories.Interfaces;
using CardGameSite.BLL.Infrastructure;
using CardGameSite.BLL.Services.Interfaces;
using System.Collections.Generic;
using CardGameSite.BLL.DTO.Interfaces;
using AutoMapper;
using System.Threading.Tasks;


namespace CardGameSite.BLL.Services.Implementations
{
    class Service<T, DTO> : IService<DTO> where T : class where DTO : class, IDto
    {
        private IUnitOfWork<T> _uow;

        private IMapper _mapper;


        public Service(IUnitOfWork<T> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTO>> GetObjectsDtoAsync()
        {

            return _mapper.Map<IEnumerable<T>, IEnumerable<DTO>>(await _uow.Repository.GetAllAsync());
        }

        public async Task<DTO> GetObjectDtoAsync(int idClassDTO)
        {
            var obj = await _uow.Repository.GetAsync(idClassDTO);
            if (obj == null)
                throw new ValidationException("Объект не найден", "");

            return _mapper.Map<T, DTO>(obj);            
        }

        public async Task<int> SaveObjectAsync(DTO obj)
        {
            T objT = _mapper.Map<DTO, T>(obj);

            if (obj.Id == 0)
            {
                Task task = Task.Factory.StartNew(() => _uow.Repository.CreateAsync(objT));
                await task;
            }
            else
            {
                Task task = Task.Factory.StartNew(() => _uow.Repository.UpdateAsync(objT));
                await task;
            }

            return await _uow.SaveAsync();
        }

        public async Task<DTO> DeleteObjectAsync(int idClassDTO)
        {            
            T obj = await _uow.Repository.DeleteAsync(idClassDTO);

            if (obj != null)
            {
                await _uow.SaveAsync();
            }                
            return _mapper.Map<T, DTO>(obj);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
