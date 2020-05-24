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
    /// Added few method for unit testing through unit of work instantiation
    /// </summary>
    public class RepositoryInmemoryUnitOfWork
    {
        IManagerRepository managerRepository;
        IClientsRepository clientRepository;
        IUnitOfWork unitOfWork;

        public RepositoryInmemoryUnitOfWork()
        {
            DbContextOptions<ApiContext> options;
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase();
            options = builder.Options;
            ApiContext ManagerDataContext = new ApiContext(options);
            ManagerDataContext.Database.EnsureDeleted();
            ManagerDataContext.Database.EnsureCreated();

            managerRepository =new ManagerRepository(ManagerDataContext);
            clientRepository = new ClientRepository(ManagerDataContext);
            unitOfWork = new UnitOfwork(ManagerDataContext);
        }

        [Fact]
        public void Add_Manager()
        {
            Managers manager = new Managers()
            {
                ManagerId = Guid.NewGuid(),
                FirstName = "fred",
                LastName = "Blogs",
                ManagerName = "TestSuit"
            };

            managerRepository.Add(manager);        

            Assert.Equal("fred", manager.FirstName);
            Assert.Equal("Blogs", manager.LastName);
            Assert.Null(manager.Email);
        }


        [Fact]
        public void Add_Manager_UnitOfwork()
        {
            Managers manager = new Managers()
            {
                ManagerId = Guid.NewGuid(),
                FirstName = "fred",
                LastName = "Blogs",
                ManagerName = "TestSuit"
            };

            unitOfWork.ManagersRepository.Add(manager);
            unitOfWork.Complete();

            Assert.Equal(1, unitOfWork.ManagersRepository.GetAll().Count());
            Assert.Equal("fred", manager.FirstName);
            Assert.Equal("Blogs", manager.LastName);
            Assert.Null(manager.Email);
        }

        [Fact]
        public void Add_Client()
        {
            Clients client = new Clients()
            {
                ClientId = Guid.NewGuid(),
                FirstName = "fred",
                LastName = "Blogs",
                ClientName = "TestSuit"
            };

            clientRepository.Add(client);

            Assert.Equal("fred", client.FirstName);
            Assert.Equal("Blogs", client.LastName);
            Assert.Null(client.Email);
        }

        [Fact]
        public void Add_Client_UnitOfwork()
        {
            Clients client = new Clients()
            {
                ClientId = Guid.NewGuid(),
                FirstName = "fred",
                LastName = "Blogs",
                ClientName = "TestSuit"
            };

            unitOfWork.ClientRepository.Add(client);
            unitOfWork.Complete();

            Assert.Equal(1, unitOfWork.ClientRepository.GetAll().Count());
            Assert.Equal("fred", client.FirstName);
            Assert.Equal("Blogs", client.LastName);
            Assert.Null(client.Email);
        }

        [Fact]
        public void Find_Client_UnitOfwork()
        {
            Clients client = new Clients()
            {
                ClientId = Guid.NewGuid(),
                FirstName = "fred",
                LastName = "Blogs",
                ClientName = "TestSuit"
            };

            unitOfWork.ClientRepository.Add(client);
            unitOfWork.Complete();

            var result = unitOfWork.ClientRepository.Get(client.ClientId);
            Assert.NotNull(result);
            Assert.Equal("fred", result.FirstName);
            Assert.Equal("Blogs", result.LastName);
            Assert.Null(result.Email);
        }

        [Fact]
        public void Find_Manager_UnitOfwork()
        {
            Managers manager = new Managers()
            {
                ManagerId = Guid.NewGuid(),
                FirstName = "fred",
                LastName = "Blogs",
                ManagerName = "TestSuit"
            };

            unitOfWork.ManagersRepository.Add(manager);
            unitOfWork.Complete();
            var result = unitOfWork.ManagersRepository.Get(manager.ManagerId);
            Assert.NotNull(result);
            Assert.Equal("fred", result.FirstName);
            Assert.Equal("Blogs", result.LastName);
            Assert.Null(result.Email);
        }

        [Fact]
        public void Remove_Manager_UnitOfwork()
        {
            Managers manager = new Managers()
            {
                ManagerId = Guid.NewGuid(),
                FirstName = "fred",
                LastName = "Blogs",
                ManagerName = "TestSuit"
            };

            unitOfWork.ManagersRepository.Add(manager);
            unitOfWork.Complete();
            unitOfWork.ManagersRepository.Remove(manager);
            unitOfWork.Complete();
            var result = unitOfWork.ManagersRepository.Get(manager.ManagerId);
            Assert.Null(result);
        }

        [Fact]
        public void Remove_Client_UnitOfwork()
        {
            Clients client = new Clients()
            {
                ClientId = Guid.NewGuid(),
                FirstName = "fred",
                LastName = "Blogs",
                ClientName = "TestSuit"
            };

            unitOfWork.ClientRepository.Add(client);
            unitOfWork.Complete();
            unitOfWork.ClientRepository.Remove(client);
            unitOfWork.Complete();
            var result = unitOfWork.ClientRepository.Get(client.ClientId);
            Assert.Null(result);
        }
    }
}
