using WebSystem.Core;
using WebSystem.Test.Models;
using Bogus;
using FluentAssertions;
using WebSystem.Test.Dtos;
using Xunit.Abstractions;

namespace WebSystem.Test;

public class WebSystemMapperTest(ITestOutputHelper testOutputHelper)
{
    private readonly Faker _faker = new("pt_BR");
    private readonly ITestOutputHelper _testOutputHelper = testOutputHelper;

    [Fact]
    public void Given_User_Mapping_Return_UserDto()
    {
        var name = _faker.Name.FullName();
        var company = _faker.Company.CompanyName();
        var user = new User { Name = name, Company = company };

        var userDto = WebSystemMapper.Map<User, UserDto>(user);
        _testOutputHelper.WriteLine(userDto.ToString());

        userDto.Should().NotBeNull();
        userDto.Name.Should().Be(user.Name);
        userDto.Company.Should().Be(user.Company);
    }
    
    [Fact]
    public void Given_Order_Mapping_Return_OrderDto()
    {
        var name = _faker.Name.FullName();
        var description = _faker.Person.Avatar;
        var order = new Order { Name = name, Description = description };

        var orderDto = WebSystemMapper.Map<Order, OrderDto>(order);
        _testOutputHelper.WriteLine(orderDto.ToString());

        orderDto.Should().NotBeNull();
        orderDto.Name.Should().Be(order.Name);
        orderDto.Description.Should().Be(order.Description);
    }
}