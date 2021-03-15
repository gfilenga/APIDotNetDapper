using System;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
            Notifiable,
            ICommandHandler<CreateCustomerCommand>,
            ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // verificar se o CPF já existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            // verificar se o email já existe na base
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este email já está em uso");

            // Criar os Value Objects
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            // Validar entidades e VO's
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);

            // Persistir o cliente
            _repository.Save(customer);

            // Enviar o email de boas vindas
            _emailService.Send(email.Address, "hello@balta.io", "Bem vindo", "Seja bem vindo ao Balta Store");

            //Retornar o resultado para tela
            return new CommandResult(true, "Bem-vindo ao BaltaStore", new
            {
                Id = customer.Id,
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}