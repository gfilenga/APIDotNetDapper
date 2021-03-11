using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        // Fail Fast Validation
        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(FirstName, 2, "FirstName", "O nome deve conter pelo menos 2 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 2, "LastName", "O sobrenome deve conter pelo menos 2 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres")
                .IsEmail(Email, "Email", "O email é inválido")
                .HasLen(Document, 11, "Document", "CPF Inválido")
            );

            return Valid();
        }
    }
}