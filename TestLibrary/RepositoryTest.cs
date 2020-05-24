using EmployeeManagement.Controllers;
using EmployeeManagement.DTOModelConverter;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using EmployeeManagement.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestLibrary
{
    /// <summary>
    /// Added few method for repository testing by mock object setup
    /// </summary>
    public class RepositoryTest
    {
        private Mock<IManagerRepository> _managerRepository;
        private Mock<IClientsRepository> _clientRepository;
        List<Managers> listManager;
        List<Clients> listClient;
        public RepositoryTest()
        {
            _managerRepository = new Mock<IManagerRepository>();
            _clientRepository = new Mock<IClientsRepository>();
            listManager = new List<Managers>();
            listClient = new List<Clients>();
            listManager.Add(new Managers() { ManagerName = "TestManager", ManagerId = Guid.NewGuid() });
            listManager.Add(new Managers() { ManagerName = "TestManager1", ManagerId = Guid.NewGuid() });
            listManager.Add(new Managers() { ManagerName = "TestManager2", ManagerId = Guid.NewGuid() });

            listClient.Add(new Clients() { ClientName = "TMClient", ClientId = Guid.NewGuid(), ManagerId = listManager[0].ManagerId });
            listClient.Add(new Clients() { ClientName = "TMClient1", ClientId = Guid.NewGuid(), ManagerId = listManager[0].ManagerId });
            listClient.Add(new Clients() { ClientName = "TM1Client", ClientId = Guid.NewGuid(), ManagerId = listManager[1].ManagerId });
            listClient.Add(new Clients() { ClientName = "TM1Client1", ClientId = Guid.NewGuid(), ManagerId = listManager[1].ManagerId });
            listClient.Add(new Clients() { ClientName = "TM2Client1", ClientId = Guid.NewGuid(), ManagerId = listManager[2].ManagerId });

            // Return all the Managers
            _managerRepository.Setup(mr => mr.GetAll()).Returns(listManager);

            // return a Manager by Id
            _managerRepository.Setup(mr => mr.Get(
                It.IsAny<Guid>())).Returns((Guid i) => listManager.Where(
                x => x.ManagerId == i).Single());

            // Return all the Clients
            _clientRepository.Setup(mr => mr.GetAll()).Returns(listClient);

            // return a Clients by Id
            _clientRepository.Setup(mr => mr.Get(
                It.IsAny<Guid>())).Returns((Guid i) => listClient.Where(
                x => x.ClientId == i).Single());

            //Similarly we can write method for other repository functions
        }

        [Fact]
        public void Test_GeAll()
        {
            IList<Managers> reult = _managerRepository.Object.GetAll().ToList();

            IList<Clients> reultClients = _clientRepository.Object.GetAll().ToList();

            Assert.Equal(reult.Count, listManager.Count);
            Assert.NotNull(reult);

            Assert.Equal(reultClients.Count, listClient.Count);
            Assert.NotNull(reultClients);
        }

        [Fact]
        public void Test_GetById()
        {
            var reultManager = _managerRepository.Object.Get(listManager[0].ManagerId);

            var reultClients = _clientRepository.Object.Get(listClient[0].ClientId);

            Assert.Equal(reultManager.ManagerName, listManager[0].ManagerName);
            Assert.NotNull(reultManager);

            Assert.Equal(reultClients.ClientName, listClient[0].ClientName);
            Assert.NotNull(reultClients);
        }

    }
}