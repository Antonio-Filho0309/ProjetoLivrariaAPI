using AutoMapper;
using ProjetoLivrariaAPI.Dtos;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Helpers {
    public class ProjetoLivrariaProfile : Profile {

        public ProjetoLivrariaProfile()
        {
            //Usuário
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            //Editora
            CreateMap<Publisher, PublisherDto>();
            CreateMap<PublisherDto, Publisher>();

            //Livro  
            CreateMap<Book , CreateBookDto>();
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}
