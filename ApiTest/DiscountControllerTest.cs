using Core.Models;
using DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Controllers;
using Xunit;

namespace ApiTest
{
    public class DiscountControllerTest
    {
        private readonly DiscountController _controller;
        private readonly IDiscountService _service;

        public DiscountControllerTest()
        {
            _service = new DiscountServiceMock();
            _controller = new DiscountController(_service);
        }

        [Fact]
        public void GetBillsTest()
        {
            // Act
            var okResult = _controller.GetBills() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Bill>>(okResult.Value);
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public void CalculateDiscountTest()
        {
            // Arrange
            var testBill = new Bill()
            {
                Id = 1,
                AccountId = 1
            };
            // Act
            var createdResponse = _controller.CalculateDiscount(testBill) as OkObjectResult;
            var discountTestResult = createdResponse.Value as DiscountResult;
            // Assert
            Assert.IsType<DiscountResult>(discountTestResult);
            Assert.Equal(new decimal(247.101), discountTestResult.PayableAmount);
        }
    }
}
