using CardGameSite.DAL.Repositories.Interfaces;
using CardGameSite.BLL.Infrastructure;
using CardGameSite.BLL.Services.Interfaces;
using System.Collections.Generic;
using AutoMapper;


namespace CardGameSite.BLL.Services.Implementations
{
    class Service<T, DTO> : IService<DTO> where T : class where DTO : class
    {
        IUnitOfWork<T> Database { get; set; }

        private IMapper _mapper;


        public Service(IUnitOfWork<T> uow, IMapper mapper)
        {
            Database = uow;
            _mapper = mapper;
        }

        public IEnumerable<DTO> GetObjectsDto()
        {

            return _mapper.Map<IEnumerable<T>, IEnumerable<DTO>>(Database.Repository.GetAll());
        }

        public DTO GetObjectDto(int? idT)
        {
            if (idT == null)
                throw new ValidationException("Не установлено id", "");
            var obj = Database.Repository.Get(idT.Value);
            if (obj == null)
                throw new ValidationException("Объект не найден", "");

            return _mapper.Map<T, DTO>(obj);            
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
