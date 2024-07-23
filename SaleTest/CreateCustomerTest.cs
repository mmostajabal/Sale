using Application.CustomerCRUD.Commands.Add;
using Domain.Customers;
using Moq;
using Persistence.Contracts.Repository;
using Persistence.Contracts.UnitOfWork;
using SaleAPI.Controllers;
using Shared.DTO.Customers;

namespace SaleTest
{
    public class CreateCustomerTest
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private AddCustomerCommandHandler _addCustomerCommandHandler;
        private Mock<IRepository<Customer>> _customerRepMock;
        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _addCustomerCommandHandler = new AddCustomerCommandHandler(_unitOfWorkMock.Object);
            _customerRepMock = new Mock<IRepository<Customer>>();
        }

        [Test]
        public async Task Create_Custemer_Handler()
        {
            //  Arrange
            var customerCommand = AddCustomerCommand.GetInstance("MO2", "Mostajab", "Address Test", "1014");

            _unitOfWorkMock.Setup(o => o.CustomersRep).Returns(_customerRepMock.Object);

            // Act 
            var result = await _addCustomerCommandHandler.Handle(customerCommand, CancellationToken.None);
            // Assert
            Assert.IsNotNull(result);

            _unitOfWorkMock.Verify(o=>o.CustomersRep.AddAsync(It.IsAny<Domain.Customers.Customer>(),CancellationToken.None), Times.Once());

            _unitOfWorkMock.Verify(o=>o.SaveAsync(), Times.Once());
            Assert.Pass();
        }
    }
}