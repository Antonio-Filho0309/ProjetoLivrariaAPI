using AutoMapper;
using ProjetoLivrariaAPI.Dtos;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Helpers {
    public class ProjetoLivrariaProfile : Profile {

        public ProjetoLivrariaProfile()
        {
            //Usuário
            CreateMap<User, UserDto>().ReverseMap();

            //Editora
            CreateMap<Publisher, PublisherDto>().ReverseMap();

            //Livro  
            CreateMap<Book , CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
        }
    }
}
