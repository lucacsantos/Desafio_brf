using FluentValidation;

namespace GestaoPessoa.Models.Validators
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation() 
        {
            RuleFor(pessoa => pessoa.Nome).NotNull().NotEqual("string").NotEqual("");
            RuleFor(pessoa => pessoa.Email).EmailAddress();
            RuleFor(pessoa => pessoa.Idade).NotEqual(0);
            RuleFor(pessoa => pessoa.Sexo).NotNull().NotEqual("string").NotEqual("");
            RuleFor(pessoa => pessoa.Rua).NotNull().NotEqual("string").NotEqual("");
            RuleFor(pessoa => pessoa.Bairro).NotNull().NotEqual("string").NotEqual("");
            RuleFor(pessoa => pessoa.Cidade).NotNull().NotEqual("string").NotEqual("");
            RuleFor(pessoa => pessoa.CEP).NotNull().NotEqual("string").NotEqual("");
            RuleFor(pessoa => pessoa.Estado).NotNull().NotEqual("string").NotEqual("")  ;
        }   
    }
}
