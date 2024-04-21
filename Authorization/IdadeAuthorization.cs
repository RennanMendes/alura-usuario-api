using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuariosApi.Authorization
{
    public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
        {
            var dataNacimentoClaim = context.User.Claims.First(claim => claim.Type == ClaimTypes.DateOfBirth);

            if (dataNacimentoClaim is null)
            {
                return Task.CompletedTask;
            }

            var dataNascimento = Convert.ToDateTime(dataNacimentoClaim.Value);

            var idadeUsuario = DateTime.Today.Year - dataNascimento.Year;

            if(dataNascimento> DateTime.Today.AddYears(-idadeUsuario))
            {
                idadeUsuario--;
            }

            if (idadeUsuario >= requirement.Idade)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
