using Microsoft.AspNetCore.Identity;

using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Eshop.Models
{
    public class Order
    {
        public const int NAME_MAX_LENGTH = 100;

        public int Id { get; }
        public string ClientName { get; }
        public Email ClientEmail { get; }
 //       public Phone? Phone { get; }

        public DateTime DateOfCreation { get; }

        public OrderState State { get; private set; }


        private List<Product> _products = new List<Product>();
        public List<Product> Products { get { return _products; } } 

        public List<OrderProduct> OrderProducts { get; set; } = new();
        private Order() { }

        private Order(string clientName, Email clientEmail, DateTime createdAt, OrderState orderState, int? id = null) 
        { 
            ClientName = clientName;
            ClientEmail = clientEmail;
            DateOfCreation = createdAt;         
            State = orderState;
            if (id.HasValue) Id = id.Value;
        }
        public static Result<Order> Create(string clientName, Email clientEmail, DateTime createdAt, OrderState orderState, int? id = null)
        {
            if (string.IsNullOrEmpty(clientName) || clientName.Length > NAME_MAX_LENGTH)
                return Result.Failure<Order>($"{nameof(clientName)} is empty or too long");

            if (clientEmail == null)
                return Result.Failure<Order>($"{nameof(clientEmail)} can not be null");

            return Result.Success<Order>(new Order(clientName, clientEmail, createdAt, orderState, id));

        }

        public Result ChangeState(OrderState newState)
        {
            State = newState;
            return Result.Success();
        }
    }

    public class Client
    {

        public string Name { get; }
        public Email Email { get; }
        public Phone? Phone { get; }
        public const int NAME_MAX_LENGTH = 100;

        private Client() { }
        private Client(string name, Email email, Phone? phone) 
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
        public static Result<Client> Create(string? name, string? email, string? phone)
        {
            if (string.IsNullOrEmpty(name) || name.Length > NAME_MAX_LENGTH)
                return Result.Failure<Client>($"{nameof(name)} is empty or too long");
            var emailResult = Email.Create(email);
            if (emailResult.IsFailure)
                return Result.Failure<Client>(emailResult.Error);

            if (string.IsNullOrEmpty(phone))
                return Result.Success<Client>(new Client(name, emailResult.Value, null));

            var phoneResult = Phone.CreateCz(phone);
            if (phoneResult.IsFailure)
                return Result.Failure<Client>(phoneResult.Error);

            return Result.Success<Client>(new Client(name, emailResult.Value, phoneResult.Value));


        }
    }

    public class Phone
    {
        public string Value { get;}

        private Phone(string value) 
        {
            Value = value;
        }

        public static Result<Phone> CreateCz(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return Result.Failure<Phone>($"{nameof(phone)} is null");

            Regex regexCzNumber = new Regex(@"^(?:\+420)?\d{ 3}\s ?\d{ 3}\s ?\d{ 3}$");

            if (regexCzNumber.Match(phone).Success)
                return Result.Success<Phone>(new Phone(phone));
            else
                return Result.Failure<Phone>("Phone number doesn't like czech phone number");
        }
 
    }

    public class Email
    {
        public string Value { get; }
        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrEmpty(email))
                return Result.Failure<Email>($"{nameof(email)} is null");

            Regex regexEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+");

            if (regexEmail.Match(email).Success)
                return Result.Success<Email>(new Email(email));
            else
                return Result.Failure<Email>("Invalid email address");
        }
    }
}
