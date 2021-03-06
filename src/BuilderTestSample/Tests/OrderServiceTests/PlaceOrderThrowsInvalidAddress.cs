﻿using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
using Xunit;

namespace BuilderTestSample.Tests.OrderServiceTests
{
   public class PlaceOrderThrowsInvalidAddress : BaseOrderServiceTests
   {
      [Fact]
      public void GivenNoStreet1()
      {
         var order = _orderBuilder
                       .WithTestValues()
                       .BuildCustomer(cb => cb.WithTestValues().BuildAddress(ab => ab.WithTestValues().Street1("")))
                       .Build();

         Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
      }
   }
}
