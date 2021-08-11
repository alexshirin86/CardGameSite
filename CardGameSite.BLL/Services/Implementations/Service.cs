using CardGameSite.DAL.Repositories.Interfaces;
using CardGameSite.BLL.Infrastructure;
using CardGameSite.BLL.Services.Interfaces;
using System.Collections.Generic;
using CardGameSite.BLL.DTO.Interfaces;
using AutoMapper;


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

        public IEnumerable<DTO> GetObjectsDto()
        {

            return _mapper.Map<IEnumerable<T>, IEnumerable<DTO>>(_uow.Repository.GetAll());
        }

        public DTO GetObjectDto(int idClassDTO)
        {
            var obj = _uow.Repository.Get(idClassDTO);
            if (obj == null)
                throw new ValidationException("Объект не найден", "");

            return _mapper.Map<T, DTO>(obj);            
        }

        public void SaveObject(DTO obj)
        {
            T objT = _mapper.Map<DTO, T>(obj);

            if (obj.Id == 0)
            {
                _uow.Repository.Create(objT);
            }
            else
            {
                _uow.Repository.Update(objT);
            }

            _uow.Save();
        }

        public DTO DeleteObject(int idClassDTO)
        {            
            T obj = _uow.Repository.Delete(idClassDTO);

            if (obj != null)
                _uow.Save();

            return _mapper.Map<T, DTO>(obj);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
