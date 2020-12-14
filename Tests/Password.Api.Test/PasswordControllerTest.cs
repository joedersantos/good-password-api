using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Password.Api.Controllers;
using Password.Api.Models;
using Password.Api.Validators;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Password.Api.Test
{
    public class PasswordControllerTest : IClassFixture<WebApplicationFactory<Password.Api.Startup>>
    {
        private readonly PasswordController controller;
        private readonly WebApplicationFactory<Password.Api.Startup> _factory;

        public PasswordControllerTest(WebApplicationFactory<Password.Api.Startup> factory)
        {
            controller = new PasswordController();
            _factory = factory;
        }

        [Fact]
        public async Task Post_senha_valida()
        {           
            var client = _factory.CreateClient();

            // Act            
            var response = await client.PostAsync("/Password/validate-rule", new StringContent(@"{ ""password"": ""AbTp9!fok""}", Encoding.UTF8, "application/json"));

            // Assert
            response.Should().Be200Ok();
            //response.Content.ReadAsStringAsync().Result.Should().Be("true");
           
        }
        [Fact]
        public async Task Post_senha_invalida()
        {
            var client = _factory.CreateClient();

            // Act            
            var response = await client.PostAsync("/Password/validate-rule", new StringContent(@"{ ""password"": ""Ab@""}", Encoding.UTF8, "application/json"));

            // Assert
            response.Should().Be400BadRequest();
            
        }

    }
}
