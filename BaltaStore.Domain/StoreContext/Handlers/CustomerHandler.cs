using System;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
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
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // verificar se o CPF já existe na base

            // verificar se o email já existe na base

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

            // Persistir o cliente

            // Enviar o email de boas vindas

            //Retornar o resultado para tela

            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}