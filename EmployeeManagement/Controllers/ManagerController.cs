using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DTO;
using EmployeeManagement.DTOModelConverter;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using EmployeeManagement.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDTOModel _dtomodel;
        public ManagerController(IUnitOfWork unitOfWork,
                                  IDTOModel dtomodel)
        {
            _unitOfWork = unitOfWork;
            _dtomodel = dtomodel;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Manager>> Get()
        {
            return Ok(_unitOfWork.ManagersRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Manager> Get(Guid id)
        {
            return Ok(_unitOfWork.ManagersRepository.Get(id));
        }

        [HttpPost]
        public void Post(Manager dtoManager)
        {
            _unitOfWork.ManagersRepository.Add(_dtomodel.GetModelObject(dtoManager));
            _unitOfWork.Complete();
        }

        [HttpPut]
        public void Put(Manager user)
        {
            var entity = _dtomodel.GetModelObject(user);
            entity.ManagerId = user.ManagerId;
            _unitOfWork.ManagersRepository.Update(entity);
            _unitOfWork.Complete();
        }

        [HttpDelete]
        public void Delete(Manager user)
        {
            var entity = _dtomodel.GetModelObject(user);
            entity.ManagerId = user.ManagerId;
            _unitOfWork.ManagersRepository.Remove(entity);
            _unitOfWork.Complete();
        }
    }
}
