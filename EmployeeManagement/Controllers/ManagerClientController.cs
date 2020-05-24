using System;
using System.Collections.Generic;
using EmployeeManagement.DTO;
using EmployeeManagement.DTOModelConverter;
using EmployeeManagement.Models;
using EmployeeManagement.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ManagerClientController(IUnitOfWork unitOfWork,
                                       IDTOModel dtomodel)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("AllManagerWithClients")]
        [HttpGet]
        public ActionResult<IEnumerable<Managers>> Get()
        {
            var result = _unitOfWork.ManagersRepository.GetAllManagerWithClients();
            return Ok(result);
        }

        [HttpGet("AllClientwithManager")]
        public ActionResult<Clients> Get(int id)
        {
            var result = _unitOfWork.ManagersRepository.GetAllClientsWithManager();
            return Ok(result);
        }

        [HttpGet("ClientForManager/{id}")]
        public ActionResult<Clients>Get(Guid id)
        {
            var result = _unitOfWork.ManagersRepository.GetAllClientForManager(id);
            return Ok(result);
        }

    }
}