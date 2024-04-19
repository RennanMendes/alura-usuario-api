using AutoMapper;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles;

public class UsusarioProfile : Profile
{
    public UsusarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    }
}