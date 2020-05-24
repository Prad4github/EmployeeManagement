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
    public class ClientController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IDTOModel _dtomodel;

        public ClientController(IUnitOfWork unitOfWork,
                                 IDTOModel dtomodel)
        {
            _unitOfWork = unitOfWork;
            _dtomodel = dtomodel;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Clients>> Get()
        {
            return Ok(_unitOfWork.ClientRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Clients> Get(Guid id)
        {
            return Ok(_unitOfWork.ClientRepository.Get(id));
        }

        [HttpPost]
        public void Post(Client value)
        {
            _unitOfWork.ClientRepository.Add(_dtomodel.GetModelObject(value));
            _unitOfWork.Complete();
        }

        [HttpPut]
        public void Put(Client value)
        {
            var entity = _dtomodel.GetModelObject(value);
            entity.ClientId = value.ClientId;
            _unitOfWork.ClientRepository.Update(entity);
            _unitOfWork.Complete();
        }

        [HttpDelete]
        public void Delete(Client value)
        {
            var entity = _dtomodel.GetModelObject(value);
            entity.ClientId = value.ClientId;
            _unitOfWork.ClientRepository.Remove(entity);
            _unitOfWork.Complete();
        }

    }
}
